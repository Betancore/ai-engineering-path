using System.Collections.Concurrent;
using AiCodeReviewer.Models;
using AiCodeReviewer.Options;
using Microsoft.Extensions.Options;

namespace AiCodeReviewer.Services;

/// <summary>
/// Provides source code by traversing the local file system.
/// </summary>
public class SourceCodeProvider : ISourceCodeProvider
{
    private readonly SourceCodeProviderOptions _options;

    public SourceCodeProvider(IOptions<SourceCodeProviderOptions> options)
    {
        _options = options.Value;
    }

    public async Task<IEnumerable<CodeFile>> GetSourceFilesAsync(string startPath)
    {
        if (string.IsNullOrWhiteSpace(startPath))
        {
            throw new ArgumentException("Start path cannot be null or empty.", nameof(startPath));
        }

        if (!Directory.Exists(startPath))
        {
            throw new DirectoryNotFoundException($"The specified directory does not exist: {startPath}");
        }

        var enumerationOptions = new EnumerationOptions
        {
            IgnoreInaccessible = true,
            RecurseSubdirectories = true,
            AttributesToSkip = FileAttributes.Hidden | FileAttributes.System | FileAttributes.ReparsePoint
        };

        var sourceFiles = Directory.EnumerateFiles(startPath, _options.SearchPattern, enumerationOptions).Where(file => !IsExcluded(file));

        var codeFiles = new ConcurrentBag<CodeFile>();

        await Parallel.ForEachAsync(sourceFiles, async (filePath, cancellationToken) =>
        {
            var relativePath = Path.GetRelativePath(startPath, filePath);
            var content = await File.ReadAllTextAsync(filePath, cancellationToken);
            codeFiles.Add(new CodeFile
            {
                RelativePath = relativePath,
                Content = content
            });
        });

        return codeFiles;
    }

    private bool IsExcluded(string filePath)
    {
        if (_options.ExcludedDirectories == null || _options.ExcludedDirectories.Length == 0)
        {
            return false;
        }

        var directorySegments = Path.GetDirectoryName(filePath)?.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) ?? Array.Empty<string>();

        foreach (var excludedDirectory in _options.ExcludedDirectories)
        {
            if (directorySegments.Contains(excludedDirectory, StringComparer.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
}
