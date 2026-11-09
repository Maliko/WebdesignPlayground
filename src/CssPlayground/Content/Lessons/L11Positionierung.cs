namespace CssPlayground.Content.Lessons;

public static class L11Positionierung
{
    public static Lesson Create() => new()
    {
        Number = 11,
        Id = "positionierung",
        Title = "Positionierung",
        Summary = "relative, absolute, fixed und sticky – Elemente gezielt platzieren und stapeln.",
        Goals =
        [
            "Die Werte von position und ihre Wirkung kennen",
            "Elemente mit top, right, bottom und left verschieben",
            "Absolut positionierte Elemente an einem Elternelement ausrichten",
            "Klebende Kopfzeilen mit sticky bauen",
            "Die Stapelreihenfolge mit z-index steuern",
        ],
        Sections =
        [
            new()
            {
                Title = "static und relative",
                Body = """
                    <p>Normalerweise stehen Elemente im <strong>normalen Fluss</strong> (<code>position: static</code>) – eins nach dem anderen.</p>
                    <p>Mit <code>position: relative</code> bleibt das Element an seinem Platz im Fluss, lässt sich aber mit
                    <code>top</code>, <code>right</code>, <code>bottom</code> und <code>left</code> <strong>relativ zu seiner ursprünglichen Position</strong> verschieben.
                    Der ursprüngliche Platz bleibt dabei frei.</p>
                    <p>Viel wichtiger ist aber ein Nebeneffekt: Ein Element mit <code>position: relative</code> wird zum <strong>Bezugspunkt</strong> für absolut positionierte Kinder.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="box">1</div>
                        <div class="box verschoben">2 (relative)</div>
                        <div class="box">3</div>
                        """,
                    Css = """
                        .box {
                          width: 140px;
                          padding: 12px;
                          margin-bottom: 6px;
                          background-color: lightsalmon;
                        }

                        .verschoben {
                          position: relative;
                          top: 10px;
                          left: 40px;
                          background-color: tomato;
                        }
                        """,
                    PreviewHeight = 180,
                },
            },
            new()
            {
                Title = "absolute",
                Body = """
                    <p>Ein Element mit <code>position: absolute</code> wird <strong>aus dem Fluss genommen</strong> – andere Elemente verhalten sich, als gäbe es es nicht.
                    Es wird am nächsten Vorfahren ausgerichtet, der selbst positioniert ist (also nicht <code>static</code>).</p>
                    <p>Das klassische Muster: Elternelement <code>position: relative</code>, Kind <code>position: absolute</code> mit Koordinaten.
                    So lassen sich Badges, Labels oder Schließen-Buttons in Ecken platzieren.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="produkt">
                          <span class="sale">-20 %</span>
                          <h3>Sneaker</h3>
                          <p>Bequem und leicht.</p>
                        </div>
                        """,
                    Css = """
                        .produkt {
                          position: relative;
                          width: 220px;
                          padding: 20px;
                          border: 1px solid #ccc;
                          margin: 20px;
                        }

                        .sale {
                          position: absolute;
                          top: -10px;
                          right: -10px;
                          background-color: crimson;
                          color: white;
                          padding: 4px 10px;
                          border-radius: 12px;
                        }
                        """,
                    PreviewHeight = 180,
                },
            },
            new()
            {
                Title = "fixed und sticky",
                Body = """
                    <ul>
                      <li><code>position: fixed</code> richtet ein Element am <strong>Browserfenster</strong> aus. Es bleibt beim Scrollen stehen –
                          typisch für Chat-Buttons oder Cookie-Hinweise.</li>
                      <li><code>position: sticky</code> ist eine Mischung: Das Element scrollt normal mit, bis es eine Grenze erreicht (z.&nbsp;B. <code>top: 0</code>),
                          und „klebt“ dann dort. Ideal für Kopfzeilen und Tabellenüberschriften.</li>
                    </ul>
                    <p>Scrolle in der Vorschau, um beide zu erleben!</p>
                    """,
                Example = new()
                {
                    Html = """
                        <header class="kopf">Ich klebe oben (sticky)</header>
                        <p>Scroll mal runter …</p>
                        <p style="height: 600px;">Viel Inhalt …</p>
                        <p>Ende.</p>
                        <button class="chat">💬</button>
                        """,
                    Css = """
                        body { margin: 0; }

                        .kopf {
                          position: sticky;
                          top: 0;
                          background-color: navy;
                          color: white;
                          padding: 12px;
                        }

                        .chat {
                          position: fixed;
                          bottom: 16px;
                          right: 16px;
                          font-size: 24px;
                        }
                        """,
                    PreviewHeight = 220,
                },
            },
            new()
            {
                Title = "Stapeln mit z-index",
                Body = """
                    <p>Überlappen sich positionierte Elemente, liegt normalerweise das später im HTML stehende oben.
                    Mit <code>z-index</code> änderst du das: Höhere Werte liegen weiter vorn. <code>z-index</code> wirkt nur bei positionierten Elementen
                    (und bei Flex- und Grid-Items).</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="karte a">A</div>
                        <div class="karte b">B</div>
                        <div class="karte c">C</div>
                        """,
                    Css = """
                        .karte {
                          position: absolute;
                          width: 100px;
                          height: 100px;
                          padding: 8px;
                          color: white;
                          font-size: 20px;
                        }

                        .a { top: 20px; left: 20px;  background: crimson; z-index: 3; }
                        .b { top: 50px; left: 60px;  background: seagreen; z-index: 2; }
                        .c { top: 80px; left: 100px; background: royalblue; z-index: 1; }
                        """,
                    PreviewHeight = 220,
                },
            },
        ],
        Exercises =
        [
            new()
            {
                Id = "l11-e1",
                Title = "Benachrichtigungs-Zähler",
                Task = """
                    <p>Der rote Zähler soll in der <strong>rechten oberen Ecke</strong> der Glocke sitzen:</p>
                    <ul>
                      <li><code>.glocke</code> wird zum Bezugspunkt.</li>
                      <li><code>.zaehler</code> wird absolut positioniert mit <code>top: -8px</code> und <code>right: -8px</code>.</li>
                    </ul>
                    """,
                Html = """
                    <button class="glocke">
                      🔔
                      <span class="zaehler">3</span>
                    </button>
                    """,
                StarterCss = """
                    .glocke {
                      font-size: 32px;
                      padding: 10px 14px;
                      margin: 20px;
                      background: #eee;
                      border: none;
                      border-radius: 8px;
                    }

                    .zaehler {
                      background-color: red;
                      color: white;
                      font-size: 12px;
                      padding: 2px 7px;
                      border-radius: 10px;
                    }
                    """,
                SolutionCss = """
                    .glocke {
                      font-size: 32px;
                      padding: 10px 14px;
                      margin: 20px;
                      background: #eee;
                      border: none;
                      border-radius: 8px;
                      position: relative;
                    }

                    .zaehler {
                      background-color: red;
                      color: white;
                      font-size: 12px;
                      padding: 2px 7px;
                      border-radius: 10px;
                      position: absolute;
                      top: -8px;
                      right: -8px;
                    }
                    """,
                Checks =
                [
                    Check.Style(".glocke ist relativ positioniert.", ".glocke", "position", "relative"),
                    Check.Style(".zaehler ist absolut positioniert.", ".zaehler", "position", "absolute"),
                    Check.Js("Der Zähler sitzt oben rechts an der Glocke.",
                        "const g = h.rect('.glocke'); const z = h.rect('.zaehler'); return (Math.abs(z.top - (g.top - 8)) < 1.5 && Math.abs(z.right - (g.right + 8)) < 1.5) || 'Der Zähler sitzt noch nicht 8px über der oberen rechten Ecke.';"),
                ],
                PreviewHeight = 140,
            },
        ],
        Project = new()
        {
            Id = "l11-projekt",
            Task = """
                <p>Zwei Positionierungs-Details für das Café:</p>
                <ol>
                  <li>Der Kopfbereich (<code>.site-header</code>) soll beim Scrollen oben kleben: <code>position: sticky</code>, <code>top: 0</code>
                      und <code>z-index: 10</code>, damit er über dem Inhalt liegt.</li>
                  <li>Das Badge „Beliebt“ (<code>.badge</code>) soll oben rechts auf seiner Karte schweben:
                      Karten werden mit <code>position: relative</code> zum Bezugspunkt, das Badge wird absolut positioniert mit <code>top: -12px</code> und <code>right: 16px</code>.</li>
                  <li>Gestalte das Badge: Hintergrund <code>#a0522d</code>, Schrift <code>white</code>, Innenabstand <code>4px 12px</code>, Schriftgröße <code>0.8rem</code>.</li>
                </ol>
                """,
            AddedCss = """
                .site-header {
                  position: sticky;
                  top: 0;
                  z-index: 10;
                }

                .card {
                  position: relative;
                }

                .badge {
                  position: absolute;
                  top: -12px;
                  right: 16px;
                  background-color: #a0522d;
                  color: white;
                  padding: 4px 12px;
                  font-size: 0.8rem;
                }
                """,
            Checks =
            [
                Check.Style("Header ist sticky", ".site-header", "position", "sticky"),
                Check.Style("Header klebt oben (top: 0)", ".site-header", "top", "0px"),
                Check.Style("Header liegt vorn (z-index 10)", ".site-header", "z-index", "10"),
                Check.Style("Karten sind relativ positioniert", ".card", "position", "relative"),
                Check.Style("Badge ist absolut positioniert", ".badge", "position", "absolute"),
                Check.Js("Badge sitzt oben rechts auf der Karte",
                    "const el = h.q('.featured'); const c = el.getBoundingClientRect(); const top = c.top + el.clientTop; const right = c.left + el.clientLeft + el.clientWidth; const b = h.rect('.badge'); return (Math.abs(b.top - (top - 12)) < 1.5 && Math.abs(b.right - (right - 16)) < 1.5) || 'Das Badge sitzt noch nicht bei top: -12px / right: 16px.';"),
                Check.Style("Badge-Hintergrund #a0522d", ".badge", "background-color", "#a0522d"),
                Check.Style("Badge-Schrift weiß", ".badge", "color", "white"),
                Check.Style("Badge-Schriftgröße 0.8rem", ".badge", "font-size", "12.8px"),
            ],
        },
    };
}
