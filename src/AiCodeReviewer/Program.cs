using AiCodeReviewer.Options;
using AiCodeReviewer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// 1. Setup Host Builder
var builder = Host.CreateApplicationBuilder(args);

// Ensure user secrets are loaded even if environment is not explicitly Development
builder.Configuration.AddUserSecrets<Program>(optional: true);

// 2. Configure Options
builder.Services.AddOptions<AiOptions>()
    .BindConfiguration(AiOptions.SectionName)
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddOptions<SourceCodeProviderOptions>()
    .BindConfiguration(SourceCodeProviderOptions.SectionName)
    .ValidateDataAnnotations()
    .ValidateOnStart();

// 3. Configure Services
builder.Services.AddTransient<ISourceCodeProvider, SourceCodeProvider>();
builder.Services.AddTransient<IAiReviewService, AiReviewService>();

// 4. Build Host
using var host = builder.Build();

var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Starting AI Code Reviewer...");

try
{
    var sourceCodeProvider = host.Services.GetRequiredService<ISourceCodeProvider>();
    var aiReviewService = host.Services.GetRequiredService<IAiReviewService>();

    // Determine the root path to review
    var startPath = FindSrcDirectory(Directory.GetCurrentDirectory());
    logger.LogInformation("Discovering source files starting from: {StartPath}", startPath);

    var codeFiles = await sourceCodeProvider.GetSourceFilesAsync(startPath);
    var codeFilesList = codeFiles.ToList();

    if (!codeFilesList.Any())
    {
        logger.LogWarning("No source files found to review.");
        return;
    }

    logger.LogInformation("Found {Count} files to review.", codeFilesList.Count);

    // Perform AI Review
    var reviewResult = await aiReviewService.ReviewCodeAsync(codeFilesList);

    // Output Results
    Console.WriteLine("\n================ AI CODE REVIEW =================\n");
    Console.WriteLine(reviewResult.Feedback);
    Console.WriteLine("\n=================================================");
}
catch (Exception exception)
{
    logger.LogCritical(exception, "An unexpected error occurred during execution.");
}
finally
{
    logger.LogInformation("AI Code Reviewer finished.");
}

// Helper to find 'src' directory from current execution path
static string FindSrcDirectory(string currentPath)
{
    var dirInfo = new DirectoryInfo(currentPath);

    while (dirInfo != null)
    {
        var potentialSrc = Path.Combine(dirInfo.FullName, "src");
        if (Directory.Exists(potentialSrc))
        {
            return potentialSrc;
        }
        dirInfo = dirInfo.Parent;
    }

    // Default to current directory if no 'src' found
    return currentPath;
}
