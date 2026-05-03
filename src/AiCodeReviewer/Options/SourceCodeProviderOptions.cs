namespace AiCodeReviewer.Options;

public class SourceCodeProviderOptions
{
    public const string SectionName = "SourceCodeProvider";

    public string[] ExcludedDirectories { get; set; } = { "bin", "obj", ".git", ".vs", "node_modules" };
    public string SearchPattern { get; set; } = "*.cs";
}
