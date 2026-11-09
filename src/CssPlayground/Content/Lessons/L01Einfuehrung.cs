namespace CssPlayground.Content.Lessons;

public static class L01Einfuehrung
{
    public static Lesson Create() => new()
    {
        Number = 1,
        Id = "einfuehrung",
        Title = "Was ist CSS?",
        Summary = "Wie CSS und HTML zusammenarbeiten und wie eine CSS-Regel aufgebaut ist.",
        Goals =
        [
            "Verstehen, wofür CSS da ist und wie es sich von HTML unterscheidet",
            "Die drei Wege kennen, CSS in eine Seite einzubinden",
            "Den Aufbau einer CSS-Regel (Selektor, Eigenschaft, Wert) beherrschen",
            "Kommentare in CSS schreiben",
        ],
        Sections =
        [
            new()
            {
                Title = "HTML für den Inhalt, CSS für das Aussehen",
                Body = """
                    <p>Mit HTML beschreibst du, <strong>was</strong> auf einer Seite steht: Überschriften, Absätze, Listen, Links.
                    CSS (<em>Cascading Style Sheets</em>) bestimmt, <strong>wie</strong> es aussieht: Farben, Schriften, Abstände, Layout.</p>
                    <p>Diese Trennung hat einen großen Vorteil: Du kannst das komplette Aussehen einer Webseite ändern, ohne das HTML anzufassen.</p>
                    <p>Unten siehst du dein erstes interaktives Beispiel. Links oben steht das HTML, darunter das CSS, rechts die Live-Vorschau.
                    <strong>Ändere ruhig etwas</strong> – zum Beispiel <code>navy</code> in <code>crimson</code> – und sieh zu, wie sich die Vorschau sofort anpasst.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <h1>Hallo CSS!</h1>
                        <p>Dieser Absatz wird gleich gestaltet.</p>
                        """,
                    Css = """
                        h1 {
                          color: navy;
                        }

                        p {
                          color: gray;
                          font-size: 20px;
                        }
                        """,
                },
            },
            new()
            {
                Title = "Aufbau einer CSS-Regel",
                Body = """
                    <p>Jede CSS-Regel besteht aus zwei Teilen:</p>
                    <pre><code>selektor {
                      eigenschaft: wert;
                      eigenschaft: wert;
                    }</code></pre>
                    <ul>
                      <li>Der <strong>Selektor</strong> legt fest, <em>welche</em> Elemente gestaltet werden (z.&nbsp;B. <code>h1</code> für alle Hauptüberschriften).</li>
                      <li>In den geschweiften Klammern stehen <strong>Deklarationen</strong>. Jede Deklaration ist ein Paar aus <strong>Eigenschaft</strong> und <strong>Wert</strong>, getrennt durch einen Doppelpunkt.</li>
                      <li>Jede Deklaration endet mit einem <strong>Semikolon</strong>.</li>
                    </ul>
                    <div class="tip"><strong>Typischer Fehler:</strong> Ein vergessenes Semikolon oder eine fehlende Klammer. Der Browser ignoriert dann die fehlerhafte Deklaration – oft auch die nächste. Wenn etwas nicht wirkt, prüfe zuerst die Satzzeichen!</div>
                    <p>Probiere es aus: Lösche im Beispiel das Semikolon hinter <code>color: white</code> und beobachte, was mit der Hintergrundfarbe passiert.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <p class="hinweis">Ein Hinweis mit Hintergrund.</p>
                        """,
                    Css = """
                        p {
                          color: white;
                          background-color: teal;
                          padding: 12px;
                        }
                        """,
                    PreviewHeight = 140,
                },
            },
            new()
            {
                Title = "Drei Wege, CSS einzubinden",
                Body = """
                    <p><strong>1. Externe Datei</strong> – der Normalfall. Im <code>&lt;head&gt;</code> wird eine CSS-Datei verlinkt; alle Seiten der Website können sie gemeinsam nutzen:</p>
                    <pre><code>&lt;link rel="stylesheet" href="style.css"&gt;</code></pre>
                    <p><strong>2. Im <code>&lt;style&gt;</code>-Element</strong> – das CSS steht direkt im <code>&lt;head&gt;</code> der Seite. Praktisch für einzelne Seiten oder zum Ausprobieren.
                    (Genau so funktionieren übrigens die Beispiele hier: Dein CSS landet in einem <code>&lt;style&gt;</code>-Element der Vorschau.)</p>
                    <p><strong>3. Inline mit dem <code>style</code>-Attribut</strong> – direkt am Element. Das ist schwer zu warten und sollte die Ausnahme bleiben:</p>
                    <pre><code>&lt;p style="color: red;"&gt;Achtung!&lt;/p&gt;</code></pre>
                    <p>Im Beispiel siehst du: Das <code>style</code>-Attribut gewinnt gegen die Regel im Stylesheet. Warum das so ist, lernst du in der Lektion zur Kaskade.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <p>Ich bin blau – das kommt aus dem Stylesheet.</p>
                        <p style="color: red;">Ich bin rot – dank style-Attribut.</p>
                        """,
                    Css = """
                        p {
                          color: blue;
                        }
                        """,
                    PreviewHeight = 140,
                },
            },
            new()
            {
                Title = "Kommentare",
                Body = """
                    <p>Kommentare werden vom Browser ignoriert. Sie helfen dir (und anderen), den Code später zu verstehen.
                    In CSS stehen sie zwischen <code>/*</code> und <code>*/</code> und dürfen über mehrere Zeilen gehen.</p>
                    <p>Ein praktischer Trick: Du kannst eine Deklaration „auskommentieren“, um zu sehen, was sie bewirkt. Probiere es im Beispiel mit der Zeile <code>font-style: italic;</code>.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <p>Ein Zitat sollte kursiv sein.</p>
                        """,
                    Css = """
                        /* Gestaltung für alle Absätze */
                        p {
                          color: darkslategray;
                          font-style: italic; /* schräg gestellt */
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
                Id = "l01-e1",
                Title = "Deine erste Regel",
                Task = """
                    <p>Schreibe eine Regel für alle <code>h1</code>-Überschriften und gib ihnen die Textfarbe <code>darkgreen</code>.</p>
                    """,
                Html = """
                    <h1>Mein Garten</h1>
                    <p>Hier wachsen Tomaten, Kräuter und Sonnenblumen.</p>
                    """,
                StarterCss = """
                    /* Schreibe deine Regel hier */

                    """,
                SolutionCss = """
                    h1 {
                      color: darkgreen;
                    }
                    """,
                Hint = "Selektor ist der Elementname h1, die Eigenschaft für die Textfarbe heißt color.",
                Checks =
                [
                    Check.Style("Die Überschrift ist dunkelgrün (darkgreen).", "h1", "color", "darkgreen"),
                ],
            },
            new()
            {
                Id = "l01-e2",
                Title = "Fehlersuche",
                Task = """
                    <p>Dieses CSS enthält zwei Fehler, weshalb der Absatz weder orange noch groß ist. Finde und behebe sie!</p>
                    <p>Ziel: Der Absatz soll die Farbe <code>darkorange</code> und die Schriftgröße <code>24px</code> haben.</p>
                    """,
                Html = """
                    <p>Fehler finden macht Spaß!</p>
                    """,
                StarterCss = """
                    p {
                      color darkorange;
                      font-size: 24px
                      font-weight: bold;
                    """,
                SolutionCss = """
                    p {
                      color: darkorange;
                      font-size: 24px;
                      font-weight: bold;
                    }
                    """,
                Hint = "Achte auf den Doppelpunkt zwischen Eigenschaft und Wert, auf Semikolons am Zeilenende und auf die schließende Klammer.",
                Checks =
                [
                    Check.Style("Der Absatz ist orange (darkorange).", "p", "color", "darkorange"),
                    Check.Style("Der Absatz hat die Schriftgröße 24px.", "p", "font-size", "24px"),
                ],
                PreviewHeight = 140,
            },
        ],
        Project = new()
        {
            Id = "l01-projekt",
            Task = """
                <p>Willkommen beim Kursprojekt! In jeder Lektion gestaltest du ein Stück der Webseite des <strong>Café Kaffeebohne</strong>.
                Das HTML ist schon fertig – du schreibst nur CSS. Im Moment sieht die Seite noch aus wie ein Dokument aus den 90ern. Das ändern wir!</p>
                <p>Dein erster Schritt:</p>
                <ol>
                  <li>Gib dem <code>body</code> die Schriftart <code>sans-serif</code> (Eigenschaft <code>font-family</code>).</li>
                  <li>Färbe alle <code>h1</code>-Überschriften in <code>saddlebrown</code>.</li>
                </ol>
                <p>Dein CSS wird automatisch gespeichert und in die nächste Lektion übernommen.</p>
                """,
            AddedCss = """
                body {
                  font-family: sans-serif;
                }

                h1 {
                  color: saddlebrown;
                }
                """,
            Hint = "Du brauchst zwei Regeln: eine mit dem Selektor body und eine mit h1.",
            Checks =
            [
                Check.Contains("Der body nutzt eine serifenlose Schrift (sans-serif).", "body", "font-family", "sans-serif"),
                Check.Style("Die h1-Überschrift ist saddlebrown.", "h1", "color", "saddlebrown"),
            ],
        },
    };
}
