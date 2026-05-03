using AiCodeReviewer.Models;

namespace AiCodeReviewer.Services;

/// <summary>
/// Defines the contract for discovering and reading source code files.
/// </summary>
public interface ISourceCodeProvider
{
    /// <summary>
    /// Discovers and reads all relevant source code files starting from the specified path.
    /// </summary>
    /// <param name="startPath">The path to start the search from.</param>
    /// <returns>A collection of read source code files.</returns>
    Task<IEnumerable<CodeFile>> GetSourceFilesAsync(string startPath);
}
