namespace AiCodeReviewer.Models;

/// <summary>
/// Represents the result of an AI code review.
/// </summary>
public record ReviewResult
{
    public required string Feedback { get; init; }
}
