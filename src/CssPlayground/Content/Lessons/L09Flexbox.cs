namespace CssPlayground.Content.Lessons;

public static class L09Flexbox
{
    public static Lesson Create() => new()
    {
        Number = 9,
        Id = "flexbox",
        Title = "Flexbox",
        Summary = "Elemente in einer Reihe oder Spalte anordnen, verteilen und ausrichten.",
        Goals =
        [
            "Flex-Container und Flex-Items unterscheiden",
            "Hauptachse und Querachse verstehen (flex-direction)",
            "Elemente mit justify-content und align-items ausrichten",
            "Abstände mit gap setzen und Umbrüche mit flex-wrap erlauben",
            "Wachsen und Schrumpfen mit flex steuern",
        ],
        Sections =
        [
            new()
            {
                Title = "Der Flex-Container",
                Body = """
                    <p>Flexbox ist ein Layout-Werkzeug für <strong>eine Dimension</strong>: eine Reihe <em>oder</em> eine Spalte.
                    Du aktivierst es auf dem <strong>Elternelement</strong>:</p>
                    <pre><code>.container { display: flex; }</code></pre>
                    <p>Damit wird das Element zum <strong>Flex-Container</strong>, und seine direkten Kinder werden zu <strong>Flex-Items</strong>.
                    Diese stehen nun nebeneinander – ganz ohne <code>inline-block</code>.</p>
                    <p>Mit <code>gap</code> legst du den Abstand zwischen den Items fest.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="container">
                          <div class="item">1</div>
                          <div class="item">2</div>
                          <div class="item">3</div>
                        </div>
                        """,
                    Css = """
                        .container {
                          display: flex;
                          gap: 10px;
                          background-color: #eee;
                          padding: 10px;
                        }

                        .item {
                          background-color: cornflowerblue;
                          color: white;
                          padding: 20px;
                          font-size: 24px;
                        }
                        """,
                    PreviewHeight = 140,
                },
            },
            new()
            {
                Title = "Hauptachse ausrichten: justify-content",
                Body = """
                    <p>Flexbox kennt zwei Achsen. Die <strong>Hauptachse</strong> verläuft standardmäßig waagerecht (<code>flex-direction: row</code>).
                    Mit <code>flex-direction: column</code> wird sie senkrecht.</p>
                    <p><code>justify-content</code> verteilt die Items entlang der Hauptachse:</p>
                    <ul>
                      <li><code>flex-start</code> (Standard), <code>center</code>, <code>flex-end</code></li>
                      <li><code>space-between</code> – erstes Item ganz links, letztes ganz rechts, Rest gleichmäßig dazwischen</li>
                      <li><code>space-around</code> / <code>space-evenly</code> – gleichmäßiger Raum um die Items</li>
                    </ul>
                    <p>Probiere alle Werte im Beispiel aus!</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="container">
                          <div class="item">A</div>
                          <div class="item">B</div>
                          <div class="item">C</div>
                        </div>
                        """,
                    Css = """
                        .container {
                          display: flex;
                          justify-content: space-between;
                          background-color: #eee;
                          padding: 10px;
                        }

                        .item {
                          background-color: salmon;
                          padding: 16px 24px;
                        }
                        """,
                    PreviewHeight = 120,
                },
            },
            new()
            {
                Title = "Querachse ausrichten: align-items",
                Body = """
                    <p><code>align-items</code> richtet die Items auf der <strong>Querachse</strong> aus (bei einer Reihe also senkrecht):</p>
                    <ul>
                      <li><code>stretch</code> (Standard) – Items werden so hoch wie der Container</li>
                      <li><code>flex-start</code>, <code>center</code>, <code>flex-end</code></li>
                      <li><code>baseline</code> – an der Textgrundlinie</li>
                    </ul>
                    <div class="tip"><strong>Der berühmte Zentrier-Trick:</strong> <code>display: flex; justify-content: center; align-items: center;</code> zentriert ein Element horizontal <em>und</em> vertikal.</div>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="buehne">
                          <div class="star">Genau in der Mitte</div>
                        </div>
                        """,
                    Css = """
                        .buehne {
                          display: flex;
                          justify-content: center;
                          align-items: center;
                          height: 180px;
                          background-color: midnightblue;
                        }

                        .star {
                          background-color: gold;
                          padding: 12px 20px;
                        }
                        """,
                    PreviewHeight = 200,
                },
            },
            new()
            {
                Title = "Wachsen, Schrumpfen und Umbrechen",
                Body = """
                    <p>Items können den freien Platz unter sich aufteilen. Die Kurzform <code>flex</code> steuert das:</p>
                    <ul>
                      <li><code>flex: 1;</code> – das Item wächst und nimmt einen Anteil des freien Platzes. Zwei Items mit <code>flex: 1</code> und <code>flex: 2</code> teilen im Verhältnis 1:2.</li>
                      <li><code>flex: 0 0 200px;</code> – das Item bleibt fest 200px breit (wächst nicht, schrumpft nicht).</li>
                    </ul>
                    <p>Standardmäßig quetscht Flexbox alle Items in eine Zeile. Mit <code>flex-wrap: wrap;</code> dürfen sie in die nächste Zeile umbrechen.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="layout">
                          <aside class="sidebar">Seitenleiste (200px)</aside>
                          <main class="inhalt">Hauptinhalt (flex: 1)</main>
                        </div>
                        """,
                    Css = """
                        .layout {
                          display: flex;
                          gap: 10px;
                        }

                        .sidebar {
                          flex: 0 0 200px;
                          background-color: khaki;
                          padding: 12px;
                        }

                        .inhalt {
                          flex: 1;
                          background-color: lightgreen;
                          padding: 12px;
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
                Id = "l09-e1",
                Title = "Eine Kopfzeile",
                Task = """
                    <p>Baue mit Flexbox eine typische Kopfzeile:</p>
                    <ul>
                      <li><code>.kopf</code> wird zum Flex-Container.</li>
                      <li>Das Logo steht links, das Menü rechts (<code>justify-content</code>).</li>
                      <li>Beide sind vertikal zentriert (<code>align-items</code>).</li>
                      <li><code>.menu</code> ist selbst ein Flex-Container mit <code>gap: 16px</code>.</li>
                    </ul>
                    """,
                Html = """
                    <header class="kopf">
                      <div class="logo">🌿 GrünZeug</div>
                      <nav class="menu">
                        <a href="#">Pflanzen</a>
                        <a href="#">Töpfe</a>
                        <a href="#">Pflege</a>
                      </nav>
                    </header>
                    """,
                StarterCss = """
                    .kopf {
                      background-color: #2e7d32;
                      color: white;
                      padding: 12px 20px;
                    }

                    .logo {
                      font-size: 26px;
                    }

                    .menu a {
                      color: white;
                    }
                    """,
                SolutionCss = """
                    .kopf {
                      background-color: #2e7d32;
                      color: white;
                      padding: 12px 20px;
                      display: flex;
                      justify-content: space-between;
                      align-items: center;
                    }

                    .logo {
                      font-size: 26px;
                    }

                    .menu {
                      display: flex;
                      gap: 16px;
                    }

                    .menu a {
                      color: white;
                    }
                    """,
                Checks =
                [
                    Check.Style(".kopf ist ein Flex-Container.", ".kopf", "display", "flex"),
                    Check.Style("Logo links, Menü rechts (space-between).", ".kopf", "justify-content", "space-between"),
                    Check.Style("Vertikal zentriert.", ".kopf", "align-items", "center"),
                    Check.Style(".menu ist ein Flex-Container.", ".menu", "display", "flex"),
                    Check.Style("Menü-Abstand 16px.", ".menu", "column-gap", "16px"),
                ],
                PreviewHeight = 120,
            },
            new()
            {
                Id = "l09-e2",
                Title = "Flexible Spalten",
                Task = """
                    <p>Die drei Spalten sollen nebeneinander stehen (<code>gap: 12px</code>) und sich den Platz teilen.
                    Die mittlere Spalte (<code>.breit</code>) soll <strong>doppelt so breit</strong> werden wie die beiden anderen.</p>
                    """,
                Html = """
                    <div class="reihe">
                      <div class="spalte">Links</div>
                      <div class="spalte breit">Mitte (doppelt)</div>
                      <div class="spalte">Rechts</div>
                    </div>
                    """,
                StarterCss = """
                    .spalte {
                      background-color: lightcoral;
                      padding: 20px;
                      text-align: center;
                    }
                    """,
                SolutionCss = """
                    .reihe {
                      display: flex;
                      gap: 12px;
                    }

                    .spalte {
                      background-color: lightcoral;
                      padding: 20px;
                      text-align: center;
                      flex: 1;
                    }

                    .breit {
                      flex: 2;
                    }
                    """,
                Hint = "Gib allen Spalten flex: 1 und der breiten Spalte flex: 2. Das padding ist bei allen gleich, daher stimmt das Verhältnis nur ungefähr – das ist in Ordnung.",
                Checks =
                [
                    Check.Style(".reihe ist ein Flex-Container.", ".reihe", "display", "flex"),
                    Check.Style("Abstand 12px.", ".reihe", "column-gap", "12px"),
                    Check.Js("Die Spalten füllen die ganze Breite.",
                        "const r = h.rect('.reihe'); const s = h.qa('.spalte'); const last = s[2].getBoundingClientRect(); return Math.abs(last.right - r.right) < 2 || 'Die Spalten füllen noch nicht die ganze Zeile.';"),
                    Check.Js("Die mittlere Spalte ist etwa doppelt so breit.",
                        "const s = h.qa('.spalte').map(e => e.getBoundingClientRect().width); const ratio = s[1] / s[0]; return (ratio > 1.6 && ratio < 2.4) || `Verhältnis aktuell: ${ratio.toFixed(2)} : 1`;"),
                ],
                PreviewHeight = 120,
            },
        ],
        Project = new()
        {
            Id = "l09-projekt",
            Task = """
                <p>Jetzt bekommt der Kopfbereich des Cafés ein richtiges Layout:</p>
                <ol>
                  <li><code>.header-inner</code>: Flex-Container, Logo links und Navigation rechts (<code>space-between</code>), vertikal zentriert,
                      Innenabstand <code>16px</code> oben und unten.</li>
                  <li><code>.main-nav ul</code>: ebenfalls ein Flex-Container mit <code>gap: 24px</code>.
                      Setze dafür den <code>margin-left</code> der <code>li</code>-Elemente aus der letzten Lektion wieder auf <code>0</code> (oder entferne ihn).</li>
                  <li>Die Öffnungszeiten-Tabelle (<code>.hours</code>) soll mit <code>margin: 0 auto</code> zentriert werden.</li>
                </ol>
                """,
            AddedCss = """
                .header-inner {
                  display: flex;
                  justify-content: space-between;
                  align-items: center;
                  padding: 16px 0;
                }

                .main-nav ul {
                  display: flex;
                  gap: 24px;
                }

                .main-nav li {
                  margin-left: 0;
                }

                .hours {
                  margin: 0 auto;
                }
                """,
            Checks =
            [
                Check.Style("Header ist ein Flex-Container", ".header-inner", "display", "flex"),
                Check.Style("Logo und Navigation an den Rändern", ".header-inner", "justify-content", "space-between"),
                Check.Style("Header vertikal zentriert", ".header-inner", "align-items", "center"),
                Check.Style("Header-Innenabstand 16px", ".header-inner", "padding-top", "16px"),
                Check.Style("Navigation ist ein Flex-Container", ".main-nav ul", "display", "flex"),
                Check.Style("Navigation mit 24px Abstand", ".main-nav ul", "column-gap", "24px"),
                Check.Style("Kein zusätzlicher Abstand links an den Listeneinträgen", ".main-nav li", "margin-left", "0px"),
                Check.Js("Öffnungszeiten-Tabelle ist zentriert",
                    "const t = h.rect('.hours'); const c = h.rect('#zeiten .container'); return Math.abs((t.left - c.left) - (c.right - t.right)) < 2 || 'Die Tabelle steht noch nicht mittig.';"),
            ],
        },
    };
}
