namespace CssPlayground.Content.Lessons;

public static class L05Einheiten
{
    public static Lesson Create() => new()
    {
        Number = 5,
        Id = "einheiten",
        Title = "Maßeinheiten",
        Summary = "px, %, em, rem, vw und vh – wann welche Einheit sinnvoll ist.",
        Goals =
        [
            "Absolute und relative Einheiten unterscheiden",
            "em und rem sicher einsetzen",
            "Prozentwerte und Viewport-Einheiten verstehen",
            "Breiten mit width und max-width begrenzen",
        ],
        Sections =
        [
            new()
            {
                Title = "Pixel: px",
                Body = """
                    <p><code>px</code> ist die bekannteste Einheit und eine <strong>feste</strong> Größe. Sie ist gut für Dinge, die sich nicht anpassen sollen,
                    z.&nbsp;B. eine dünne Rahmenlinie von <code>1px</code>.</p>
                    <p>Für Schriftgrößen und Abstände sind <strong>relative</strong> Einheiten oft besser: Sie passen sich an, wenn jemand im Browser eine größere
                    Grundschrift eingestellt hat – wichtig für die Barrierefreiheit.</p>
                    """,
            },
            new()
            {
                Title = "em und rem",
                Body = """
                    <ul>
                      <li><code>rem</code> („root em“) bezieht sich auf die Schriftgröße des <code>&lt;html&gt;</code>-Elements – im Normalfall <code>16px</code>.
                          <code>2rem</code> sind also <code>32px</code>. Überall auf der Seite gleich – sehr berechenbar!</li>
                      <li><code>em</code> bezieht sich auf die Schriftgröße des <strong>aktuellen Elements</strong> (bzw. bei <code>font-size</code> des Elternelements).
                          Verschachtelte <code>em</code>-Angaben multiplizieren sich – das kann überraschen.</li>
                    </ul>
                    <p>Faustregel: <strong>rem für Schriftgrößen</strong>, <code>em</code> für Abstände, die mit der Schrift eines Elements mitwachsen sollen (z.&nbsp;B. Innenabstand eines Buttons).</p>
                    <p>Im Beispiel siehst du den Unterschied: Die <code>em</code>-Listen werden mit jeder Ebene größer, die <code>rem</code>-Listen nicht.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="em">
                          em-Ebene 1
                          <div class="em">
                            em-Ebene 2
                            <div class="em">em-Ebene 3</div>
                          </div>
                        </div>
                        <div class="rem">
                          rem-Ebene 1
                          <div class="rem">
                            rem-Ebene 2
                            <div class="rem">rem-Ebene 3</div>
                          </div>
                        </div>
                        """,
                    Css = """
                        body { font-family: Arial, sans-serif; }

                        .em  { font-size: 1.3em; color: darkred; }
                        .rem { font-size: 1.3rem; color: darkblue; }
                        """,
                    PreviewHeight = 260,
                },
            },
            new()
            {
                Title = "Prozent und Viewport-Einheiten",
                Body = """
                    <p><code>%</code> bezieht sich auf das <strong>Elternelement</strong>: <code>width: 50%</code> ist halb so breit wie der umgebende Container.</p>
                    <p>Viewport-Einheiten beziehen sich auf das Browserfenster:</p>
                    <ul>
                      <li><code>1vw</code> = 1&nbsp;% der Fensterbreite</li>
                      <li><code>1vh</code> = 1&nbsp;% der Fensterhöhe – <code>min-height: 100vh</code> macht einen Bereich mindestens bildschirmhoch</li>
                    </ul>
                    <p>Hier im Beispiel ist das „Fenster“ die Vorschau. Ziehe dein Browserfenster schmaler und beobachte die Balken.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="balken prozent">width: 50%</div>
                        <div class="balken vw">width: 30vw</div>
                        <div class="balken px">width: 200px</div>
                        """,
                    Css = """
                        .balken {
                          background-color: lightseagreen;
                          color: white;
                          margin-bottom: 8px;
                          padding: 6px;
                        }

                        .prozent { width: 50%; }
                        .vw      { width: 30vw; }
                        .px      { width: 200px; }
                        """,
                    PreviewHeight = 160,
                },
            },
            new()
            {
                Title = "Breiten begrenzen: max-width",
                Body = """
                    <p>Auf großen Bildschirmen werden Textzeilen schnell zu lang. Mit <code>max-width</code> legst du eine Höchstbreite fest:
                    Das Element darf schmaler werden, aber nie breiter als der angegebene Wert.</p>
                    <p>Eine typische Kombination ist <code>width: 90%; max-width: 1000px;</code> – auf kleinen Bildschirmen 90&nbsp;% breit, auf großen höchstens 1000&nbsp;Pixel.
                    Ähnlich gibt es <code>min-width</code>, <code>min-height</code> und <code>max-height</code>.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="inhalt">
                          Dieser Kasten ist 90 % breit, aber höchstens 300px. Ändere max-width auf 500px und beobachte, was passiert.
                        </div>
                        """,
                    Css = """
                        .inhalt {
                          width: 90%;
                          max-width: 300px;
                          background-color: wheat;
                          padding: 10px;
                        }
                        """,
                    PreviewHeight = 150,
                },
            },
        ],
        Exercises =
        [
            new()
            {
                Id = "l05-e1",
                Title = "Mit rem skalieren",
                Task = """
                    <p>Ersetze die Pixel-Schriftgrößen durch <code>rem</code>-Werte (Grundgröße 16px):</p>
                    <ul>
                      <li><code>h1</code>: <code>32px</code> → <code>2rem</code></li>
                      <li><code>p</code>: <code>18px</code> → <code>1.125rem</code></li>
                      <li><code>.klein</code>: <code>12px</code> → <code>0.75rem</code></li>
                    </ul>
                    <p>Das Aussehen ändert sich dabei nicht – aber deine Seite respektiert jetzt die Schrifteinstellung des Browsers.</p>
                    """,
                Html = """
                    <h1>Rezept: Pfannkuchen</h1>
                    <p>Mehl, Milch und Eier glatt rühren und eine Prise Salz hinzufügen.</p>
                    <p class="klein">Ergibt etwa 8 Stück.</p>
                    """,
                StarterCss = """
                    h1 {
                      font-size: 32px;
                    }

                    p {
                      font-size: 18px;
                    }

                    .klein {
                      font-size: 12px;
                    }
                    """,
                SolutionCss = """
                    h1 {
                      font-size: 2rem;
                    }

                    p {
                      font-size: 1.125rem;
                    }

                    .klein {
                      font-size: 0.75rem;
                    }
                    """,
                Checks =
                [
                    Check.Js("h1 verwendet 2rem.", "return h.ruleValue(/^h1$/, 'font-size') === '2rem' || 'Setze font-size: 2rem; für h1.';"),
                    Check.Js("p verwendet 1.125rem.", "return h.ruleValue(/^p$/, 'font-size') === '1.125rem' || 'Setze font-size: 1.125rem; für p.';"),
                    Check.Js(".klein verwendet 0.75rem.", "return h.ruleValue(/^\\.klein$/, 'font-size') === '0.75rem' || 'Setze font-size: 0.75rem; für .klein.';"),
                    Check.Style("Die Größen stimmen weiterhin (h1 = 32px).", "h1", "font-size", "32px"),
                ],
                PreviewHeight = 200,
            },
            new()
            {
                Id = "l05-e2",
                Title = "Lesbare Spaltenbreite",
                Task = """
                    <p>Der Text läuft über die ganze Breite. Gib <code>.text</code> eine Breite von <code>80%</code> und eine Höchstbreite von <code>400px</code>.</p>
                    """,
                Html = """
                    <p class="text">Lange Zeilen sind schwer zu lesen. Typografen empfehlen etwa 60 bis 75 Zeichen pro Zeile. Mit max-width sorgst du dafür, dass Texte auch auf großen Bildschirmen angenehm lesbar bleiben.</p>
                    """,
                StarterCss = """
                    .text {
                      background-color: lavender;
                      padding: 12px;
                    }
                    """,
                SolutionCss = """
                    .text {
                      background-color: lavender;
                      padding: 12px;
                      width: 80%;
                      max-width: 400px;
                    }
                    """,
                Checks =
                [
                    Check.Js("Breite ist 80 %.", "return h.ruleValue(/\\.text/, 'width') === '80%' || 'Setze width: 80%;';"),
                    Check.Style("Höchstbreite ist 400px.", ".text", "max-width", "400px"),
                ],
                PreviewHeight = 180,
            },
        ],
        Project = new()
        {
            Id = "l05-projekt",
            Task = """
                <p>Damit die Café-Seite auf jedem Bildschirm gut aussieht, nutzen wir relative Einheiten und begrenzen die Inhaltsbreite.</p>
                <ol>
                  <li>Alle Inhalte stecken in Elementen mit der Klasse <code>container</code>. Gib <code>.container</code> eine Breite von <code>90%</code> und eine Höchstbreite von <code>1000px</code>.</li>
                  <li>Stelle die Schriftgrößen auf <code>rem</code> um: <code>h1</code> → <code>2.5rem</code>, <code>h2</code> → <code>1.875rem</code>, <code>.hero-text</code> → <code>1.2rem</code>.</li>
                  <li>Der Hero-Bereich (<code>.hero</code>) soll mindestens <code>60vh</code> hoch sein (<code>min-height</code>).</li>
                </ol>
                """,
            AddedCss = """
                .container {
                  width: 90%;
                  max-width: 1000px;
                }

                h1 {
                  font-size: 2.5rem;
                }

                h2 {
                  font-size: 1.875rem;
                }

                .hero-text {
                  font-size: 1.2rem;
                }

                .hero {
                  min-height: 60vh;
                }
                """,
            Checks =
            [
                Check.Js(".container ist 90 % breit.", "return h.ruleValue(/\\.container/, 'width') === '90%' || 'Setze width: 90%; für .container.';"),
                Check.Style(".container ist höchstens 1000px breit.", ".container", "max-width", "1000px"),
                Check.Js("h1 nutzt 2.5rem.", "return h.ruleValue(/(^|,)\\s*h1\\s*($|,)/, 'font-size') === '2.5rem' || 'Setze font-size: 2.5rem; für h1.';"),
                Check.Js("h2 nutzt 1.875rem.", "return h.ruleValue(/(^|,)\\s*h2\\s*($|,)/, 'font-size') === '1.875rem' || 'Setze font-size: 1.875rem; für h2.';"),
                Check.Js(".hero-text nutzt 1.2rem.", "return h.ruleValue(/\\.hero-text/, 'font-size') === '1.2rem' || 'Setze font-size: 1.2rem; für .hero-text.';"),
                Check.Js("Hero ist mindestens 60vh hoch.", "return h.ruleValue(/\\.hero$/, 'min-height') === '60vh' || 'Setze min-height: 60vh; für .hero.';"),
            ],
        },
    };
}
