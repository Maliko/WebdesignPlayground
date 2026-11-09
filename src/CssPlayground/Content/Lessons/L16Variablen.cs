namespace CssPlayground.Content.Lessons;

public static class L16Variablen
{
    public static Lesson Create() => new()
    {
        Number = 16,
        Id = "variablen",
        Title = "CSS-Variablen",
        Summary = "Farben und Werte zentral verwalten mit Custom Properties – und dein Projekt abschließen.",
        Goals =
        [
            "Custom Properties definieren und mit var() verwenden",
            "Variablen auf :root für das ganze Dokument festlegen",
            "Fallback-Werte angeben",
            "Variablen lokal überschreiben, z. B. für Themes",
        ],
        Sections =
        [
            new()
            {
                Title = "Variablen definieren und verwenden",
                Body = """
                    <p>Wenn eine Farbe an zwanzig Stellen im CSS steht und sich ändern soll, wird es mühsam. <strong>CSS-Variablen</strong> (offiziell <em>Custom Properties</em>) lösen das:</p>
                    <pre><code>:root {
                      --farbe-primaer: #2a9d8f;
                    }

                    .button {
                      background-color: var(--farbe-primaer);
                    }</code></pre>
                    <ul>
                      <li>Variablennamen beginnen mit zwei Bindestrichen: <code>--name</code>.</li>
                      <li><code>:root</code> steht für das <code>&lt;html&gt;</code>-Element – dort definierte Variablen gelten überall.</li>
                      <li>Mit <code>var(--name)</code> wird der Wert eingesetzt. Ein Fallback ist möglich: <code>var(--name, gray)</code>.</li>
                    </ul>
                    <p>Ändere im Beispiel nur den Wert von <code>--akzent</code> – alle Elemente ziehen mit!</p>
                    """,
                Example = new()
                {
                    Html = """
                        <h2>Variablen sind praktisch</h2>
                        <p>Ein <a href="#">Link</a> in der Akzentfarbe.</p>
                        <button>Ein Button</button>
                        """,
                    Css = """
                        :root {
                          --akzent: #e76f51;
                          --abstand: 12px;
                        }

                        h2 {
                          color: var(--akzent);
                          border-bottom: 3px solid var(--akzent);
                          padding-bottom: var(--abstand);
                        }

                        a {
                          color: var(--akzent);
                        }

                        button {
                          background-color: var(--akzent);
                          color: white;
                          border: none;
                          padding: var(--abstand) calc(var(--abstand) * 2);
                        }
                        """,
                    PreviewHeight = 200,
                },
            },
            new()
            {
                Title = "Variablen überschreiben",
                Body = """
                    <p>Variablen werden wie andere Eigenschaften <strong>vererbt</strong> und können auf jedem Element neu gesetzt werden.
                    Das macht Varianten und Themes (z.&nbsp;B. einen Dunkelmodus) sehr einfach:</p>
                    <p>Im Beispiel setzt <code>.dunkel</code> nur die Variablen neu – die Regeln für <code>.box</code> bleiben unverändert.</p>
                    <p>Mit <code>calc()</code> kannst du außerdem mit Variablen rechnen: <code>calc(var(--abstand) * 2)</code>.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="box">Helles Theme</div>
                        <div class="box dunkel">Dunkles Theme</div>
                        """,
                    Css = """
                        .box {
                          --hintergrund: white;
                          --text: #222;
                          background-color: var(--hintergrund);
                          color: var(--text);
                          border: 1px solid #ccc;
                          padding: 20px;
                          margin-bottom: 10px;
                        }

                        .dunkel {
                          --hintergrund: #222;
                          --text: #f5f5f5;
                        }
                        """,
                    PreviewHeight = 160,
                },
            },
        ],
        Exercises =
        [
            new()
            {
                Id = "l16-e1",
                Title = "Farben zentralisieren",
                Task = """
                    <p>Die Farbe <code>#6a4c93</code> steht dreimal im CSS. Definiere auf <code>:root</code> eine Variable <code>--marke</code> mit diesem Wert und ersetze alle drei Vorkommen durch <code>var(--marke)</code>.</p>
                    <p>Teste anschließend: Wenn du nur den Wert der Variable änderst, sollten sich alle drei Stellen ändern.</p>
                    """,
                Html = """
                    <h1>Lila Laune</h1>
                    <p>Hier gibt es <a href="#">gute Stimmung</a>.</p>
                    <button>Mitmachen</button>
                    """,
                StarterCss = """
                    h1 {
                      color: #6a4c93;
                    }

                    a {
                      color: #6a4c93;
                    }

                    button {
                      background-color: #6a4c93;
                      color: white;
                      border: none;
                      padding: 10px 20px;
                    }
                    """,
                SolutionCss = """
                    :root {
                      --marke: #6a4c93;
                    }

                    h1 {
                      color: var(--marke);
                    }

                    a {
                      color: var(--marke);
                    }

                    button {
                      background-color: var(--marke);
                      color: white;
                      border: none;
                      padding: 10px 20px;
                    }
                    """,
                Checks =
                [
                    Check.Js("--marke ist auf :root definiert.", "return h.rootVars().includes('--marke') || 'Definiere --marke in einer :root-Regel.';"),
                    Check.Js("Der Hex-Wert steht nur noch einmal im CSS.", "const n = (h.css().match(/#6a4c93/gi) || []).length; return n === 1 || `#6a4c93 kommt noch ${n}-mal vor.`;"),
                    Check.Js("Mindestens drei Stellen verwenden var(--marke).", "const n = (h.css().match(/var\\(\\s*--marke/g) || []).length; return n >= 3 || `var(--marke) wird erst ${n}-mal verwendet.`;"),
                    Check.Style("Die Überschrift hat weiterhin die Markenfarbe.", "h1", "color", "#6a4c93"),
                    Check.Style("Der Button hat weiterhin die Markenfarbe.", "button", "background-color", "#6a4c93"),
                ],
                PreviewHeight = 180,
            },
        ],
        Project = new()
        {
            Id = "l16-projekt",
            Task = """
                <p>Zum Abschluss räumst du das CSS des Cafés auf. Die Farben stehen bisher an vielen Stellen als Hex-Code.</p>
                <ol>
                  <li>Lege auf <code>:root</code> diese Variablen an:
                    <ul>
                      <li><code>--farbe-dunkel: #3b2a20</code></li>
                      <li><code>--farbe-akzent: #a0522d</code></li>
                      <li><code>--farbe-hell: #fffaf3</code></li>
                    </ul>
                  </li>
                  <li>Ersetze die Hex-Codes dieser drei Farben im übrigen CSS durch <code>var(…)</code>. Es dürfen höchstens noch je ein Vorkommen (in der Definition) übrig bleiben.</li>
                </ol>
                <p>Probiere danach aus, was passiert, wenn du <code>--farbe-akzent</code> z.&nbsp;B. auf <code>#2a9d8f</code> änderst. Herzlichen Glückwunsch – deine Café-Webseite ist fertig! 🎉</p>
                """,
            AddedCss = """
                :root {
                  --farbe-dunkel: #3b2a20;
                  --farbe-akzent: #a0522d;
                  --farbe-hell: #fffaf3;
                }
                """,
            RewritePrevious = css => css
                .Replace("#3b2a20", "var(--farbe-dunkel)")
                .Replace("#a0522d", "var(--farbe-akzent)")
                .Replace("#fffaf3", "var(--farbe-hell)"),
            Hint = "Suche im Editor nach #3b2a20, #a0522d und #fffaf3 (Strg+F im Browser hilft) und ersetze sie z. B. durch var(--farbe-dunkel).",
            Checks =
            [
                Check.Js("Variablen auf :root definiert",
                    "const v = h.rootVars(); const missing = ['--farbe-dunkel', '--farbe-akzent', '--farbe-hell'].filter(n => !v.includes(n)); return missing.length === 0 || 'Es fehlen: ' + missing.join(', ');"),
                Check.Js("Variablen haben die richtigen Werte",
                    "const s = win.getComputedStyle(doc.documentElement); const ok = [['--farbe-dunkel', '#3b2a20'], ['--farbe-akzent', '#a0522d'], ['--farbe-hell', '#fffaf3']].every(([n, v]) => s.getPropertyValue(n).trim().toLowerCase() === v); return ok || 'Mindestens eine Variable hat nicht den vorgegebenen Wert.';"),
                Check.Js("Hex-Codes durch Variablen ersetzt",
                    "const css = h.css().replace(/\\/\\*[\\s\\S]*?\\*\\//g, ''); const rest = ['#3b2a20', '#a0522d', '#fffaf3'].filter(c => (css.match(new RegExp(c, 'gi')) || []).length > 1); return rest.length === 0 || 'Diese Farben stehen noch mehrfach im CSS: ' + rest.join(', ');"),
                Check.Js("Variablen werden verwendet",
                    "const n = (h.css().match(/var\\(\\s*--farbe-/g) || []).length; return n >= 6 || `Erst ${n} Verwendungen von var(--farbe-…) gefunden – ersetze alle Vorkommen.`;"),
                Check.Style("Header nutzt weiterhin das dunkle Braun", ".site-header", "background-color", "#3b2a20"),
                Check.Style("Button nutzt weiterhin die Akzentfarbe", ".hero .button", "background-color", "#a0522d"),
            ],
        },
    };
}
