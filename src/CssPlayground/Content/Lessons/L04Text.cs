namespace CssPlayground.Content.Lessons;

public static class L04Text
{
    public static Lesson Create() => new()
    {
        Number = 4,
        Id = "text",
        Title = "Text und Schrift",
        Summary = "Schriftarten, Größen, Zeilenhöhe, Ausrichtung und weitere Texteigenschaften.",
        Goals =
        [
            "Schriftarten mit Fallbacks angeben (font-family)",
            "Schriftgröße, -stärke und -stil festlegen",
            "Zeilenhöhe und Ausrichtung für gute Lesbarkeit einstellen",
            "Texte mit text-transform, text-decoration und letter-spacing verfeinern",
        ],
        Sections =
        [
            new()
            {
                Title = "Schriftarten: font-family",
                Body = """
                    <p>Mit <code>font-family</code> legst du die Schrift fest. Da nicht jede Schrift auf jedem Gerät installiert ist,
                    gibst du eine <strong>Liste</strong> an. Der Browser nimmt die erste, die verfügbar ist:</p>
                    <pre><code>font-family: "Segoe UI", Arial, sans-serif;</code></pre>
                    <ul>
                      <li>Namen mit Leerzeichen gehören in Anführungszeichen.</li>
                      <li>Am Ende steht immer eine <strong>generische Familie</strong> als Notlösung:
                          <code>serif</code> (mit Füßchen), <code>sans-serif</code> (ohne), <code>monospace</code> (gleiche Breite), <code>cursive</code>.</li>
                    </ul>
                    <div class="tip">Schriften von Diensten wie Google Fonts bindet man mit einem <code>&lt;link&gt;</code> im HTML-Kopf ein und kann sie danach ganz normal per <code>font-family</code> verwenden.</div>
                    """,
                Example = new()
                {
                    Html = """
                        <p class="serif">Serif: Georgia oder Times</p>
                        <p class="sans">Sans-Serif: Arial oder Helvetica</p>
                        <p class="mono">Monospace: Courier für Code</p>
                        <p class="cursive">Cursive: verspielte Schrift</p>
                        """,
                    Css = """
                        p { font-size: 20px; }

                        .serif   { font-family: Georgia, "Times New Roman", serif; }
                        .sans    { font-family: Arial, Helvetica, sans-serif; }
                        .mono    { font-family: "Courier New", monospace; }
                        .cursive { font-family: "Comic Sans MS", cursive; }
                        """,
                },
            },
            new()
            {
                Title = "Größe, Stärke und Stil",
                Body = """
                    <ul>
                      <li><code>font-size</code> – die Schriftgröße, z.&nbsp;B. <code>18px</code>. Standard im Browser sind <code>16px</code>.</li>
                      <li><code>font-weight</code> – die Stärke: <code>normal</code> (= 400), <code>bold</code> (= 700) oder Zahlen von 100 bis 900.</li>
                      <li><code>font-style</code> – <code>italic</code> für kursiv, <code>normal</code> für aufrecht.</li>
                    </ul>
                    <p>Ob Zwischenstufen wie 300 oder 600 sichtbar sind, hängt davon ab, ob die Schrift diese Schnitte mitbringt.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <p class="klein">Kleiner Text (14px)</p>
                        <p class="gross">Großer Text (28px)</p>
                        <p class="fett">Fetter Text</p>
                        <p class="kursiv">Kursiver Text</p>
                        """,
                    Css = """
                        body { font-family: Arial, sans-serif; }

                        .klein  { font-size: 14px; }
                        .gross  { font-size: 28px; }
                        .fett   { font-weight: bold; }
                        .kursiv { font-style: italic; }
                        """,
                },
            },
            new()
            {
                Title = "Zeilenhöhe und Ausrichtung",
                Body = """
                    <p>Für gut lesbare Fließtexte ist die <strong>Zeilenhöhe</strong> entscheidend. <code>line-height</code> wird am besten
                    <strong>ohne Einheit</strong> angegeben – der Wert ist dann ein Faktor der Schriftgröße. Werte zwischen <code>1.4</code> und <code>1.7</code> sind für Fließtext angenehm.</p>
                    <p><code>text-align</code> richtet Text aus: <code>left</code>, <code>center</code>, <code>right</code> oder <code>justify</code> (Blocksatz).</p>
                    <p>Vergleiche die beiden Absätze und ändere die Werte für <code>line-height</code>.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <p class="eng">Eng gesetzter Text ist auf Dauer anstrengend zu lesen, weil das Auge beim Zeilenwechsel leicht die Orientierung verliert und in der falschen Zeile landet.</p>
                        <p class="luftig">Luftig gesetzter Text lässt sich angenehm lesen, weil das Auge beim Zeilenwechsel leicht die nächste Zeile findet und der Text atmen kann.</p>
                        <h2>Zentrierte Überschrift</h2>
                        """,
                    Css = """
                        body {
                          font-family: Arial, sans-serif;
                          max-width: 420px;
                        }

                        .eng    { line-height: 1; }
                        .luftig { line-height: 1.7; }

                        h2 { text-align: center; }
                        """,
                    PreviewHeight = 280,
                },
            },
            new()
            {
                Title = "Weitere Texteigenschaften",
                Body = """
                    <ul>
                      <li><code>text-transform: uppercase;</code> – Großbuchstaben, ohne den HTML-Text zu ändern (auch <code>lowercase</code>, <code>capitalize</code>)</li>
                      <li><code>letter-spacing: 2px;</code> – Abstand zwischen den Buchstaben (schön bei Großbuchstaben)</li>
                      <li><code>text-decoration</code> – <code>underline</code>, <code>line-through</code> oder <code>none</code></li>
                      <li><code>text-indent</code> – Einzug der ersten Zeile</li>
                    </ul>
                    """,
                Example = new()
                {
                    Html = """
                        <p class="label">Neu eingetroffen</p>
                        <p class="kapitel">Es war einmal ein kleiner Text, der eingerückt beginnen wollte. Und so geschah es.</p>
                        """,
                    Css = """
                        body { font-family: Arial, sans-serif; }

                        .label {
                          text-transform: uppercase;
                          letter-spacing: 3px;
                          font-size: 13px;
                          color: darkcyan;
                        }

                        .kapitel {
                          text-indent: 24px;
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
                Id = "l04-e1",
                Title = "Ein Blogartikel",
                Task = """
                    <p>Mach den Artikel gut lesbar:</p>
                    <ul>
                      <li><code>article</code>: Schrift <code>Georgia, serif</code>, Schriftgröße <code>18px</code>, Zeilenhöhe <code>1.6</code></li>
                      <li><code>h1</code>: zentriert</li>
                      <li><code>.datum</code>: kursiv und in Großbuchstaben (<code>text-transform</code>)</li>
                    </ul>
                    """,
                Html = """
                    <article>
                      <h1>Der perfekte Sonntag</h1>
                      <p class="datum">12. Mai 2026</p>
                      <p>Ein guter Sonntag beginnt mit einem langen Frühstück. Danach ein Spaziergang durch den Park, am Nachmittag ein Buch auf dem Sofa und abends ein gemeinsames Essen mit Freunden.</p>
                    </article>
                    """,
                SolutionCss = """
                    article {
                      font-family: Georgia, serif;
                      font-size: 18px;
                      line-height: 1.6;
                    }

                    h1 {
                      text-align: center;
                    }

                    .datum {
                      font-style: italic;
                      text-transform: uppercase;
                    }
                    """,
                Checks =
                [
                    Check.Contains("Artikel nutzt Georgia.", "article", "font-family", "georgia"),
                    Check.Style("Artikel hat 18px Schriftgröße.", "article", "font-size", "18px"),
                    Check.Js("Zeilenhöhe des Artikels ist 1.6.",
                        "const lh = parseFloat(h.cs('article p:last-child', 'line-height')); const fs = parseFloat(h.cs('article p:last-child', 'font-size')); return Math.abs(lh / fs - 1.6) < 0.02 || 'Die Zeilenhöhe ist noch nicht 1.6.';"),
                    Check.Style("Überschrift ist zentriert.", "h1", "text-align", "center"),
                    Check.Style("Datum ist kursiv.", ".datum", "font-style", "italic"),
                    Check.Style("Datum in Großbuchstaben.", ".datum", "text-transform", "uppercase"),
                ],
                PreviewHeight = 300,
            },
        ],
        Project = new()
        {
            Id = "l04-projekt",
            Task = """
                <p>Jetzt bekommt das Café eine schöne Typografie:</p>
                <ol>
                  <li><code>body</code>: Schrift <code>"Segoe UI", Arial, sans-serif</code> und Zeilenhöhe <code>1.6</code></li>
                  <li><code>h1</code>: Schriftgröße <code>40px</code>, Zeilenhöhe <code>1.2</code></li>
                  <li><code>h2</code>: Schriftgröße <code>30px</code>, zentriert</li>
                  <li><code>.logo</code>: fett, Schriftgröße <code>20px</code></li>
                  <li><code>.hero-text</code>: Schriftgröße <code>19px</code></li>
                  <li>Die Navigationslinks (<code>.main-nav a</code>): Großbuchstaben mit <code>letter-spacing: 1px</code> und Schriftgröße <code>14px</code></li>
                </ol>
                <p>Du kannst bestehende Regeln ergänzen oder neue darunter schreiben.</p>
                """,
            AddedCss = """
                body {
                  font-family: "Segoe UI", Arial, sans-serif;
                  line-height: 1.6;
                }

                h1 {
                  font-size: 40px;
                  line-height: 1.2;
                }

                h2 {
                  font-size: 30px;
                  text-align: center;
                }

                .logo {
                  font-weight: bold;
                  font-size: 20px;
                }

                .hero-text {
                  font-size: 19px;
                }

                .main-nav a {
                  text-transform: uppercase;
                  letter-spacing: 1px;
                  font-size: 14px;
                }
                """,
            Checks =
            [
                Check.Contains("body nutzt Segoe UI.", "body", "font-family", "segoe ui"),
                Check.Contains("…mit Arial als Fallback.", "body", "font-family", "arial"),
                Check.Style("body hat Zeilenhöhe 1.6.", "body", "line-height", "25.6px"),
                Check.Style("h1 ist 40px groß.", "h1", "font-size", "40px"),
                Check.Style("h1 hat Zeilenhöhe 1.2 (48px).", "h1", "line-height", "48px"),
                Check.Style("h2 ist 30px groß.", "h2", "font-size", "30px"),
                Check.Style("h2 ist zentriert.", "h2", "text-align", "center"),
                Check.Style("Logo ist fett.", ".logo", "font-weight", "700"),
                Check.Style("Logo ist 20px groß.", ".logo", "font-size", "20px"),
                Check.Style("Hero-Text ist 19px groß.", ".hero-text", "font-size", "19px"),
                Check.Style("Navigation in Großbuchstaben.", ".main-nav a", "text-transform", "uppercase"),
                Check.Style("Navigation mit 1px Buchstabenabstand.", ".main-nav a", "letter-spacing", "1px"),
                Check.Style("Navigation ist 14px groß.", ".main-nav a", "font-size", "14px"),
            ],
        },
    };
}
