using CssPlayground.Content.Lessons;

namespace CssPlayground.Content;

/// <summary>Alle Lektionen des Kurses in ihrer Reihenfolge.</summary>
public sealed class LessonCatalog
{
    public IReadOnlyList<Lesson> Lessons { get; }

    public LessonCatalog()
    {
        Lessons =
        [
            L01Einfuehrung.Create(),
            L02Selektoren.Create(),
            L03Farben.Create(),
            L04Text.Create(),
            L05Einheiten.Create(),
            L06Boxmodell.Create(),
            L07Display.Create(),
            L08Kaskade.Create(),
            L09Flexbox.Create(),
            L10Grid.Create(),
            L11Positionierung.Create(),
            L12Pseudoklassen.Create(),
            L13Effekte.Create(),
            L14Animationen.Create(),
            L15Responsive.Create(),
            L16Variablen.Create(),
        ];
    }

    public Lesson? Find(string id) => Lessons.FirstOrDefault(l => l.Id == id);

    public Lesson? Next(Lesson lesson) => Lessons.SkipWhile(l => l != lesson).Skip(1).FirstOrDefault();

    public Lesson? Previous(Lesson lesson) => Lessons.TakeWhile(l => l != lesson).LastOrDefault();

    /// <summary>IDs aller prüfbaren Aufgaben einer Lektion (Übungen + Projektschritt).</summary>
    public static IReadOnlyList<string> TaskIds(Lesson lesson)
    {
        var ids = lesson.Exercises.Select(e => e.Id).ToList();
        if (lesson.Project is not null) ids.Add(lesson.Project.Id);
        return ids;
    }

    public int TotalTasks => Lessons.Sum(l => TaskIds(l).Count);

    public ProjectStep? PreviousProjectStep(Lesson lesson) =>
        Lessons.TakeWhile(l => l != lesson).Select(l => l.Project).LastOrDefault(p => p is not null);

    /// <summary>Musterlösung des Projekts vor dieser Lektion (alle vorherigen Schritte).</summary>
    public string ReferenceCssBefore(Lesson lesson) =>
        JoinCss(Lessons.TakeWhile(l => l != lesson).Select(l => l.Project));

    /// <summary>Musterlösung des Projekts einschließlich dieser Lektion.</summary>
    public string ReferenceCssThrough(Lesson lesson) =>
        JoinCss(Lessons.TakeWhile(l => l != lesson).Append(lesson).Select(l => l.Project));

    public ProjectStep LastProjectStep => Lessons.Last(l => l.Project is not null).Project!;

    private static string JoinCss(IEnumerable<ProjectStep?> steps)
    {
        var css = "";
        foreach (var step in steps)
        {
            if (step is null) continue;
            var added = step.AddedCss.Trim() + "\n";
            if (step.RewritePrevious is not null)
                css = added + (css.Length > 0 ? "\n" + step.RewritePrevious(css) : "");
            else
                css = css.Length > 0 ? css + "\n" + added : added;
        }
        return css;
    }
}
