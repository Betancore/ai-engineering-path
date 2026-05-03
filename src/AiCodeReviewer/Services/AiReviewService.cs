using System.Text;
using AiCodeReviewer.Models;
using AiCodeReviewer.Options;
using Google.GenAI;
using Google.GenAI.Types;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AiCodeReviewer.Services;

/// <summary>
/// Implements an AI code review service using the Google GenAI SDK.
/// </summary>
public class AiReviewService : IAiReviewService
{
    private readonly ILogger<AiReviewService> _logger;
    private readonly AiOptions _options;
    private readonly Client _client;

    public AiReviewService(IOptions<AiOptions> options, ILogger<AiReviewService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));

        if (string.IsNullOrWhiteSpace(_options.GeminiKey))
        {
            throw new InvalidOperationException("The Gemini API Key is not configured. Please add it to your configuration (e.g., via user secrets).");
        }

        _client = new Client(apiKey: _options.GeminiKey);
    }

    public async Task<ReviewResult> ReviewCodeAsync(IEnumerable<CodeFile> codeFiles)
    {
        if (codeFiles == null)
        {
            throw new ArgumentNullException(nameof(codeFiles));
        }

        _logger.LogInformation("Preparing code context...");

        var systemInstruction = @"You are an Expert Senior C# Architect. 
Please review the following C# codebase.
Focus on:
1. SOLID Principles
2. Clean Code practices
3. Potential bugs or performance issues
4. Security vulnerabilities

Provide a detailed summary of your findings and actionable recommendations for improvement.";

        var userContext = GetFormattedCodeContext(codeFiles);

        _logger.LogInformation("Sending prompt to {ModelId}...", _options.ModelId);

        try
        {
            var configuration = new GenerateContentConfig
            {
                SystemInstruction = new Content
                {
                    Parts = new List<Part>
                    {
                        new Part { Text = systemInstruction }
                    }
                }
            };

            var response = await _client.Models.GenerateContentAsync(
                model: _options.ModelId,
                contents: userContext,
                config: configuration
            );

            _logger.LogInformation("Review completed successfully.");

            return new ReviewResult
            {
                Feedback = response.Text ?? "No response received from the model."
            };
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "An error occurred while communicating with the AI service.");
            
            throw;
        }
    }

    private static string GetFormattedCodeContext(IEnumerable<CodeFile> codeFiles)
    {
        var contextBuilder = new StringBuilder();

        foreach (var file in codeFiles)
        {
            contextBuilder.AppendLine($"--- BEGIN FILE: {file.RelativePath} ---");
            contextBuilder.AppendLine(file.Content);
            contextBuilder.AppendLine($"--- END FILE: {file.RelativePath} ---");
            contextBuilder.AppendLine();
        }

        return contextBuilder.ToString();
    }
}
