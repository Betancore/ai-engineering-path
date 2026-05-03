# C# Coding Guidelines

This project strictly adheres to Senior Architecture C# conventions to ensure maintainability, readability, and consistency.

## 1. File and Type Organization
- **One Type Per File**: Each `class`, `interface`, `record`, `struct`, or `enum` must reside in its own dedicated file. 
- The filename must exactly match the type name (e.g., `AiOptions.cs` for `public class AiOptions`).

## 2. Using Directives
- **Location**: `using` directives must be placed at the very top of the file, outside of the namespace declaration.
- **Sorting**: 
  - Alphabetically sorted.
  - `System.*` namespaces must always be placed first, before any `Microsoft.*`, third-party, or local project namespaces.
- **Minimization**: Do not include explicit usings for namespaces already provided globally by .NET Implicit Usings (e.g., `System`, `System.IO`, `System.Linq`, `System.Threading.Tasks`, `System.Collections.Generic`).

## 3. Member Layout (Sorting)
Within any `class`, `struct`, or `record`, members must be organized in the following top-to-bottom order to maintain clear logical progression:

1. **Constants** (`public const`, then `private const`)
2. **Static Fields**
3. **Instance Fields** (`private readonly`, etc.)
4. **Constructors**
5. **Properties**
6. **Public Methods**
7. **Private / Protected Methods**

*Within each category, order by access modifier: `public` -> `internal` -> `protected` -> `private`.*

## 4. Naming Conventions
- **Classes, Structs, Records, Properties, Public Methods, and Events**: `PascalCase`
- **Interfaces**: `PascalCase` prefixed with `I` (e.g., `ISourceCodeProvider`)
- **Constants**: `PascalCase` (e.g., `public const string SectionName = "AI";`)
- **Parameters and Local Variables**: `camelCase`
- **Private Fields**: `_camelCase` (must start with an underscore)

*Avoid abbreviations. Use full, descriptive words (e.g., `cancellationToken` instead of `ct`, `sourceFiles` instead of `sf`).*

## 5. Formatting & Indentation
- **Indentation**: Strictly 4 spaces. No tabs.
- **Bracing**: Allman style (curly braces must always be placed on a new line).
- Enforced by `.editorconfig`.
