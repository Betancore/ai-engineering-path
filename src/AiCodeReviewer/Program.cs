using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.AI;
using Google.GenAI;
using System.Text;

// 1. Setup Configuration
var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string apiKey = config["AI:GeminiKey"] ?? throw new Exception("API Key not found!");

// 2. Initialize Client
var googleClient = new Client(apiKey: apiKey);
// Using Gemini 3 Flash - the fastest 2026 model for dev tools
IChatClient client = googleClient.AsIChatClient("gemini-3-flash-preview");

// 3. Robust Directory Discovery
static string FindSrcPath(string startDir)
{
    var dir = new DirectoryInfo(startDir);
    while (dir != null && !dir.GetDirectories("src").Any())
        dir = dir.Parent;

    return dir != null ? Path.Combine(dir.FullName, "src") : throw new DirectoryNotFoundException("Could not locate 'src' folder!");
}

string srcPath = FindSrcPath(AppContext.BaseDirectory);
var codeFiles = Directory.GetFiles(srcPath, "*.cs", SearchOption.AllDirectories)
    .Where(f => !f.Contains("obj") && !f.Contains("bin"))
    .ToList();

// Debug output to see what is happening
Console.WriteLine($"[DEBUG] Scanning: {srcPath}");
Console.WriteLine($"[DEBUG] Found {codeFiles.Count} files.");

if (codeFiles.Count == 0)
{
    Console.WriteLine("Error: No .cs files found. Check your directory structure.");
    return;
}

// 4. Prepare Context & Prompt (English-optimized)
var contextBuilder = new StringBuilder();
contextBuilder.AppendLine("Task: Perform a Code Review of the following C# project.");
contextBuilder.AppendLine("Focus: SOLID principles, Clean Code violations, and potential bugs.");
contextBuilder.AppendLine("Format: Technical, concise, and structured feedback in English.\n");

foreach (var file in codeFiles)
{
    string relativePath = Path.GetRelativePath(srcPath, file);
    string content = await File.ReadAllTextAsync(file);

    contextBuilder.AppendLine($"--- FILE: {relativePath} ---");
    contextBuilder.AppendLine(content);
    contextBuilder.AppendLine("--- END OF FILE ---\n");
}

contextBuilder.AppendLine("\nPlease provide your feedback based on the code provided above.");

// 5. Execution
var chatHistory = new List<ChatMessage>
{
    new ChatMessage(ChatRole.User, contextBuilder.ToString())
};

var options = new ChatOptions { Temperature = 0.0f };
Console.WriteLine($"Sending context to {client.GetType().Name}... Please wait.");

var response = await client.GetResponseAsync(chatHistory, options);

Console.WriteLine("\n=== AI ARCHITECT REVIEW ===\n");
Console.WriteLine(response.Messages[0].Text);