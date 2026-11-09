namespace CssPlayground.Content.Lessons;

public static class L07Display
{
    public static Lesson Create() => new()
    {
        Number = 7,
        Id = "display",
        Title = "Block, Inline und display",
        Summary = "Wie Elemente im Textfluss stehen – und wie du das mit display änderst.",
        Goals =
        [
            "Block- und Inline-Elemente unterscheiden",
            "inline-block für Buttons und Menüs einsetzen",
            "Elemente mit display: none ausblenden",
            "Listen für Navigationen zurücksetzen",
        ],
        Sections =
        [
            new()
            {
                Title = "Block und Inline",
                Body = """
                    <p>HTML-Elemente verhalten sich standardmäßig unterschiedlich:</p>
                    <ul>
                      <li><strong>Block-Elemente</strong> (<code>div</code>, <code>p</code>, <code>h1</code>, <code>section</code>, <code>ul</code> …) beginnen in einer neuen Zeile
                          und nehmen die <strong>volle verfügbare Breite</strong> ein. <code>width</code>, <code>height</code> und alle Abstände wirken.</li>
                      <li><strong>Inline-Elemente</strong> (<code>a</code>, <code>span</code>, <code>strong</code>, <code>em</code> …) fließen im Text mit und sind nur so breit wie ihr Inhalt.
                          <code>width</code> und <code>height</code> werden ignoriert, vertikale <code>margin</code>-Werte ebenfalls.</li>
                    </ul>
                    <p>Im Beispiel haben alle Elemente einen Rahmen, damit du ihre Boxen siehst.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div>Ein div (Block)</div>
                        <p>Ein Absatz (Block) mit <span>einem span</span> und <a href="#">einem Link</a> (beide inline).</p>
                        <span>Noch ein span</span><span>und noch einer</span>
                        """,
                    Css = """
                        div, p {
                          border: 2px solid royalblue;
                        }

                        span, a {
                          border: 2px solid orangered;
                          width: 300px; /* wirkt nicht bei inline! */
                        }
                        """,
                    PreviewHeight = 180,
                },
            },
            new()
            {
                Title = "display ändert das Verhalten",
                Body = """
                    <p>Mit der Eigenschaft <code>display</code> kannst du das Verhalten jedes Elements ändern:</p>
                    <ul>
                      <li><code>display: block;</code> – Element verhält sich wie ein Block</li>
                      <li><code>display: inline;</code> – Element fließt im Text</li>
                      <li><code>display: inline-block;</code> – steht in einer Zeile mit anderen, akzeptiert aber <code>width</code>, <code>height</code> und alle Abstände.
                          Perfekt für <strong>Buttons</strong>!</li>
                      <li><code>display: none;</code> – das Element verschwindet komplett (und nimmt keinen Platz mehr ein)</li>
                    </ul>
                    <p>Später lernst du noch <code>display: flex</code> und <code>display: grid</code> kennen – die modernen Layout-Werkzeuge.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <a href="#" class="button">Button 1</a>
                        <a href="#" class="button">Button 2</a>
                        <p class="geheim">Mich sieht man nicht.</p>
                        <p>Ändere inline-block in block oder inline und beobachte die Buttons.</p>
                        """,
                    Css = """
                        .button {
                          display: inline-block;
                          padding: 10px 20px;
                          margin: 10px 4px;
                          background-color: mediumseagreen;
                          color: white;
                          text-decoration: none;
                        }

                        .geheim {
                          display: none;
                        }
                        """,
                    PreviewHeight = 180,
                },
            },
            new()
            {
                Title = "Navigation aus einer Liste",
                Body = """
                    <p>Menüs werden meist als Liste <code>&lt;ul&gt;</code> geschrieben – das ist semantisch sinnvoll. Für die Darstellung entfernen wir dann:</p>
                    <ul>
                      <li>die Aufzählungspunkte mit <code>list-style: none;</code></li>
                      <li>den Standard-Einzug mit <code>padding: 0;</code> und <code>margin: 0;</code></li>
                    </ul>
                    <p>und stellen die Listeneinträge mit <code>display: inline-block</code> nebeneinander.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <ul class="menu">
                          <li><a href="#">Start</a></li>
                          <li><a href="#">Produkte</a></li>
                          <li><a href="#">Über uns</a></li>
                        </ul>
                        """,
                    Css = """
                        .menu {
                          list-style: none;
                          margin: 0;
                          padding: 0;
                          background-color: #222;
                        }

                        .menu li {
                          display: inline-block;
                        }

                        .menu a {
                          display: block;
                          padding: 12px 16px;
                          color: white;
                          text-decoration: none;
                        }
                        """,
                    PreviewHeight = 120,
                },
            },
        ],
        Exercises =
        [
            new()
            {
                Id = "l07-e1",
                Title = "Tags nebeneinander",
                Task = """
                    <p>Die Schlagworte (<code>.tag</code>) sind <code>div</code>-Elemente und stehen daher untereinander über die volle Breite.
                    Stelle sie mit <code>inline-block</code> nebeneinander. Blende außerdem das Element mit der Klasse <code>.intern</code> aus.</p>
                    """,
                Html = """
                    <p>Schlagworte:</p>
                    <div class="tag">CSS</div>
                    <div class="tag">HTML</div>
                    <div class="tag">Webdesign</div>
                    <div class="tag intern">Entwurf</div>
                    """,
                StarterCss = """
                    .tag {
                      background-color: lightsteelblue;
                      padding: 4px 12px;
                      margin: 4px;
                    }
                    """,
                SolutionCss = """
                    .tag {
                      background-color: lightsteelblue;
                      padding: 4px 12px;
                      margin: 4px;
                      display: inline-block;
                    }

                    .intern {
                      display: none;
                    }
                    """,
                Checks =
                [
                    Check.Style("Tags sind inline-block.", ".tag", "display", "inline-block"),
                    Check.Style(".intern ist ausgeblendet.", ".intern", "display", "none"),
                    Check.Js("Die Tags stehen in einer Zeile.", "const t = h.qa('.tag'); return Math.abs(t[0].getBoundingClientRect().top - t[2].getBoundingClientRect().top) < 2 || 'Die Tags stehen noch untereinander.';"),
                ],
                PreviewHeight = 160,
            },
        ],
        Project = new()
        {
            Id = "l07-projekt",
            Task = """
                <p>Navigation und Button des Cafés nehmen Form an:</p>
                <ol>
                  <li><code>.main-nav ul</code>: keine Aufzählungspunkte, <code>margin</code> und <code>padding</code> auf 0.</li>
                  <li><code>.main-nav li</code>: <code>display: inline-block</code> und <code>margin-left: 20px</code>.</li>
                  <li><code>.button</code>: <code>display: inline-block</code>, Innenabstand <code>12px 24px</code>, Hintergrund <code>#a0522d</code>,
                      Schriftfarbe <code>white</code>, keine Unterstreichung.</li>
                  <li>Die Elemente im Kontaktformular (<code>.contact-form label</code>, <code>input</code> und <code>textarea</code>) sollen untereinander stehen:
                      <code>display: block</code> und <code>width: 100%</code>. Gib <code>input</code> und <code>textarea</code> außerdem <code>padding: 10px</code> und <code>margin-bottom: 16px</code>.</li>
                </ol>
                """,
            AddedCss = """
                .main-nav ul {
                  list-style: none;
                  margin: 0;
                  padding: 0;
                }

                .main-nav li {
                  display: inline-block;
                  margin-left: 20px;
                }

                .button {
                  display: inline-block;
                  padding: 12px 24px;
                  background-color: #a0522d;
                  color: white;
                  text-decoration: none;
                }

                .contact-form label,
                .contact-form input,
                .contact-form textarea {
                  display: block;
                  width: 100%;
                }

                .contact-form input,
                .contact-form textarea {
                  padding: 10px;
                  margin-bottom: 16px;
                }
                """,
            Checks =
            [
                Check.Style("Navigation ohne Aufzählungspunkte", ".main-nav ul", "list-style-type", "none"),
                Check.Style("Navigationsliste ohne Einzug", ".main-nav ul", "padding-left", "0px"),
                Check.Style("Listeneinträge sind inline-block", ".main-nav li", "display", "inline-block"),
                Check.Style("Listeneinträge haben 20px Abstand links", ".main-nav li", "margin-left", "20px"),
                Check.Style("Button ist inline-block", ".hero .button", "display", "inline-block"),
                Check.Style("Button-Innenabstand oben 12px", ".hero .button", "padding-top", "12px"),
                Check.Style("Button-Innenabstand links 24px", ".hero .button", "padding-left", "24px"),
                Check.Style("Button-Hintergrund #a0522d", ".hero .button", "background-color", "#a0522d"),
                Check.Style("Button-Schrift weiß", ".hero .button", "color", "white"),
                Check.Style("Button nicht unterstrichen", ".hero .button", "text-decoration-line", "none"),
                Check.Style("Labels sind Block-Elemente", ".contact-form label", "display", "block"),
                Check.Style("Eingabefeld ist ein Block-Element", ".contact-form input", "display", "block"),
                Check.Js("Eingabefelder sind so breit wie das Formular",
                    "const f = h.rect('.contact-form'); const i = h.rect('.contact-form textarea'); return Math.abs(f.width - i.width) < 2 || 'Das Textfeld ist noch nicht 100 % breit.';"),
                Check.Style("Eingabefeld mit 10px Innenabstand", ".contact-form input", "padding-top", "10px"),
                Check.Style("Eingabefeld mit 16px Abstand unten", ".contact-form textarea", "margin-bottom", "16px"),
            ],
        },
    };
}
