using AiCodeReviewer.Models;

namespace AiCodeReviewer.Services;

/// <summary>
/// Defines the contract for an AI code review service.
/// </summary>
public interface IAiReviewService
{
    /// <summary>
    /// Performs an AI review on the provided collection of code files.
    /// </summary>
    /// <param name="codeFiles">The source files to review.</param>
    /// <returns>The result of the review.</returns>
    Task<ReviewResult> ReviewCodeAsync(IEnumerable<CodeFile> codeFiles);
}
