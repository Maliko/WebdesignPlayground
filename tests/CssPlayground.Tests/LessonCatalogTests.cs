using System.Text.RegularExpressions;
using CssPlayground.Content;

namespace CssPlayground.Tests;

public class LessonCatalogTests
{
    private static readonly string[] Modes = ["eq", "neq", "contains", "gte", "lte", "js"];
    private readonly LessonCatalog catalog = new();

    public static IEnumerable<object[]> AllLessons() => new LessonCatalog().Lessons.Select(l => new object[] { l.Id });

    [Fact]
    public void Lessons_are_numbered_consecutively()
    {
        Assert.Equal(Enumerable.Range(1, catalog.Lessons.Count), catalog.Lessons.Select(l => l.Number));
    }

    [Fact]
    public void Lesson_ids_are_unique_and_url_friendly()
    {
        var ids = catalog.Lessons.Select(l => l.Id).ToList();
        Assert.Equal(ids.Count, ids.Distinct().Count());
        Assert.All(ids, id => Assert.Matches("^[a-z0-9-]+$", id));
    }

    [Fact]
    public void Task_ids_are_unique_across_the_course()
    {
        var ids = catalog.Lessons.SelectMany(LessonCatalog.TaskIds).ToList();
        Assert.Equal(ids.Count, ids.Distinct().Count());
        Assert.Equal(catalog.TotalTasks, ids.Count);
    }

    [Fact]
    public void Every_lesson_contributes_a_project_step()
    {
        Assert.All(catalog.Lessons, l => Assert.NotNull(l.Project));
    }

    [Theory]
    [MemberData(nameof(AllLessons))]
    public void Lesson_content_is_complete(string id)
    {
        var lesson = catalog.Find(id)!;
        Assert.False(string.IsNullOrWhiteSpace(lesson.Title));
        Assert.False(string.IsNullOrWhiteSpace(lesson.Summary));
        Assert.NotEmpty(lesson.Goals);
        Assert.NotEmpty(lesson.Sections);
        Assert.All(lesson.Sections, s =>
        {
            Assert.False(string.IsNullOrWhiteSpace(s.Title));
            Assert.False(string.IsNullOrWhiteSpace(s.Body));
        });
        Assert.All(lesson.Exercises, e =>
        {
            Assert.False(string.IsNullOrWhiteSpace(e.Html));
            Assert.False(string.IsNullOrWhiteSpace(e.SolutionCss));
            Assert.NotEqual(e.StarterCss.Trim(), e.SolutionCss.Trim());
            Assert.NotEmpty(e.Checks);
        });
    }

    [Theory]
    [MemberData(nameof(AllLessons))]
    public void Checks_are_well_formed(string id)
    {
        var lesson = catalog.Find(id)!;
        var checks = lesson.Exercises.SelectMany(e => e.Checks).Concat(lesson.Project?.Checks ?? []);
        Assert.All(checks, c =>
        {
            Assert.Contains(c.Mode, Modes);
            Assert.False(string.IsNullOrWhiteSpace(c.Description));
            if (c.Mode == "js")
            {
                Assert.False(string.IsNullOrWhiteSpace(c.Script));
                Assert.Contains("return", c.Script);
            }
            else
            {
                Assert.False(string.IsNullOrWhiteSpace(c.Selector));
                Assert.False(string.IsNullOrWhiteSpace(c.Property));
                Assert.NotNull(c.Expected);
            }
        });
    }

    [Theory]
    [MemberData(nameof(AllLessons))]
    public void Css_has_balanced_braces(string id)
    {
        var lesson = catalog.Find(id)!;
        var sources = lesson.Sections.Where(s => s.Example is not null).Select(s => s.Example!.Css)
            .Concat(lesson.Exercises.Select(e => e.SolutionCss))
            .Append(lesson.Project!.AddedCss);
        Assert.All(sources, css => Assert.Equal(css.Count(ch => ch == '{'), css.Count(ch => ch == '}')));
    }

    [Fact]
    public void Project_reference_builds_up_cumulatively()
    {
        var first = catalog.Lessons[0];
        var second = catalog.Lessons[1];
        Assert.Equal("", catalog.ReferenceCssBefore(first));
        Assert.Equal(catalog.ReferenceCssThrough(first), catalog.ReferenceCssBefore(second));
        Assert.Contains(second.Project!.AddedCss.Trim(), catalog.ReferenceCssThrough(second));
    }

    [Fact]
    public void Final_reference_uses_variables_instead_of_repeated_colors()
    {
        var css = catalog.ReferenceCssThrough(catalog.Lessons[^1]);
        foreach (var color in new[] { "#3b2a20", "#a0522d", "#fffaf3" })
        {
            Assert.Single(Regex.Matches(css, Regex.Escape(color), RegexOptions.IgnoreCase));
        }
        Assert.Contains("var(--farbe-akzent)", css);
    }

    [Fact]
    public void Project_html_contains_all_classes_used_by_project_checks()
    {
        var classes = catalog.Lessons
            .SelectMany(l => l.Project!.Checks)
            .Where(c => c.Selector is not null)
            .SelectMany(c => Regex.Matches(c.Selector!, @"\.([a-z][a-z0-9-]*)").Select(m => m.Groups[1].Value))
            .Distinct();
        Assert.All(classes, cls => Assert.Matches($"class=\"[^\"]*\\b{Regex.Escape(cls)}\\b", CafeProject.Html));
    }
}
