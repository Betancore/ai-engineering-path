namespace AiCodeReviewer.Models;

/// <summary>
/// Represents a source code file discovered in the file system.
/// </summary>
public record CodeFile
{
    public required string RelativePath { get; init; }
    public required string Content { get; init; }
}
