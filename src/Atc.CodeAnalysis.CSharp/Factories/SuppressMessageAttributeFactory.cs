namespace Atc.CodeAnalysis.CSharp.Factories;

/// <summary>
/// SuppressMessage Attribute Factory.
/// </summary>
/// <remarks>
/// Code Analysis Warnings for Managed Code by CheckId:
/// https://docs.microsoft.com/en-us/visualstudio/code-quality/code-analysis-warnings-for-managed-code-by-checkid?view=vs-2019.
/// </remarks>
public static class SuppressMessageAttributeFactory
{
    /// <summary>
    /// Creates a <see cref="SuppressMessageAttribute"/> for a Code Analysis (CA) rule suppression.
    /// </summary>
    /// <param name="checkId">The numeric identifier of the CA rule to suppress (e.g., 1062 for CA1062).</param>
    /// <param name="justification">The justification for suppressing the rule. If null or empty, defaults to "OK."</param>
    /// <returns>A <see cref="SuppressMessageAttribute"/> configured for the specified Code Analysis rule.</returns>
    /// <exception cref="NotImplementedException">Thrown when the specified <paramref name="checkId"/> is not implemented in the factory.</exception>
    [SuppressMessage("Info Code Smell", "S1135:Track uses of \"TODO\" tags", Justification = "Allow TODO here.")]
    public static SuppressMessageAttribute CreateCodeAnalysisSuppression(
        int checkId,
        string? justification)
    {
        if (string.IsNullOrEmpty(justification))
        {
            justification = "OK.";
        }

        return checkId switch
        {
            // TODO: Add all rules
            1062 => new SuppressMessageAttribute("Design", "CA1062:Validate arguments of public methods") { Justification = justification },
            1720 => new SuppressMessageAttribute("Naming", "CA1720:Identifiers should not contain type names") { Justification = justification },
            _ => throw new NotImplementedException($"Rule for CA{checkId} must be implemented."),
        };
    }

    /// <summary>
    /// Creates a <see cref="SuppressMessageAttribute"/> for a StyleCop (SA) rule suppression.
    /// </summary>
    /// <param name="checkId">The numeric identifier of the SA rule to suppress (e.g., 1413 for SA1413).</param>
    /// <param name="justification">The justification for suppressing the rule. If null or empty, defaults to "OK."</param>
    /// <returns>A <see cref="SuppressMessageAttribute"/> configured for the specified StyleCop rule.</returns>
    /// <exception cref="NotImplementedException">Thrown when the specified <paramref name="checkId"/> is not implemented in the factory.</exception>
    [SuppressMessage("Info Code Smell", "S1135:Track uses of \"TODO\" tags", Justification = "Allow TODO here.")]
    public static SuppressMessageAttribute CreateStyleCopSuppression(
        int checkId,
        string? justification)
    {
        if (string.IsNullOrEmpty(justification))
        {
            justification = "OK.";
        }

        return checkId switch
        {
            // TODO: Add all rules
            1413 => new SuppressMessageAttribute("Maintainability Rules", "SA1413:Use trailing comma in multi-line initializers") { Justification = justification },
            _ => throw new NotImplementedException($"Rule for SA{checkId} must be implemented."),
        };
    }
}