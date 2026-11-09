namespace CssPlayground.Content.Lessons;

public static class L13Effekte
{
    public static Lesson Create() => new()
    {
        Number = 13,
        Id = "effekte",
        Title = "Hintergründe, Ecken und Schatten",
        Summary = "Farbverläufe, Hintergrundbilder, abgerundete Ecken und Schatten für den letzten Schliff.",
        Goals =
        [
            "Farbverläufe mit linear-gradient und radial-gradient erstellen",
            "Hintergrundbilder einbinden und mit background-size steuern",
            "Ecken mit border-radius abrunden",
            "Schatten mit box-shadow und text-shadow einsetzen",
        ],
        Sections =
        [
            new()
            {
                Title = "Farbverläufe",
                Body = """
                    <p>Verläufe sind in CSS <strong>Bilder</strong> und werden daher über <code>background-image</code> (oder die Kurzform <code>background</code>) gesetzt:</p>
                    <ul>
                      <li><code>linear-gradient(to right, gold, tomato)</code> – linearer Verlauf in eine Richtung</li>
                      <li><code>linear-gradient(135deg, …)</code> – Richtung als Winkel</li>
                      <li><code>radial-gradient(circle, white, skyblue)</code> – kreisförmig von innen nach außen</li>
                    </ul>
                    <p>Du kannst beliebig viele Farben angeben, optional mit Positionen: <code>linear-gradient(red 0%, yellow 50%, green 100%)</code>.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="feld linear">linear</div>
                        <div class="feld winkel">135deg, drei Farben</div>
                        <div class="feld radial">radial</div>
                        """,
                    Css = """
                        .feld {
                          height: 60px;
                          margin-bottom: 8px;
                          padding: 8px;
                          color: white;
                          font-weight: bold;
                        }

                        .linear { background-image: linear-gradient(to right, gold, tomato); }
                        .winkel { background-image: linear-gradient(135deg, #667eea, #764ba2, #f64f59); }
                        .radial { background-image: radial-gradient(circle, white, skyblue); color: navy; }
                        """,
                    PreviewHeight = 240,
                },
            },
            new()
            {
                Title = "Hintergrundbilder",
                Body = """
                    <p>Ein Bild als Hintergrund bindest du mit <code>background-image: url("bild.jpg");</code> ein. Wichtige Begleiter:</p>
                    <ul>
                      <li><code>background-size: cover;</code> – Bild füllt die Fläche vollständig (wird ggf. beschnitten)</li>
                      <li><code>background-size: contain;</code> – Bild passt komplett hinein</li>
                      <li><code>background-position: center;</code> – Ausrichtung</li>
                      <li><code>background-repeat: no-repeat;</code> – keine Kachelung</li>
                    </ul>
                    <p>Ein Trick für lesbaren Text auf Fotos: Ein halbtransparenter Verlauf <em>über</em> dem Bild. Mehrere Hintergründe werden mit Komma getrennt – der erste liegt oben.
                    Im Beispiel ersetzt ein Muster aus Verläufen das Foto, damit es ohne Internetverbindung funktioniert.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="banner">Text auf Hintergrund</div>
                        """,
                    Css = """
                        .banner {
                          height: 140px;
                          display: flex;
                          align-items: flex-end;
                          padding: 16px;
                          color: white;
                          font-size: 22px;
                          background-image:
                            linear-gradient(to top, rgb(0 0 0 / 0.7), transparent),
                            repeating-linear-gradient(45deg, #2a9d8f 0 20px, #e9c46a 20px 40px);
                        }
                        """,
                    PreviewHeight = 180,
                },
            },
            new()
            {
                Title = "Abgerundete Ecken: border-radius",
                Body = """
                    <p><code>border-radius</code> rundet die Ecken eines Elements ab – auch ohne Rahmen.</p>
                    <ul>
                      <li><code>border-radius: 8px;</code> – sanft abgerundet</li>
                      <li><code>border-radius: 999px;</code> – „Pillenform“ für Buttons</li>
                      <li><code>border-radius: 50%;</code> – bei quadratischen Elementen ein Kreis</li>
                      <li><code>border-radius: 20px 0;</code> – oben links/unten rechts rund, die anderen eckig</li>
                    </ul>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="form sanft">8px</div>
                        <div class="form pille">Pille</div>
                        <div class="form kreis">50%</div>
                        <div class="form blatt">Blatt</div>
                        """,
                    Css = """
                        .form {
                          display: inline-flex;
                          align-items: center;
                          justify-content: center;
                          width: 90px;
                          height: 90px;
                          margin: 6px;
                          background-color: mediumslateblue;
                          color: white;
                        }

                        .sanft { border-radius: 8px; }
                        .pille { border-radius: 999px; width: 140px; height: 50px; }
                        .kreis { border-radius: 50%; }
                        .blatt { border-radius: 40px 0; }
                        """,
                    PreviewHeight = 140,
                },
            },
            new()
            {
                Title = "Schatten",
                Body = """
                    <p><code>box-shadow</code> wirft einen Schatten um die Box:</p>
                    <pre><code>box-shadow: x-versatz y-versatz unschärfe ausdehnung farbe;
                    box-shadow: 0 4px 12px rgb(0 0 0 / 0.15);</code></pre>
                    <p>Dezente, weiche Schatten (große Unschärfe, wenig Deckkraft) wirken modern; harte schwarze Schatten wirken schnell altbacken.
                    Mit dem Schlüsselwort <code>inset</code> fällt der Schatten nach innen.</p>
                    <p><code>text-shadow</code> funktioniert ähnlich für Text, nur ohne Ausdehnung: <code>text-shadow: 1px 1px 2px black;</code></p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="karte weich">Weicher Schatten</div>
                        <div class="karte hart">Harter Schatten</div>
                        <h2 class="glow">Leuchtender Text</h2>
                        """,
                    Css = """
                        body {
                          background-color: #f4f4f4;
                          padding: 10px;
                        }

                        .karte {
                          background-color: white;
                          padding: 20px;
                          margin-bottom: 16px;
                          border-radius: 8px;
                        }

                        .weich { box-shadow: 0 4px 12px rgb(0 0 0 / 0.15); }
                        .hart  { box-shadow: 4px 4px 0 black; }

                        .glow {
                          color: white;
                          text-shadow: 0 0 8px deeppink;
                        }
                        """,
                    PreviewHeight = 250,
                },
            },
        ],
        Exercises =
        [
            new()
            {
                Id = "l13-e1",
                Title = "Ein modernes Profil",
                Task = """
                    <p>Gestalte die Profilkarte:</p>
                    <ul>
                      <li><code>.karte</code>: Ecken mit <code>16px</code> Radius und ein weicher Schatten (<code>box-shadow</code>, beliebige Werte).</li>
                      <li><code>.kopf</code>: ein linearer Farbverlauf von <code>#ff9a9e</code> nach <code>#fad0c4</code>.</li>
                      <li><code>.avatar</code>: ein Kreis (<code>border-radius: 50%</code>).</li>
                    </ul>
                    """,
                Html = """
                    <div class="karte">
                      <div class="kopf"></div>
                      <div class="avatar">🙂</div>
                      <h3>Lena Lernfreudig</h3>
                      <p>Frontend-Entwicklerin</p>
                    </div>
                    """,
                StarterCss = """
                    body {
                      background-color: #eee;
                      padding: 20px;
                    }

                    .karte {
                      width: 260px;
                      background-color: white;
                      text-align: center;
                      overflow: hidden;
                      padding-bottom: 12px;
                    }

                    .kopf {
                      height: 80px;
                    }

                    .avatar {
                      width: 80px;
                      height: 80px;
                      margin: -40px auto 0;
                      background-color: #fff3e0;
                      border: 4px solid white;
                      font-size: 44px;
                      line-height: 80px;
                    }
                    """,
                SolutionCss = """
                    body {
                      background-color: #eee;
                      padding: 20px;
                    }

                    .karte {
                      width: 260px;
                      background-color: white;
                      text-align: center;
                      overflow: hidden;
                      padding-bottom: 12px;
                      border-radius: 16px;
                      box-shadow: 0 6px 20px rgb(0 0 0 / 0.12);
                    }

                    .kopf {
                      height: 80px;
                      background-image: linear-gradient(to right, #ff9a9e, #fad0c4);
                    }

                    .avatar {
                      width: 80px;
                      height: 80px;
                      margin: -40px auto 0;
                      background-color: #fff3e0;
                      border: 4px solid white;
                      font-size: 44px;
                      line-height: 80px;
                      border-radius: 50%;
                    }
                    """,
                Checks =
                [
                    Check.Style("Karte hat 16px Eckenradius.", ".karte", "border-top-left-radius", "16px"),
                    Check.NotStyle("Karte hat einen Schatten.", ".karte", "box-shadow", "none"),
                    Check.Contains("Kopf hat einen linearen Verlauf.", ".kopf", "background-image", "linear-gradient"),
                    Check.Js("Verlauf nutzt die angegebenen Farben.",
                        "const bg = h.cs('.kopf', 'background-image'); return (bg.includes(h.norm('color', '#ff9a9e')) && bg.includes(h.norm('color', '#fad0c4'))) || 'Verwende #ff9a9e und #fad0c4.';"),
                    Check.Style("Avatar ist rund.", ".avatar", "border-top-left-radius", "50%"),
                ],
                PreviewHeight = 300,
            },
        ],
        Project = new()
        {
            Id = "l13-projekt",
            Task = """
                <p>Der letzte optische Schliff für das Café:</p>
                <ol>
                  <li><code>.hero</code>: ein linearer Verlauf im Winkel <code>135deg</code> von <code>#f3e3cf</code> nach <code>#e2c4a0</code>.</li>
                  <li><code>.card</code>: Ecken mit <code>12px</code> Radius und ein weicher Schatten, z.&nbsp;B. <code>0 4px 12px rgb(0 0 0 / 0.08)</code>.</li>
                  <li><code>.button</code> und <code>.badge</code>: Pillenform mit <code>border-radius: 999px</code>.</li>
                  <li>Eingabefelder im Formular: Rahmen <code>1px solid #e0d2c0</code> und <code>6px</code> Eckenradius.</li>
                  <li>Der Button im Formular (<code>.contact-form button</code>) hat noch einen grauen Standardrahmen: entferne ihn mit <code>border: none</code> und setze <code>cursor: pointer</code>.</li>
                </ol>
                """,
            AddedCss = """
                .hero {
                  background-image: linear-gradient(135deg, #f3e3cf, #e2c4a0);
                }

                .card {
                  border-radius: 12px;
                  box-shadow: 0 4px 12px rgb(0 0 0 / 0.08);
                }

                .button,
                .badge {
                  border-radius: 999px;
                }

                .contact-form input,
                .contact-form textarea {
                  border: 1px solid #e0d2c0;
                  border-radius: 6px;
                }

                .contact-form button {
                  border: none;
                  cursor: pointer;
                }
                """,
            Checks =
            [
                Check.Contains("Hero hat einen linearen Verlauf", ".hero", "background-image", "linear-gradient(135deg"),
                Check.Js("Verlauf von #f3e3cf nach #e2c4a0",
                    "const bg = h.cs('.hero', 'background-image'); return (bg.includes(h.norm('color', '#f3e3cf')) && bg.includes(h.norm('color', '#e2c4a0'))) || 'Verwende #f3e3cf und #e2c4a0.';"),
                Check.Style("Karten haben 12px Eckenradius", ".card", "border-top-left-radius", "12px"),
                Check.NotStyle("Karten haben einen Schatten", ".card", "box-shadow", "none"),
                Check.AtLeast("Buttons sind pillenförmig", ".hero .button", "border-top-left-radius", "100px"),
                Check.AtLeast("Badge ist pillenförmig", ".badge", "border-top-left-radius", "100px"),
                Check.Style("Eingabefelder: Rahmenfarbe #e0d2c0", ".contact-form input", "border-top-color", "#e0d2c0"),
                Check.Style("Eingabefelder: 6px Eckenradius", ".contact-form textarea", "border-top-left-radius", "6px"),
                Check.Style("Formular-Button ohne Rahmen", ".contact-form button", "border-top-style", "none"),
                Check.Style("Formular-Button mit Zeiger-Cursor", ".contact-form button", "cursor", "pointer"),
            ],
        },
    };
}
