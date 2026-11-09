namespace CssPlayground.Content;

/// <summary>Eine Lektion des Kurses.</summary>
public sealed class Lesson
{
    public required int Number { get; init; }
    public required string Id { get; init; }
    public required string Title { get; init; }

    /// <summary>Kurzbeschreibung für Übersicht und Seitenleiste.</summary>
    public required string Summary { get; init; }

    /// <summary>Lernziele der Lektion (Aufzählung).</summary>
    public IReadOnlyList<string> Goals { get; init; } = [];

    public required IReadOnlyList<LessonSection> Sections { get; init; }
    public IReadOnlyList<Exercise> Exercises { get; init; } = [];

    /// <summary>Schritt am gemeinsamen Café-Projekt, das über alle Lektionen wächst.</summary>
    public ProjectStep? Project { get; init; }

    public string Url => $"lektion/{Id}";
}

/// <summary>Ein Theorie-Abschnitt mit optionalem, editierbarem Beispiel.</summary>
public sealed class LessonSection
{
    public required string Title { get; init; }

    /// <summary>Erklärtext als HTML (vom Kursautor, daher vertrauenswürdig).</summary>
    public required string Body { get; init; }

    public Example? Example { get; init; }
}

/// <summary>Ein interaktives Beispiel: HTML und CSS sind frei editierbar.</summary>
public sealed class Example
{
    public required string Html { get; init; }
    public required string Css { get; init; }
    public int PreviewHeight { get; init; } = 220;
}

/// <summary>Eine Übung mit automatischer Prüfung.</summary>
public sealed class Exercise
{
    public required string Id { get; init; }
    public required string Title { get; init; }

    /// <summary>Aufgabenstellung als HTML.</summary>
    public required string Task { get; init; }

    public required string Html { get; init; }
    public string StarterCss { get; init; } = "";
    public required string SolutionCss { get; init; }
    public string? Hint { get; init; }
    public required IReadOnlyList<Check> Checks { get; init; }
    public int PreviewHeight { get; init; } = 240;
}

/// <summary>Ein Schritt am Café-Projekt. Das CSS baut auf dem vorherigen Schritt auf.</summary>
public sealed class ProjectStep
{
    public required string Id { get; init; }
    public required string Task { get; init; }

    /// <summary>CSS, das die Musterlösung in diesem Schritt hinzufügt.</summary>
    public required string AddedCss { get; init; }

    public string? Hint { get; init; }
    public required IReadOnlyList<Check> Checks { get; init; }

    /// <summary>
    /// Optional: Schreibt die Musterlösung der vorherigen Schritte um (z.&#160;B. Hex-Codes durch
    /// Variablen ersetzen). Ist sie gesetzt, wird <see cref="AddedCss"/> vorangestellt statt angehängt.
    /// </summary>
    public Func<string, string>? RewritePrevious { get; init; }
}
