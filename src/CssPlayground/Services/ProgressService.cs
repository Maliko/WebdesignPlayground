using System.Text.Json;
using CssPlayground.Content;
using Microsoft.JSInterop;

namespace CssPlayground.Services;

/// <summary>
/// Hält den Lernfortschritt (erledigte Übungen) im localStorage des Browsers.
/// Der Code selbst wird als Entwurf direkt vom JavaScript-Modul gespeichert.
/// </summary>
public sealed class ProgressService(IJSRuntime js, LessonCatalog catalog) : IAsyncDisposable
{
    private IJSObjectReference? _module;
    private readonly HashSet<string> _completed = new(StringComparer.Ordinal);
    private bool _loaded;

    public event Action? Changed;

    public async Task<IJSObjectReference> GetModuleAsync()
    {
        _module ??= await js.InvokeAsync<IJSObjectReference>("import", "./js/playground.js");
        return _module;
    }

    public async Task EnsureLoadedAsync()
    {
        if (_loaded) return;
        var module = await GetModuleAsync();
        var json = await module.InvokeAsync<string?>("loadProgress");
        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                var data = JsonSerializer.Deserialize<ProgressData>(json);
                if (data?.Completed is not null) _completed.UnionWith(data.Completed);
            }
            catch (JsonException)
            {
                // Beschädigte Daten ignorieren – der Lernende startet dann neu.
            }
        }
        _loaded = true;
        Changed?.Invoke();
    }

    public bool IsCompleted(string taskId) => _completed.Contains(taskId);

    public async Task MarkCompletedAsync(string taskId)
    {
        if (!_completed.Add(taskId)) return;
        await SaveAsync();
        Changed?.Invoke();
    }

    public int CompletedCount(Lesson lesson) => LessonCatalog.TaskIds(lesson).Count(IsCompleted);

    public int TotalCompleted => catalog.Lessons.Sum(CompletedCount);

    public bool IsLessonCompleted(Lesson lesson) => CompletedCount(lesson) == LessonCatalog.TaskIds(lesson).Count;

    /// <summary>Liefert das gespeicherte Projekt-CSS eines Schritts, falls vorhanden.</summary>
    public async Task<string?> GetProjectDraftAsync(ProjectStep step)
    {
        var module = await GetModuleAsync();
        var draft = await module.InvokeAsync<DraftData?>("getDraft", step.Id);
        return draft?.Css;
    }

    /// <summary>
    /// Ausgangs-CSS für einen Projektschritt: der eigene Stand aus dem vorherigen Schritt,
    /// sonst die Musterlösung bis dorthin.
    /// </summary>
    public async Task<string> GetProjectStarterAsync(Lesson lesson)
    {
        var previous = catalog.PreviousProjectStep(lesson);
        if (previous is null) return "";
        var own = await GetProjectDraftAsync(previous);
        return own ?? catalog.ReferenceCssBefore(lesson);
    }

    public async Task ResetAllAsync()
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("resetAll");
        _completed.Clear();
        Changed?.Invoke();
    }

    private async Task SaveAsync()
    {
        var module = await GetModuleAsync();
        var json = JsonSerializer.Serialize(new ProgressData { Completed = [.. _completed.Order()] });
        await module.InvokeVoidAsync("saveProgress", json);
    }

    public async ValueTask DisposeAsync()
    {
        if (_module is not null)
        {
            try { await _module.DisposeAsync(); }
            catch (JSDisconnectedException) { }
        }
    }

    private sealed class ProgressData
    {
        public List<string>? Completed { get; set; }
    }

    public sealed class DraftData
    {
        public string? Html { get; set; }
        public string? Css { get; set; }
    }
}
