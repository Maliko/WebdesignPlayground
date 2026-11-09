namespace CssPlayground.Content.Lessons;

public static class L06Boxmodell
{
    public static Lesson Create() => new()
    {
        Number = 6,
        Id = "boxmodell",
        Title = "Das Box-Modell",
        Summary = "Jedes Element ist eine Box: Inhalt, padding, border und margin.",
        Goals =
        [
            "Die vier Schichten des Box-Modells kennen",
            "Innen- und Außenabstände mit padding und margin setzen",
            "Rahmen mit border gestalten",
            "box-sizing: border-box verstehen und einsetzen",
            "Blöcke mit margin: auto zentrieren",
        ],
        Sections =
        [
            new()
            {
                Title = "Jedes Element ist eine Box",
                Body = """
                    <p>Für den Browser ist jedes Element ein Rechteck – eine <strong>Box</strong>. Diese Box besteht von innen nach außen aus:</p>
                    <div class="boxmodel-diagram">
                      <div class="bm-margin">margin
                        <div class="bm-border">border
                          <div class="bm-padding">padding
                            <div class="bm-content">Inhalt</div>
                          </div>
                        </div>
                      </div>
                    </div>
                    <ul>
                      <li><strong>Inhalt</strong> (content) – Text, Bilder usw. Größe über <code>width</code> und <code>height</code>.</li>
                      <li><strong>padding</strong> – Innenabstand zwischen Inhalt und Rahmen. Hat die Hintergrundfarbe des Elements.</li>
                      <li><strong>border</strong> – der Rahmen.</li>
                      <li><strong>margin</strong> – Außenabstand zu anderen Elementen. Immer durchsichtig.</li>
                    </ul>
                    <div class="tip">In den Entwicklertools deines Browsers (F12) siehst du das Box-Modell jedes Elements – sehr hilfreich bei der Fehlersuche!</div>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="box">Ich bin eine Box.</div>
                        <div class="box">Ich auch.</div>
                        """,
                    Css = """
                        .box {
                          width: 200px;
                          padding: 20px;
                          border: 5px solid steelblue;
                          margin: 15px;
                          background-color: lightblue;
                        }
                        """,
                    PreviewHeight = 240,
                },
            },
            new()
            {
                Title = "padding und margin: Kurzschreibweisen",
                Body = """
                    <p>Abstände kannst du für jede Seite einzeln setzen (<code>padding-top</code>, <code>margin-left</code> …) oder in Kurzform:</p>
                    <ul>
                      <li><code>padding: 10px;</code> – alle vier Seiten</li>
                      <li><code>padding: 10px 20px;</code> – oben/unten 10px, links/rechts 20px</li>
                      <li><code>padding: 5px 10px 15px 20px;</code> – oben, rechts, unten, links (im Uhrzeigersinn ab 12 Uhr)</li>
                    </ul>
                    <p>Für <code>margin</code> gilt das genauso.</p>
                    <div class="tip"><strong>Margin-Collapsing:</strong> Treffen die vertikalen Außenabstände zweier Blöcke aufeinander, werden sie nicht addiert – es gilt der größere.
                    Darum ist der Abstand zwischen zwei Absätzen mit je <code>margin: 16px 0</code> nur 16px, nicht 32px.</div>
                    """,
                Example = new()
                {
                    Html = """
                        <p class="a">padding: 10px</p>
                        <p class="b">padding: 10px 40px</p>
                        <p class="c">padding: 0 0 30px 60px</p>
                        """,
                    Css = """
                        p {
                          background-color: peachpuff;
                          margin: 8px 0;
                        }

                        .a { padding: 10px; }
                        .b { padding: 10px 40px; }
                        .c { padding: 0 0 30px 60px; }
                        """,
                    PreviewHeight = 200,
                },
            },
            new()
            {
                Title = "Rahmen: border",
                Body = """
                    <p>Ein Rahmen braucht drei Angaben: <strong>Breite</strong>, <strong>Stil</strong> und <strong>Farbe</strong>. Die Kurzform:</p>
                    <pre><code>border: 2px solid gray;</code></pre>
                    <p>Stile sind z.&nbsp;B. <code>solid</code>, <code>dashed</code>, <code>dotted</code> und <code>double</code>. Ohne Stil (oder mit <code>none</code>) ist kein Rahmen zu sehen!</p>
                    <p>Auch einzelne Seiten sind möglich: <code>border-bottom: 3px solid orange;</code> ergibt eine schöne Unterstreichung.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <p class="solid">solid</p>
                        <p class="dashed">dashed</p>
                        <p class="links">nur links</p>
                        """,
                    Css = """
                        p { padding: 8px; }

                        .solid  { border: 2px solid slategray; }
                        .dashed { border: 3px dashed tomato; }
                        .links  { border-left: 6px solid seagreen; background-color: honeydew; }
                        """,
                    PreviewHeight = 200,
                },
            },
            new()
            {
                Title = "box-sizing: border-box",
                Body = """
                    <p>Standardmäßig gilt <code>width</code> nur für den <strong>Inhalt</strong>. Padding und Rahmen kommen noch dazu:
                    Eine Box mit <code>width: 200px</code>, <code>padding: 20px</code> und <code>border: 5px</code> ist in Wirklichkeit 250px breit!</p>
                    <p>Mit <code>box-sizing: border-box</code> schließt <code>width</code> Padding und Rahmen ein – die Box ist genau so breit, wie du angibst.
                    Deshalb beginnen fast alle modernen Stylesheets mit:</p>
                    <pre><code>* {
                      box-sizing: border-box;
                    }</code></pre>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="box content-box">content-box: 250px breit</div>
                        <div class="box border-box">border-box: 200px breit</div>
                        """,
                    Css = """
                        .box {
                          width: 200px;
                          padding: 20px;
                          border: 5px solid darkorange;
                          margin-bottom: 10px;
                        }

                        .content-box { box-sizing: content-box; }
                        .border-box  { box-sizing: border-box; }
                        """,
                    PreviewHeight = 200,
                },
            },
            new()
            {
                Title = "Zentrieren mit margin: auto",
                Body = """
                    <p>Ein Block-Element mit fester Breite (oder <code>max-width</code>) lässt sich horizontal zentrieren, indem man den linken und rechten Außenabstand
                    auf <code>auto</code> setzt: Der Browser verteilt den freien Platz dann gleichmäßig.</p>
                    <pre><code>margin: 0 auto;</code></pre>
                    <p>Außerdem hat <code>body</code> standardmäßig einen Außenabstand von 8px – den setzt man meist mit <code>margin: 0</code> zurück.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="mitte">Ich bin zentriert.</div>
                        """,
                    Css = """
                        body { margin: 0; }

                        .mitte {
                          max-width: 250px;
                          margin: 20px auto;
                          padding: 16px;
                          background-color: plum;
                        }
                        """,
                    PreviewHeight = 130,
                },
            },
        ],
        Exercises =
        [
            new()
            {
                Id = "l06-e1",
                Title = "Eine Hinweisbox",
                Task = """
                    <p>Gestalte <code>.hinweis</code> als Box:</p>
                    <ul>
                      <li>Innenabstand <code>16px</code> rundherum</li>
                      <li>Linker Rahmen: <code>5px solid goldenrod</code></li>
                      <li>Außenabstand oben und unten <code>20px</code>, links und rechts <code>0</code></li>
                    </ul>
                    """,
                Html = """
                    <p>Ein ganz normaler Absatz.</p>
                    <div class="hinweis">Achtung: Die Bibliothek ist am Montag geschlossen.</div>
                    <p>Noch ein Absatz.</p>
                    """,
                StarterCss = """
                    .hinweis {
                      background-color: lightyellow;
                    }
                    """,
                SolutionCss = """
                    .hinweis {
                      background-color: lightyellow;
                      padding: 16px;
                      border-left: 5px solid goldenrod;
                      margin: 20px 0;
                    }
                    """,
                Checks =
                [
                    Check.Style("Innenabstand oben 16px", ".hinweis", "padding-top", "16px"),
                    Check.Style("Innenabstand links 16px", ".hinweis", "padding-left", "16px"),
                    Check.Style("Linker Rahmen 5px breit", ".hinweis", "border-left-width", "5px"),
                    Check.Style("Linker Rahmen durchgezogen", ".hinweis", "border-left-style", "solid"),
                    Check.Style("Linker Rahmen goldenrod", ".hinweis", "border-left-color", "goldenrod"),
                    Check.Style("Kein Rahmen oben", ".hinweis", "border-top-style", "none"),
                    Check.Style("Außenabstand oben 20px", ".hinweis", "margin-top", "20px"),
                    Check.Style("Außenabstand links 0", ".hinweis", "margin-left", "0px"),
                ],
                PreviewHeight = 220,
            },
            new()
            {
                Id = "l06-e2",
                Title = "Zentrierte Karte",
                Task = """
                    <p>Die Karte soll <strong>genau 300px breit</strong> sein (inklusive Padding und Rahmen) und horizontal zentriert werden.</p>
                    <ul>
                      <li>Verwende <code>box-sizing: border-box</code></li>
                      <li>Zentriere mit <code>margin</code></li>
                    </ul>
                    """,
                Html = """
                    <div class="karte">
                      <h3>Max Mustermann</h3>
                      <p>Webdesigner aus Leidenschaft</p>
                    </div>
                    """,
                StarterCss = """
                    .karte {
                      width: 300px;
                      padding: 24px;
                      border: 2px solid #ccc;
                      background-color: white;
                    }
                    """,
                SolutionCss = """
                    .karte {
                      width: 300px;
                      padding: 24px;
                      border: 2px solid #ccc;
                      background-color: white;
                      box-sizing: border-box;
                      margin: 0 auto;
                    }
                    """,
                Checks =
                [
                    Check.Js("Die Karte ist insgesamt 300px breit.", "const w = h.rect('.karte').width; return Math.abs(w - 300) < 1 || `Die Karte ist aktuell ${Math.round(w)}px breit.`;"),
                    Check.Js("Die Karte ist horizontal zentriert.",
                        "const r = h.rect('.karte'); const pw = doc.body.getBoundingClientRect(); const left = r.left - pw.left; const right = pw.right - r.right; return (left > 5 && Math.abs(left - right) < 2) || 'Links und rechts ist noch nicht gleich viel Platz.';"),
                ],
                PreviewHeight = 200,
            },
        ],
        Project = new()
        {
            Id = "l06-projekt",
            Task = """
                <p>Die Café-Seite braucht Luft zum Atmen!</p>
                <ol>
                  <li>Setze für alle Elemente (<code>*</code>) <code>box-sizing: border-box</code>.</li>
                  <li>Entferne den Außenabstand des <code>body</code> (<code>margin: 0</code>).</li>
                  <li>Zentriere <code>.container</code> mit <code>margin: 0 auto</code>.</li>
                  <li>Gib jedem <code>.section</code> einen Innenabstand von <code>64px</code> oben und unten (links/rechts 0).</li>
                  <li>Der <code>.hero</code> bekommt oben und unten <code>96px</code> Innenabstand.</li>
                  <li>Die Karten (<code>.card</code>): Innenabstand <code>24px</code>, Rahmen <code>1px solid #e0d2c0</code>, Hintergrund <code>white</code>
                      und <code>16px</code> Außenabstand unten.</li>
                </ol>
                """,
            AddedCss = """
                * {
                  box-sizing: border-box;
                }

                body {
                  margin: 0;
                }

                .container {
                  margin: 0 auto;
                }

                .section {
                  padding: 64px 0;
                }

                .hero {
                  padding: 96px 0;
                }

                .card {
                  padding: 24px;
                  border: 1px solid #e0d2c0;
                  background-color: white;
                  margin-bottom: 16px;
                }
                """,
            Checks =
            [
                Check.Style("box-sizing: border-box für alle Elemente", ".card p", "box-sizing", "border-box"),
                Check.Style("body hat keinen Außenabstand", "body", "margin-top", "0px"),
                Check.Js(".container ist zentriert",
                    "const c = h.rect('#ueber-uns .container'); const w = doc.documentElement.clientWidth; return Math.abs(c.left - (w - c.right)) < 2 || 'Links und rechts vom Container ist unterschiedlich viel Platz.';"),
                Check.Style(".section: 64px Innenabstand oben", ".section", "padding-top", "64px"),
                Check.Style(".section: 64px Innenabstand unten", ".section", "padding-bottom", "64px"),
                Check.Style(".hero: 96px Innenabstand oben", ".hero", "padding-top", "96px"),
                Check.Style(".card: 24px Innenabstand", ".card", "padding-left", "24px"),
                Check.Style(".card: Rahmen 1px", ".card", "border-top-width", "1px"),
                Check.Style(".card: Rahmenfarbe #e0d2c0", ".card", "border-top-color", "#e0d2c0"),
                Check.Style(".card: weißer Hintergrund", ".card", "background-color", "white"),
                Check.Style(".card: 16px Abstand unten", ".card", "margin-bottom", "16px"),
            ],
        },
    };
}
