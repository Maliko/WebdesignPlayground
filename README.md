# 🎨 CSS-Werkstatt

Ein interaktives Tutorial, mit dem man **CSS von Grund auf** lernt – direkt im Browser, mit Live-Vorschau und automatisch geprüften Übungen.
Grundkenntnisse in HTML werden vorausgesetzt.

Geschrieben in **C# mit ASP.NET Core / Blazor (.NET 8)**.

## Was die App bietet

- **16 aufeinander aufbauende Lektionen** – von „Was ist CSS?“ über Box-Modell, Flexbox und Grid bis zu Animationen, Responsive Design und CSS-Variablen.
- **Interaktive Beispiele** in jeder Lektion: HTML und CSS sind editierbar, die Vorschau aktualisiert sich beim Tippen.
- **Übungen mit automatischer Prüfung**: Die App prüft die *tatsächlich berechneten* Stile im Browser
  (`red`, `#f00` und `rgb(255 0 0)` gelten also gleichermaßen als richtig) und erklärt, was noch fehlt.
  Dazu gibt es Tipps und auf Wunsch die Lösung.
- **Durchgehendes Projekt „Café Kaffeebohne“**: In jeder Lektion gestaltest du ein weiteres Stück derselben Webseite.
  Dein CSS wird in den nächsten Schritt übernommen – am Ende steht eine komplette, responsive Webseite,
  die du als HTML-Datei herunterladen kannst.
- **Fortschritt** und eigener Code werden lokal im Browser (localStorage) gespeichert – kein Konto, keine Datenbank.
- **Spielwiese** zum freien Experimentieren und eine **Projektansicht** mit Desktop-/Tablet-/Smartphone-Vorschau.

### Lektionen

| Nr. | Thema | Projektschritt im Café |
|----:|-------|------------------------|
| 1 | Was ist CSS? (Syntax, Einbinden, Kommentare) | erste Regeln für `body` und `h1` |
| 2 | Selektoren (Typ, Klasse, ID, Gruppen, Nachfahren) | Preise, Navigation, Überschriften |
| 3 | Farben (Namen, Hex, rgb, hsl, Transparenz) | Farbkonzept |
| 4 | Text und Schrift | Typografie |
| 5 | Maßeinheiten (px, rem, em, %, vw/vh) | Container-Breite, rem-Größen |
| 6 | Box-Modell | Abstände, Karten, Zentrierung |
| 7 | Block, Inline und `display` | Navigation, Button, Formular |
| 8 | Kaskade, Spezifität, Vererbung | hervorgehobene Karte, `font: inherit` |
| 9 | Flexbox | Kopfzeilen-Layout |
| 10 | CSS Grid | Kartenraster der Speisekarte |
| 11 | Positionierung | Sticky Header, Badge |
| 12 | Pseudoklassen und -elemente | Hover, Fokus, Zebrastreifen, Deko-Linie |
| 13 | Hintergründe, Ecken, Schatten | Verlauf, Rundungen, Schatten |
| 14 | Transformationen, Übergänge, Animationen | Hover-Effekte, Einblend-Animation |
| 15 | Responsive Design | Media Query fürs Smartphone |
| 16 | CSS-Variablen | Farben zentralisieren |

## Starten

Voraussetzung: [.NET 8 SDK](https://dotnet.microsoft.com/download)

```bash
dotnet run --project src/CssPlayground
```

Danach im Browser <http://localhost:5206> öffnen.

Tests ausführen:

```bash
dotnet test
```

Zusätzlich gibt es in der App die Seite **`/selbsttest`**: Sie prüft im Browser für jede Übung und jeden Projektschritt,
dass die Musterlösung alle Prüfungen besteht und der Ausgangszustand nicht. Das ist hilfreich, wenn man Lektionen ändert oder ergänzt.

## Aufbau

```
src/CssPlayground/
├── Content/                 Kursinhalte (reines C#, keine Datenbank)
│   ├── Models.cs            Lesson, LessonSection, Example, Exercise, ProjectStep
│   ├── Check.cs             Prüfungen (berechnete Stile oder eigenes JavaScript)
│   ├── CafeProject.cs       HTML der Café-Webseite
│   ├── LessonCatalog.cs     Reihenfolge, Projekt-Musterlösungen
│   └── Lessons/L01…L16      die einzelnen Lektionen
├── Services/ProgressService.cs   Fortschritt (localStorage über JS-Interop)
├── Components/
│   ├── Shared/CodePlayground.razor   Editor + Vorschau + Prüfung
│   ├── Pages/                        Startseite, Lektion, Projekt, Spielwiese, Selbsttest
│   └── Layout/MainLayout.razor       Seitenleiste mit Fortschritt
└── wwwroot/
    ├── js/playground.js     Editor-Komfort, Live-Vorschau (iframe), Prüf-Engine
    └── app.css
tests/CssPlayground.Tests/   xUnit-Tests für die Konsistenz der Kursinhalte
```

### Eine Lektion ergänzen

1. Neue Datei unter `Content/Lessons/` nach dem Muster der vorhandenen anlegen.
2. In `LessonCatalog` in die Liste eintragen.
3. Prüfungen mit `Check.Style(...)`, `Check.Contains(...)`, `Check.AtLeast(...)` oder `Check.Js(...)` formulieren.
   In `Check.Js` stehen `doc`, `win` und Helfer `h` zur Verfügung (`h.cs`, `h.rect`, `h.findRules`, `h.ruleValue`, `h.keyframes`, `h.rootVars`, `h.css` …, siehe `playground.js`).
4. `dotnet test` und `/selbsttest` ausführen.

## Technische Hinweise

- Blazor Server mit interaktivem Rendering (ohne Prerendering, damit JS-Interop sofort verfügbar ist).
- Die Editoren werden im Browser verwaltet: Tippen aktualisiert die Vorschau ohne Server-Roundtrip.
- Die Vorschau läuft in einem `iframe` mit `sandbox="allow-same-origin"` – Skripte im HTML der Lernenden werden nicht ausgeführt.
