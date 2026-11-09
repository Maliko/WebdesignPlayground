namespace CssPlayground.Content.Lessons;

public static class L03Farben
{
    public static Lesson Create() => new()
    {
        Number = 3,
        Id = "farben",
        Title = "Farben",
        Summary = "Farbnamen, Hex-Codes, rgb() und hsl() – plus Hintergrundfarben und Transparenz.",
        Goals =
        [
            "Farben als Name, Hex-Code, rgb() und hsl() angeben",
            "Text- und Hintergrundfarben setzen",
            "Transparenz mit Alpha-Werten nutzen",
            "Auf ausreichenden Kontrast achten",
        ],
        Sections =
        [
            new()
            {
                Title = "Textfarbe und Hintergrundfarbe",
                Body = """
                    <p>Zwei Eigenschaften brauchst du ständig:</p>
                    <ul>
                      <li><code>color</code> – die Farbe des Textes</li>
                      <li><code>background-color</code> – die Hintergrundfarbe des Elements</li>
                    </ul>
                    <p>Der einfachste Weg, eine Farbe anzugeben, sind <strong>Farbnamen</strong>. CSS kennt 148 davon – von <code>red</code> über
                    <code>tomato</code> bis <code>papayawhip</code>.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <p class="a">tomato auf ivory</p>
                        <p class="b">white auf rebeccapurple</p>
                        <p class="c">midnightblue auf lightskyblue</p>
                        """,
                    Css = """
                        .a {
                          color: tomato;
                          background-color: ivory;
                        }

                        .b {
                          color: white;
                          background-color: rebeccapurple;
                        }

                        .c {
                          color: midnightblue;
                          background-color: lightskyblue;
                        }
                        """,
                    PreviewHeight = 180,
                },
            },
            new()
            {
                Title = "Hex-Codes",
                Body = """
                    <p>Hex-Codes sind die verbreitetste Schreibweise im Webdesign. Sie beginnen mit <code>#</code>, gefolgt von drei Zahlenpaaren für
                    <strong>Rot</strong>, <strong>Grün</strong> und <strong>Blau</strong> – im Sechzehnersystem von <code>00</code> (nichts) bis <code>ff</code> (voll).</p>
                    <ul>
                      <li><code>#ff0000</code> – reines Rot</li>
                      <li><code>#000000</code> – Schwarz, <code>#ffffff</code> – Weiß</li>
                      <li><code>#3b2a20</code> – ein dunkles Kaffeebraun</li>
                    </ul>
                    <p>Bestehen alle Paare aus gleichen Ziffern, gibt es eine Kurzform: <code>#ff6600</code> → <code>#f60</code>.</p>
                    <p>Farben aus einem Design-Programm oder einem Farbwähler bekommst du fast immer als Hex-Code.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="farbe eins">#e63946</div>
                        <div class="farbe zwei">#f1faee</div>
                        <div class="farbe drei">#1d3557</div>
                        """,
                    Css = """
                        .farbe {
                          padding: 12px;
                          font-family: monospace;
                        }

                        .eins { background-color: #e63946; color: #fff; }
                        .zwei { background-color: #f1faee; color: #1d3557; }
                        .drei { background-color: #1d3557; color: #f1faee; }
                        """,
                    PreviewHeight = 170,
                },
            },
            new()
            {
                Title = "rgb() und hsl()",
                Body = """
                    <p><code>rgb(rot grün blau)</code> beschreibt dieselben drei Kanäle mit Dezimalzahlen von 0 bis 255: <code>rgb(255 0 0)</code> ist Rot.</p>
                    <p><code>hsl(farbton sättigung helligkeit)</code> ist oft intuitiver:</p>
                    <ul>
                      <li><strong>Farbton</strong> (hue) als Winkel auf dem Farbkreis: 0 = Rot, 120 = Grün, 240 = Blau</li>
                      <li><strong>Sättigung</strong> in Prozent: 0&nbsp;% = grau, 100&nbsp;% = kräftig</li>
                      <li><strong>Helligkeit</strong> in Prozent: 0&nbsp;% = schwarz, 50&nbsp;% = normal, 100&nbsp;% = weiß</li>
                    </ul>
                    <p>Mit hsl kannst du leicht hellere oder dunklere Varianten <em>derselben</em> Farbe bauen – ändere im Beispiel nur die letzte Zahl!</p>
                    <div class="tip">Du siehst manchmal auch die ältere Schreibweise mit Kommas: <code>rgb(255, 0, 0)</code>. Beide funktionieren.</div>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="box hell">hsl(200 70% 85%)</div>
                        <div class="box mittel">hsl(200 70% 50%)</div>
                        <div class="box dunkel">hsl(200 70% 25%)</div>
                        """,
                    Css = """
                        .box {
                          padding: 12px;
                          color: white;
                        }

                        .hell   { background-color: hsl(200 70% 85%); color: black; }
                        .mittel { background-color: hsl(200 70% 50%); }
                        .dunkel { background-color: hsl(200 70% 25%); }
                        """,
                    PreviewHeight = 170,
                },
            },
            new()
            {
                Title = "Transparenz",
                Body = """
                    <p>Ein vierter Wert, der <strong>Alpha-Kanal</strong>, steuert die Deckkraft von 0 (unsichtbar) bis 1 (deckend).
                    Er wird mit einem Schrägstrich angehängt: <code>rgb(0 0 0 / 0.5)</code> ist halbtransparentes Schwarz.
                    Bei Hex-Codes geht das mit einem vierten Paar: <code>#00000080</code>.</p>
                    <p>Im Gegensatz dazu macht <code>opacity: 0.5;</code> das <em>ganze</em> Element samt Text durchsichtig.</p>
                    <div class="tip"><strong>Kontrast:</strong> Text muss sich deutlich vom Hintergrund abheben. Helles Grau auf Weiß sieht vielleicht elegant aus, ist aber für viele Menschen kaum lesbar.</div>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="bild">
                          <p class="alpha">Hintergrund mit Alpha</p>
                          <p class="opac">Ganzes Element mit opacity</p>
                        </div>
                        """,
                    Css = """
                        .bild {
                          background-color: orange;
                          padding: 16px;
                        }

                        .alpha {
                          background-color: rgb(0 0 0 / 0.5);
                          color: white;
                        }

                        .opac {
                          background-color: black;
                          color: white;
                          opacity: 0.5;
                        }
                        """,
                    PreviewHeight = 170,
                },
            },
        ],
        Exercises =
        [
            new()
            {
                Id = "l03-e1",
                Title = "Ampel",
                Task = """
                    <p>Gib den drei Lichtern ihre Hintergrundfarben – jedes Mal in einer anderen Schreibweise:</p>
                    <ul>
                      <li><code>.rot</code>: Hex-Code <code>#e53935</code></li>
                      <li><code>.gelb</code>: <code>rgb(253 216 53)</code></li>
                      <li><code>.gruen</code>: <code>hsl(122 39% 49%)</code></li>
                    </ul>
                    """,
                Html = """
                    <div class="ampel">
                      <div class="licht rot"></div>
                      <div class="licht gelb"></div>
                      <div class="licht gruen"></div>
                    </div>
                    """,
                StarterCss = """
                    .ampel {
                      background-color: #333;
                      width: 70px;
                      padding: 8px;
                    }

                    .licht {
                      width: 50px;
                      height: 50px;
                      margin: 10px;
                      border-radius: 50%;
                      background-color: #555;
                    }

                    /* Deine Farben hier */

                    """,
                SolutionCss = """
                    .ampel {
                      background-color: #333;
                      width: 70px;
                      padding: 8px;
                    }

                    .licht {
                      width: 50px;
                      height: 50px;
                      margin: 10px;
                      border-radius: 50%;
                      background-color: #555;
                    }

                    .rot { background-color: #e53935; }
                    .gelb { background-color: rgb(253 216 53); }
                    .gruen { background-color: hsl(122 39% 49%); }
                    """,
                Checks =
                [
                    Check.Style("Rotes Licht: #e53935", ".rot", "background-color", "#e53935"),
                    Check.Style("Gelbes Licht: rgb(253 216 53)", ".gelb", "background-color", "rgb(253 216 53)"),
                    Check.Style("Grünes Licht: hsl(122 39% 49%)", ".gruen", "background-color", "hsl(122 39% 49%)"),
                ],
                PreviewHeight = 260,
            },
            new()
            {
                Id = "l03-e2",
                Title = "Halbtransparentes Overlay",
                Task = """
                    <p>Über dem farbigen Bereich liegt ein Text-Overlay. Gib <code>.overlay</code> einen <strong>schwarzen Hintergrund mit 60&nbsp;% Deckkraft</strong>
                    und weiße Schrift. Der Text selbst soll dabei voll deckend bleiben – verwende also <em>nicht</em> <code>opacity</code>.</p>
                    """,
                Html = """
                    <div class="foto">
                      <p class="overlay">Sonnenuntergang am Meer</p>
                    </div>
                    """,
                StarterCss = """
                    .foto {
                      background-color: coral;
                      padding: 60px 20px 20px;
                    }

                    .overlay {
                      padding: 10px;
                    }
                    """,
                SolutionCss = """
                    .foto {
                      background-color: coral;
                      padding: 60px 20px 20px;
                    }

                    .overlay {
                      padding: 10px;
                      background-color: rgb(0 0 0 / 0.6);
                      color: white;
                    }
                    """,
                Hint = "rgb(0 0 0 / 0.6) ist Schwarz mit 60 % Deckkraft.",
                Checks =
                [
                    Check.Style("Hintergrund: Schwarz mit 60 % Deckkraft", ".overlay", "background-color", "rgb(0 0 0 / 0.6)"),
                    Check.Style("Text ist weiß.", ".overlay", "color", "white"),
                    Check.Style("Das Element selbst ist nicht transparent (opacity 1).", ".overlay", "opacity", "1"),
                ],
                PreviewHeight = 180,
            },
        ],
        Project = new()
        {
            Id = "l03-projekt",
            Task = """
                <p>Zeit für das Farbkonzept des Cafés: warme Kaffee- und Cremetöne.</p>
                <ol>
                  <li><code>body</code>: Textfarbe <code>#3b2a20</code>, Hintergrund <code>#fffaf3</code></li>
                  <li><code>.site-header</code> und <code>.site-footer</code>: Hintergrund <code>#3b2a20</code></li>
                  <li>Logo, Navigationslinks und der Text im Footer (<code>.site-footer p</code>): Farbe <code>#fffaf3</code></li>
                  <li><code>.hero</code>: Hintergrund <code>#f3e3cf</code></li>
                  <li><code>.section-alt</code>: Hintergrund <code>#f7efe5</code></li>
                  <li>Überschriften <code>h1</code> und Preise <code>.price</code>: Farbe <code>#a0522d</code></li>
                </ol>
                <p>Tipp: Nutze Gruppierungen, wo mehrere Elemente dieselbe Farbe bekommen.</p>
                """,
            AddedCss = """
                body {
                  color: #3b2a20;
                  background-color: #fffaf3;
                }

                .site-header,
                .site-footer {
                  background-color: #3b2a20;
                }

                .logo,
                .main-nav a,
                .site-footer p {
                  color: #fffaf3;
                }

                .hero {
                  background-color: #f3e3cf;
                }

                .section-alt {
                  background-color: #f7efe5;
                }

                h1,
                .price {
                  color: #a0522d;
                }
                """,
            Checks =
            [
                Check.Style("body: Textfarbe #3b2a20", "body", "color", "#3b2a20"),
                Check.Style("body: Hintergrund #fffaf3", "body", "background-color", "#fffaf3"),
                Check.Style("Header: Hintergrund #3b2a20", ".site-header", "background-color", "#3b2a20"),
                Check.Style("Footer: Hintergrund #3b2a20", ".site-footer", "background-color", "#3b2a20"),
                Check.Style("Logo: Farbe #fffaf3", ".logo", "color", "#fffaf3"),
                Check.Style("Navigationslinks: Farbe #fffaf3", ".main-nav a", "color", "#fffaf3"),
                Check.Style("Footer-Text: Farbe #fffaf3", ".site-footer p", "color", "#fffaf3"),
                Check.Style("Hero: Hintergrund #f3e3cf", ".hero", "background-color", "#f3e3cf"),
                Check.Style("Abwechselnde Abschnitte: Hintergrund #f7efe5", ".section-alt", "background-color", "#f7efe5"),
                Check.Style("h1: Farbe #a0522d", "h1", "color", "#a0522d"),
                Check.Style("Preise: Farbe #a0522d", ".price", "color", "#a0522d"),
            ],
        },
    };
}
