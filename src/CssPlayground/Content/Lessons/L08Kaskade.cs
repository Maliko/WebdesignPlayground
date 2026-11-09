namespace CssPlayground.Content.Lessons;

public static class L08Kaskade
{
    public static Lesson Create() => new()
    {
        Number = 8,
        Id = "kaskade",
        Title = "Kaskade, Spezifität und Vererbung",
        Summary = "Welche Regel gewinnt, wenn sich mehrere widersprechen? Und was erben Kinder von ihren Eltern?",
        Goals =
        [
            "Die Reihenfolge der Regeln als Entscheidungskriterium kennen",
            "Spezifität von Selektoren einschätzen",
            "Verstehen, welche Eigenschaften vererbt werden",
            "inherit gezielt einsetzen und !important vermeiden",
        ],
        Sections =
        [
            new()
            {
                Title = "Die Kaskade: Die letzte Regel gewinnt …",
                Body = """
                    <p>Das „C“ in CSS steht für <em>Cascading</em>. Gelten mehrere Regeln für dasselbe Element und dieselbe Eigenschaft, muss der Browser entscheiden.
                    Bei <strong>gleich spezifischen</strong> Selektoren gewinnt die Regel, die <strong>weiter unten</strong> steht.</p>
                    <p>Im Beispiel ist der Absatz grün. Vertausche die beiden Regeln – was passiert?</p>
                    """,
                Example = new()
                {
                    Html = """
                        <p>Welche Farbe habe ich?</p>
                        """,
                    Css = """
                        p {
                          color: crimson;
                        }

                        p {
                          color: green;
                        }
                        """,
                    PreviewHeight = 100,
                },
            },
            new()
            {
                Title = "… außer, eine Regel ist spezifischer",
                Body = """
                    <p>Spezifischere Selektoren gewinnen – egal, wo sie stehen. Die Spezifität wird grob so gezählt (wie eine dreistellige Zahl):</p>
                    <table class="spec-table">
                      <tr><th>Selektor-Bestandteil</th><th>Gewicht</th></tr>
                      <tr><td>ID (<code>#nav</code>)</td><td>1-0-0</td></tr>
                      <tr><td>Klasse, Attribut, Pseudoklasse (<code>.aktiv</code>, <code>:hover</code>)</td><td>0-1-0</td></tr>
                      <tr><td>Element, Pseudoelement (<code>p</code>, <code>::before</code>)</td><td>0-0-1</td></tr>
                    </table>
                    <p>Beispiele: <code>p</code> = 0-0-1, <code>.text</code> = 0-1-0, <code>p.text</code> = 0-1-1, <code>#inhalt p</code> = 1-0-1.</p>
                    <p>Das <code>style</code>-Attribut im HTML schlägt alle Selektoren, und <code>!important</code> hinter einem Wert schlägt sogar das.</p>
                    <div class="tip"><strong>Gute Praxis:</strong> Halte die Spezifität niedrig und arbeite vor allem mit Klassen. <code>!important</code> ist ein Notausgang, kein Werkzeug – wer es oft braucht, hat meist ein Spezifitätsproblem.</div>
                    """,
                Example = new()
                {
                    Html = """
                        <div id="inhalt">
                          <p class="text">Welche Farbe gewinnt?</p>
                        </div>
                        """,
                    Css = """
                        #inhalt p {
                          color: purple;   /* 1-0-1 */
                        }

                        p.text {
                          color: orange;   /* 0-1-1 */
                        }

                        p {
                          color: blue;     /* 0-0-1 */
                        }
                        """,
                    PreviewHeight = 100,
                },
            },
            new()
            {
                Title = "Vererbung",
                Body = """
                    <p>Manche Eigenschaften werden an Kindelemente <strong>vererbt</strong>. Setzt du <code>color</code> oder <code>font-family</code> auf dem <code>body</code>,
                    übernehmen alle Elemente darin diese Werte – deshalb musst du die Schrift nicht für jeden Absatz einzeln angeben.</p>
                    <ul>
                      <li><strong>Vererbt</strong> werden vor allem Text-Eigenschaften: <code>color</code>, <code>font-*</code>, <code>line-height</code>, <code>text-align</code>, <code>letter-spacing</code> …</li>
                      <li><strong>Nicht vererbt</strong> werden Box-Eigenschaften: <code>padding</code>, <code>margin</code>, <code>border</code>, <code>background</code>, <code>width</code> …</li>
                    </ul>
                    <p>Mit dem Wert <code>inherit</code> erzwingst du die Vererbung. Formularelemente wie <code>input</code> und <code>button</code> erben z.&nbsp;B. die Schrift <em>nicht</em> –
                    mit <code>font: inherit;</code> bekommen sie die Schrift der Seite.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="eltern">
                          <p>Ich erbe Farbe und Schrift, aber keinen Rahmen.</p>
                          <button>Button ohne inherit</button>
                          <button class="erbt">Button mit inherit</button>
                        </div>
                        """,
                    Css = """
                        .eltern {
                          color: darkmagenta;
                          font-family: Georgia, serif;
                          font-size: 18px;
                          border: 2px solid darkmagenta;
                          padding: 10px;
                        }

                        .erbt {
                          font: inherit;
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
                Id = "l08-e1",
                Title = "Spezifität überlisten – ohne !important",
                Task = """
                    <p>Der Button mit der zusätzlichen Klasse <code>gefahr</code> soll einen roten Hintergrund (<code>crimson</code>) bekommen.
                    Die vorhandene Regel <code>.toolbar .btn</code> ist aber spezifischer als ein einfaches <code>.gefahr</code>.</p>
                    <p>Schreibe einen Selektor, der spezifisch genug ist – <strong>ohne</strong> <code>!important</code> und ohne die bestehende Regel zu ändern.</p>
                    """,
                Html = """
                    <div class="toolbar">
                      <button class="btn">Speichern</button>
                      <button class="btn gefahr">Löschen</button>
                    </div>
                    """,
                StarterCss = """
                    .toolbar .btn {
                      background-color: steelblue;
                      color: white;
                      border: none;
                      padding: 8px 16px;
                    }

                    .gefahr {
                      background-color: crimson;
                    }
                    """,
                SolutionCss = """
                    .toolbar .btn {
                      background-color: steelblue;
                      color: white;
                      border: none;
                      padding: 8px 16px;
                    }

                    .toolbar .btn.gefahr {
                      background-color: crimson;
                    }
                    """,
                Hint = "Zwei Klassen ohne Leerzeichen hintereinander (.btn.gefahr) treffen Elemente, die beide Klassen haben. Kombiniere das mit .toolbar.",
                Checks =
                [
                    Check.Style("Der Löschen-Button ist crimson.", ".gefahr", "background-color", "crimson"),
                    Check.Style("Der Speichern-Button bleibt steelblue.", ".btn:not(.gefahr)", "background-color", "steelblue"),
                    Check.Js("Kein !important verwendet.", "return !/!\\s*important/i.test(h.css()) || 'Bitte ohne !important lösen.';"),
                ],
                PreviewHeight = 100,
            },
            new()
            {
                Id = "l08-e2",
                Title = "Vererbung nutzen",
                Task = """
                    <p>Setze Schrift (<code>Verdana, sans-serif</code>) und Textfarbe (<code>#333</code>) nur <strong>einmal</strong> auf dem <code>body</code> – alle Elemente sollen sie erben.
                    Das Eingabefeld und der Button erben die Schrift von sich aus nicht: Sorge mit <code>font: inherit</code> dafür, dass auch sie Verdana nutzen.</p>
                    """,
                Html = """
                    <h2>Newsletter</h2>
                    <p>Trag dich ein und verpasse nichts.</p>
                    <input type="email" placeholder="E-Mail-Adresse">
                    <button>Anmelden</button>
                    """,
                SolutionCss = """
                    body {
                      font-family: Verdana, sans-serif;
                      color: #333;
                    }

                    input,
                    button {
                      font: inherit;
                    }
                    """,
                Checks =
                [
                    Check.Contains("Überschrift erbt Verdana.", "h2", "font-family", "verdana"),
                    Check.Style("Absatz erbt die Farbe #333.", "p", "color", "#333"),
                    Check.Contains("Eingabefeld nutzt Verdana.", "input", "font-family", "verdana"),
                    Check.Contains("Button nutzt Verdana.", "button", "font-family", "verdana"),
                    Check.Js("Die Schrift wird nur auf body (und per inherit) gesetzt.",
                        "const bad = h.rules().filter(r => r.style.getPropertyValue('font-family') && !/inherit/.test(r.style.getPropertyValue('font-family')) && !/^body$/.test(r.selector.trim())); return bad.length === 0 || 'font-family sollte nur beim body stehen.';"),
                ],
                PreviewHeight = 200,
            },
        ],
        Project = new()
        {
            Id = "l08-projekt",
            Task = """
                <p>Zwei Feinheiten für das Café:</p>
                <ol>
                  <li>Die hervorgehobene Karte (sie hat die Klassen <code>card</code> <em>und</em> <code>featured</code>) soll einen <code>2px</code> breiten Rahmen in <code>#a0522d</code> bekommen.
                      Achte darauf, dass dein Selektor spezifischer als <code>.card</code> ist oder weiter unten steht.</li>
                  <li>Die Formularelemente (<code>input</code>, <code>textarea</code> und <code>button</code> im <code>.contact-form</code>) sollen die Schrift der Seite erben: <code>font: inherit</code>.</li>
                </ol>
                """,
            AddedCss = """
                .card.featured {
                  border: 2px solid #a0522d;
                }

                .contact-form input,
                .contact-form textarea,
                .contact-form button {
                  font: inherit;
                }
                """,
            Checks =
            [
                Check.Style("Hervorgehobene Karte: Rahmen 2px", ".card.featured", "border-top-width", "2px"),
                Check.Style("Hervorgehobene Karte: Rahmenfarbe #a0522d", ".card.featured", "border-top-color", "#a0522d"),
                Check.Style("Normale Karten behalten 1px Rahmen", ".card:not(.featured)", "border-top-width", "1px"),
                Check.Js("Eingabefelder erben die Schrift",
                    "return h.cs('.contact-form input', 'font-family') === h.cs('body', 'font-family') || 'Das Eingabefeld nutzt noch eine andere Schrift als die Seite.';"),
                Check.Js("Der Button erbt die Schrift",
                    "return h.cs('.contact-form button', 'font-family') === h.cs('body', 'font-family') || 'Der Button nutzt noch eine andere Schrift als die Seite.';"),
            ],
        },
    };
}
