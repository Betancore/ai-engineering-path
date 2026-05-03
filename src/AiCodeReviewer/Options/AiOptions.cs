using System.ComponentModel.DataAnnotations;
using AiCodeReviewer.Models;

namespace AiCodeReviewer.Options;

public class AiOptions
{
    public const string SectionName = "AI";

    [Required(ErrorMessage = "GeminiKey is required.")]
    public string GeminiKey { get; set; } = string.Empty;

    [Required]
    public string ModelId { get; set; } = GeminiModels.Gemini31ProPreview;
}
