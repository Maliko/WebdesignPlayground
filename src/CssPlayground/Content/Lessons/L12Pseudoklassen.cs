namespace CssPlayground.Content.Lessons;

public static class L12Pseudoklassen
{
    public static Lesson Create() => new()
    {
        Number = 12,
        Id = "pseudoklassen",
        Title = "Pseudoklassen und Pseudoelemente",
        Summary = "Zustände wie :hover und :focus gestalten, Elemente nach Position wählen und Inhalte mit ::before einfügen.",
        Goals =
        [
            "Interaktive Zustände mit :hover, :focus und :active gestalten",
            "Elemente mit :first-child, :last-child und :nth-child auswählen",
            "Mit ::before und ::after dekorative Inhalte erzeugen",
            "Weitere Pseudoelemente wie ::placeholder kennen",
        ],
        Sections =
        [
            new()
            {
                Title = "Zustände: :hover, :focus, :active",
                Body = """
                    <p>Pseudoklassen beschreiben einen <strong>Zustand</strong> eines Elements. Sie werden mit einem Doppelpunkt an den Selektor gehängt:</p>
                    <ul>
                      <li><code>a:hover</code> – die Maus befindet sich über dem Element</li>
                      <li><code>input:focus</code> – das Element ist fokussiert (z.&nbsp;B. angeklickt oder per Tab-Taste erreicht)</li>
                      <li><code>button:active</code> – während das Element gedrückt wird</li>
                      <li><code>a:visited</code> – ein bereits besuchter Link</li>
                    </ul>
                    <p>Fahre in der Vorschau mit der Maus über den Button und klicke in das Eingabefeld.</p>
                    <div class="tip"><strong>Barrierefreiheit:</strong> Entferne niemals den Fokus-Rahmen (<code>outline: none</code>), ohne einen gut sichtbaren Ersatz zu gestalten. Menschen, die mit der Tastatur navigieren, sind darauf angewiesen.</div>
                    """,
                Example = new()
                {
                    Html = """
                        <button class="btn">Fahr über mich</button>
                        <p><input placeholder="Klick mich an"></p>
                        """,
                    Css = """
                        .btn {
                          background-color: royalblue;
                          color: white;
                          border: none;
                          padding: 10px 20px;
                          font-size: 16px;
                        }

                        .btn:hover {
                          background-color: navy;
                        }

                        .btn:active {
                          background-color: crimson;
                        }

                        input {
                          padding: 8px;
                          border: 2px solid #ccc;
                        }

                        input:focus {
                          border-color: royalblue;
                          outline: 3px solid lightblue;
                        }
                        """,
                    PreviewHeight = 140,
                },
            },
            new()
            {
                Title = "Struktur: :first-child, :last-child, :nth-child()",
                Body = """
                    <p>Diese Pseudoklassen wählen Elemente nach ihrer <strong>Position</strong> unter den Geschwistern:</p>
                    <ul>
                      <li><code>li:first-child</code> / <code>li:last-child</code> – das erste bzw. letzte Kind</li>
                      <li><code>li:nth-child(3)</code> – das dritte</li>
                      <li><code>tr:nth-child(odd)</code> / <code>tr:nth-child(even)</code> – jedes ungerade / gerade (perfekt für Zebrastreifen in Tabellen)</li>
                      <li><code>li:nth-child(3n)</code> – jedes dritte</li>
                      <li><code>li:not(:last-child)</code> – alle außer dem letzten</li>
                    </ul>
                    """,
                Example = new()
                {
                    Html = """
                        <ul class="liste">
                          <li>Eins</li>
                          <li>Zwei</li>
                          <li>Drei</li>
                          <li>Vier</li>
                          <li>Fünf</li>
                          <li>Sechs</li>
                        </ul>
                        """,
                    Css = """
                        .liste {
                          list-style: none;
                          padding: 0;
                        }

                        .liste li {
                          padding: 6px 10px;
                        }

                        .liste li:nth-child(even) {
                          background-color: #f0f0f0;
                        }

                        .liste li:first-child {
                          font-weight: bold;
                        }

                        .liste li:not(:last-child) {
                          border-bottom: 1px solid #ddd;
                        }
                        """,
                    PreviewHeight = 240,
                },
            },
            new()
            {
                Title = "Pseudoelemente: ::before und ::after",
                Body = """
                    <p>Pseudoelemente erzeugen <strong>zusätzliche Teile</strong> eines Elements, die gar nicht im HTML stehen. Sie werden mit zwei Doppelpunkten geschrieben.</p>
                    <p><code>::before</code> und <code>::after</code> fügen Inhalt am Anfang bzw. Ende des Elements ein. Pflicht ist die Eigenschaft <code>content</code> – sonst erscheint nichts:</p>
                    <pre><code>.hinweis::before {
                      content: "💡 ";
                    }</code></pre>
                    <p>Mit leerem Inhalt (<code>content: ""</code>) und <code>display: block</code> lassen sich auch rein dekorative Formen bauen, etwa eine Linie unter einer Überschrift.</p>
                    <p>Weitere Pseudoelemente: <code>::placeholder</code> (Platzhaltertext in Eingabefeldern), <code>::first-letter</code>, <code>::selection</code> (markierter Text).</p>
                    """,
                Example = new()
                {
                    Html = """
                        <h2 class="titel">Überschrift mit Linie</h2>
                        <p class="hinweis">Speichere regelmäßig deine Arbeit.</p>
                        <p class="initial">Es war einmal ein Absatz mit einer großen Initiale am Anfang.</p>
                        """,
                    Css = """
                        .titel::after {
                          content: "";
                          display: block;
                          width: 60px;
                          height: 4px;
                          background-color: orange;
                          margin-top: 6px;
                        }

                        .hinweis::before {
                          content: "💡 ";
                        }

                        .initial::first-letter {
                          font-size: 2.5em;
                          color: darkred;
                          float: left;
                          margin-right: 4px;
                        }
                        """,
                    PreviewHeight = 220,
                },
            },
        ],
        Exercises =
        [
            new()
            {
                Id = "l12-e1",
                Title = "Zebratabelle mit Hover",
                Task = """
                    <p>Mach die Tabelle übersichtlicher:</p>
                    <ul>
                      <li>Jede <strong>gerade</strong> Zeile im <code>tbody</code> bekommt den Hintergrund <code>#f2f2f2</code>.</li>
                      <li>Beim Überfahren mit der Maus soll eine Zeile im <code>tbody</code> den Hintergrund <code>lightyellow</code> bekommen.</li>
                    </ul>
                    """,
                Html = """
                    <table>
                      <thead>
                        <tr><th>Stadt</th><th>Einwohner</th></tr>
                      </thead>
                      <tbody>
                        <tr><td>Berlin</td><td>3,7 Mio.</td></tr>
                        <tr><td>Hamburg</td><td>1,9 Mio.</td></tr>
                        <tr><td>München</td><td>1,5 Mio.</td></tr>
                        <tr><td>Köln</td><td>1,1 Mio.</td></tr>
                      </tbody>
                    </table>
                    """,
                StarterCss = """
                    table {
                      border-collapse: collapse;
                      width: 100%;
                    }

                    th, td {
                      padding: 8px;
                      text-align: left;
                    }

                    thead {
                      background-color: #333;
                      color: white;
                    }
                    """,
                SolutionCss = """
                    table {
                      border-collapse: collapse;
                      width: 100%;
                    }

                    th, td {
                      padding: 8px;
                      text-align: left;
                    }

                    thead {
                      background-color: #333;
                      color: white;
                    }

                    tbody tr:nth-child(even) {
                      background-color: #f2f2f2;
                    }

                    tbody tr:hover {
                      background-color: lightyellow;
                    }
                    """,
                Checks =
                [
                    Check.Style("Zweite Zeile ist grau (#f2f2f2).", "tbody tr:nth-child(2)", "background-color", "#f2f2f2"),
                    Check.Style("Erste Zeile bleibt ohne Hintergrund.", "tbody tr:nth-child(1)", "background-color", "transparent"),
                    Check.Js("Hover-Regel für Tabellenzeilen ist vorhanden.",
                        "const r = h.findRules(/tr:hover/, { prop: 'background-color' }); if (!r.length) return 'Es gibt noch keine Regel mit tr:hover.'; return h.norm('background-color', r[r.length - 1].style.getPropertyValue('background-color')) === h.norm('background-color', 'lightyellow') || 'Die Hover-Farbe sollte lightyellow sein.';"),
                ],
                PreviewHeight = 220,
            },
            new()
            {
                Id = "l12-e2",
                Title = "Pflichtfelder markieren",
                Task = """
                    <p>Hänge an jedes Label mit der Klasse <code>pflicht</code> mit <code>::after</code> ein rotes Sternchen an: Inhalt <code>" *"</code>, Farbe <code>red</code>.</p>
                    """,
                Html = """
                    <form>
                      <p><label class="pflicht">Name</label><br><input></p>
                      <p><label>Telefon</label><br><input></p>
                      <p><label class="pflicht">E-Mail</label><br><input></p>
                    </form>
                    """,
                SolutionCss = """
                    .pflicht::after {
                      content: " *";
                      color: red;
                    }
                    """,
                Checks =
                [
                    Check.Contains("Pflichtfeld-Labels haben ein Sternchen.", ".pflicht", "content", "*", "::after"),
                    Check.Style("Das Sternchen ist rot.", ".pflicht", "color", "red", "::after"),
                    Check.Js("Andere Labels haben kein Sternchen.", "const c = h.cs('label:not(.pflicht)', 'content', '::after'); return c === 'none' || c === 'normal' || 'Auch das Telefon-Label hat ein ::after – wähle nur .pflicht aus.';"),
                ],
                PreviewHeight = 220,
            },
        ],
        Project = new()
        {
            Id = "l12-projekt",
            Task = """
                <p>Das Café wird interaktiv:</p>
                <ol>
                  <li>Navigationslinks: beim Überfahren (<code>:hover</code>) Farbe <code>#f3c98b</code>.</li>
                  <li>Buttons: beim Überfahren Hintergrund <code>#7a3e20</code>.</li>
                  <li>Eingabefelder im Kontaktformular: bei <code>:focus</code> eine Umrandung <code>outline: 2px solid #a0522d</code>.</li>
                  <li>Zebrastreifen für die Öffnungszeiten: Jede <strong>ungerade</strong> Zeile (<code>.hours tr</code>) bekommt den Hintergrund <code>#f7efe5</code>.
                      Gib außerdem <code>th</code> und <code>td</code> der Tabelle einen Innenabstand von <code>8px 24px</code> und richte die <code>th</code> links aus.</li>
                  <li>Unter jeder <code>h2</code> erscheint eine dekorative Linie mit <code>::after</code>: leerer Inhalt, <code>display: block</code>,
                      <code>60px</code> breit, <code>3px</code> hoch, Hintergrund <code>#a0522d</code>, <code>margin: 12px auto 0</code>.</li>
                </ol>
                """,
            AddedCss = """
                .main-nav a:hover {
                  color: #f3c98b;
                }

                .button:hover {
                  background-color: #7a3e20;
                }

                .contact-form input:focus,
                .contact-form textarea:focus {
                  outline: 2px solid #a0522d;
                }

                .hours tr:nth-child(odd) {
                  background-color: #f7efe5;
                }

                .hours th,
                .hours td {
                  padding: 8px 24px;
                }

                .hours th {
                  text-align: left;
                }

                h2::after {
                  content: "";
                  display: block;
                  width: 60px;
                  height: 3px;
                  background-color: #a0522d;
                  margin: 12px auto 0;
                }
                """,
            Checks =
            [
                Check.Js("Hover-Farbe für Navigationslinks",
                    "const r = h.findRules(/nav[^,]*a:hover/, { prop: 'color' }); if (!r.length) return 'Keine :hover-Regel für die Navigationslinks gefunden.'; return h.norm('color', r[r.length - 1].style.getPropertyValue('color')) === h.norm('color', '#f3c98b') || 'Die Hover-Farbe sollte #f3c98b sein.';"),
                Check.Js("Hover-Hintergrund für Buttons",
                    "const r = h.findRules(/\\.button:hover/, { prop: 'background-color' }); if (!r.length) return 'Keine :hover-Regel für .button gefunden.'; return h.norm('background-color', r[r.length - 1].style.getPropertyValue('background-color')) === h.norm('background-color', '#7a3e20') || 'Der Hover-Hintergrund sollte #7a3e20 sein.';"),
                Check.Js("Fokus-Umrandung für Eingabefelder",
                    "return h.findRules(/input:focus/).some(r => r.style.getPropertyValue('outline') || r.style.getPropertyValue('outline-style')) || 'Keine :focus-Regel mit outline für input gefunden.';"),
                Check.Style("Ungerade Tabellenzeilen haben #f7efe5", ".hours tr:nth-child(1)", "background-color", "#f7efe5"),
                Check.Style("Gerade Tabellenzeilen bleiben ohne Hintergrund", ".hours tr:nth-child(2)", "background-color", "transparent"),
                Check.Style("Tabellenzellen mit 24px Innenabstand", ".hours td", "padding-left", "24px"),
                Check.Style("Tabellenköpfe links ausgerichtet", ".hours th", "text-align", "left"),
                Check.Style("h2::after ist ein Block", "h2", "display", "block", "::after"),
                Check.Style("Linie ist 60px breit", "h2", "width", "60px", "::after"),
                Check.Style("Linie ist 3px hoch", "h2", "height", "3px", "::after"),
                Check.Style("Linie hat die Farbe #a0522d", "h2", "background-color", "#a0522d", "::after"),
            ],
        },
    };
}
