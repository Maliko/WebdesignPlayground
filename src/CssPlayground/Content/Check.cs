namespace CssPlayground.Content;

/// <summary>
/// Eine automatische Prüfung, die im Browser gegen die gerenderte Vorschau ausgeführt wird.
/// Stil-Prüfungen vergleichen berechnete Werte (getComputedStyle). Der erwartete Wert wird
/// dabei vom Browser normalisiert, so dass z.&#160;B. <c>red</c>, <c>#f00</c> und
/// <c>rgb(255, 0, 0)</c> gleichwertig sind.
/// </summary>
public sealed record Check
{
    public required string Description { get; init; }
    public string? Selector { get; init; }
    public string? Property { get; init; }
    public string? Expected { get; init; }
    public string? Pseudo { get; init; }

    /// <summary>eq, neq, contains, gte, lte oder js.</summary>
    public string Mode { get; init; } = "eq";

    /// <summary>
    /// JavaScript-Funktionsrumpf für Mode "js". Verfügbar sind <c>doc</c>, <c>win</c> und
    /// Helfer <c>h</c> (siehe playground.js). Rückgabe: true/false oder eine Fehlermeldung.
    /// </summary>
    public string? Script { get; init; }

    public static Check Style(string description, string selector, string property, string expected, string? pseudo = null) =>
        new() { Description = description, Selector = selector, Property = property, Expected = expected, Pseudo = pseudo, Mode = "eq" };

    public static Check NotStyle(string description, string selector, string property, string notExpected, string? pseudo = null) =>
        new() { Description = description, Selector = selector, Property = property, Expected = notExpected, Pseudo = pseudo, Mode = "neq" };

    public static Check Contains(string description, string selector, string property, string part, string? pseudo = null) =>
        new() { Description = description, Selector = selector, Property = property, Expected = part, Pseudo = pseudo, Mode = "contains" };

    public static Check AtLeast(string description, string selector, string property, string min, string? pseudo = null) =>
        new() { Description = description, Selector = selector, Property = property, Expected = min, Pseudo = pseudo, Mode = "gte" };

    public static Check AtMost(string description, string selector, string property, string max, string? pseudo = null) =>
        new() { Description = description, Selector = selector, Property = property, Expected = max, Pseudo = pseudo, Mode = "lte" };

    public static Check Js(string description, string script) =>
        new() { Description = description, Script = script, Mode = "js" };
}
