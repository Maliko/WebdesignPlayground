namespace CssPlayground.Content.Lessons;

public static class L10Grid
{
    public static Lesson Create() => new()
    {
        Number = 10,
        Id = "grid",
        Title = "CSS Grid",
        Summary = "Zweidimensionale Layouts mit Zeilen und Spalten.",
        Goals =
        [
            "Ein Raster mit grid-template-columns definieren",
            "Die Einheit fr und die Funktion repeat() nutzen",
            "Elemente über mehrere Spalten oder Zeilen spannen",
            "Automatisch anpassende Raster mit auto-fit und minmax() bauen",
            "Benannte Bereiche mit grid-template-areas einsetzen",
        ],
        Sections =
        [
            new()
            {
                Title = "Spalten definieren",
                Body = """
                    <p>Während Flexbox eine Dimension kennt, arbeitet Grid in <strong>zwei Dimensionen</strong>: Zeilen <em>und</em> Spalten.
                    Wie bei Flexbox wird das Elternelement zum Container:</p>
                    <pre><code>.raster {
                      display: grid;
                      grid-template-columns: 200px 1fr 1fr;
                      gap: 16px;
                    }</code></pre>
                    <p>Die Einheit <code>fr</code> („fraction“) bedeutet „ein Anteil des freien Platzes“. Im Beispiel ist die erste Spalte 200px breit,
                    die übrigen teilen sich den Rest. Die Kinder werden automatisch Zelle für Zelle verteilt – neue Zeilen entstehen von selbst.</p>
                    <p>Statt <code>1fr 1fr 1fr 1fr</code> kannst du <code>repeat(4, 1fr)</code> schreiben.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="raster">
                          <div>1</div><div>2</div><div>3</div>
                          <div>4</div><div>5</div><div>6</div>
                          <div>7</div>
                        </div>
                        """,
                    Css = """
                        .raster {
                          display: grid;
                          grid-template-columns: repeat(3, 1fr);
                          gap: 10px;
                        }

                        .raster div {
                          background-color: mediumpurple;
                          color: white;
                          padding: 16px;
                          text-align: center;
                        }
                        """,
                    PreviewHeight = 220,
                },
            },
            new()
            {
                Title = "Über mehrere Zellen spannen",
                Body = """
                    <p>Ein Item kann sich über mehrere Spalten oder Zeilen erstrecken:</p>
                    <ul>
                      <li><code>grid-column: span 2;</code> – zwei Spalten breit</li>
                      <li><code>grid-row: span 2;</code> – zwei Zeilen hoch</li>
                      <li><code>grid-column: 1 / -1;</code> – von der ersten bis zur letzten Linie, also über die ganze Breite</li>
                    </ul>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="galerie">
                          <div class="gross">groß</div>
                          <div>2</div><div>3</div>
                          <div>4</div><div>5</div>
                          <div class="breit">ganz breit</div>
                        </div>
                        """,
                    Css = """
                        .galerie {
                          display: grid;
                          grid-template-columns: repeat(4, 1fr);
                          gap: 8px;
                        }

                        .galerie div {
                          background-color: lightseagreen;
                          color: white;
                          padding: 20px;
                        }

                        .gross {
                          grid-column: span 2;
                          grid-row: span 2;
                        }

                        .breit {
                          grid-column: 1 / -1;
                        }
                        """,
                    PreviewHeight = 260,
                },
            },
            new()
            {
                Title = "Raster, die sich selbst anpassen",
                Body = """
                    <p>Eine der nützlichsten Zeilen in ganz CSS:</p>
                    <pre><code>grid-template-columns: repeat(auto-fit, minmax(150px, 1fr));</code></pre>
                    <p>Bedeutung: „Mach so viele Spalten, wie hineinpassen. Jede ist mindestens 150px breit und teilt sich ansonsten den Platz.“
                    So entsteht ein Kartenraster, das sich ohne Media Queries an jede Bildschirmbreite anpasst. Ziehe dein Browserfenster schmaler und beobachte die Vorschau!</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="karten">
                          <div>Karte 1</div><div>Karte 2</div><div>Karte 3</div>
                          <div>Karte 4</div><div>Karte 5</div>
                        </div>
                        """,
                    Css = """
                        .karten {
                          display: grid;
                          grid-template-columns: repeat(auto-fit, minmax(150px, 1fr));
                          gap: 12px;
                        }

                        .karten div {
                          background-color: sandybrown;
                          padding: 24px;
                        }
                        """,
                    PreviewHeight = 200,
                },
            },
            new()
            {
                Title = "Benannte Bereiche",
                Body = """
                    <p>Für Seitenlayouts kannst du den Bereichen Namen geben und das Layout regelrecht „aufzeichnen“:</p>
                    <pre><code>grid-template-areas:
                      "kopf   kopf"
                      "seite  inhalt"
                      "fuss   fuss";</code></pre>
                    <p>Jedes Kind wird dann mit <code>grid-area: kopf;</code> usw. seinem Bereich zugeordnet. Probiere, die Seitenleiste nach rechts zu verschieben,
                    indem du nur die Bereichsnamen änderst!</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="seite">
                          <header>Kopf</header>
                          <aside>Seite</aside>
                          <main>Inhalt</main>
                          <footer>Fuß</footer>
                        </div>
                        """,
                    Css = """
                        .seite {
                          display: grid;
                          grid-template-columns: 150px 1fr;
                          grid-template-areas:
                            "kopf  kopf"
                            "seite inhalt"
                            "fuss  fuss";
                          gap: 8px;
                        }

                        header { grid-area: kopf;   background: tomato; }
                        aside  { grid-area: seite;  background: gold; }
                        main   { grid-area: inhalt; background: lightgreen; min-height: 100px; }
                        footer { grid-area: fuss;   background: lightblue; }

                        .seite > * { padding: 12px; }
                        """,
                    PreviewHeight = 240,
                },
            },
        ],
        Exercises =
        [
            new()
            {
                Id = "l10-e1",
                Title = "Fotogalerie",
                Task = """
                    <p>Baue eine Galerie mit <strong>4 gleich breiten Spalten</strong> (nutze <code>repeat</code> und <code>fr</code>) und <code>gap: 10px</code>.
                    Das erste Bild (<code>.highlight</code>) soll sich über <strong>2 Spalten</strong> erstrecken.</p>
                    """,
                Html = """
                    <div class="galerie">
                      <div class="bild highlight">★</div>
                      <div class="bild">2</div>
                      <div class="bild">3</div>
                      <div class="bild">4</div>
                      <div class="bild">5</div>
                      <div class="bild">6</div>
                    </div>
                    """,
                StarterCss = """
                    .bild {
                      background-color: steelblue;
                      color: white;
                      height: 80px;
                      font-size: 24px;
                      text-align: center;
                      line-height: 80px;
                    }
                    """,
                SolutionCss = """
                    .galerie {
                      display: grid;
                      grid-template-columns: repeat(4, 1fr);
                      gap: 10px;
                    }

                    .bild {
                      background-color: steelblue;
                      color: white;
                      height: 80px;
                      font-size: 24px;
                      text-align: center;
                      line-height: 80px;
                    }

                    .highlight {
                      grid-column: span 2;
                    }
                    """,
                Checks =
                [
                    Check.Style(".galerie ist ein Grid.", ".galerie", "display", "grid"),
                    Check.Js("4 gleich breite Spalten.",
                        "const cols = h.cs('.galerie', 'grid-template-columns').split(' ').map(parseFloat); return (cols.length === 4 && Math.max(...cols) - Math.min(...cols) < 1) || `Aktuell: ${cols.length} Spalte(n).`;"),
                    Check.Style("Abstand 10px.", ".galerie", "row-gap", "10px"),
                    Check.Js("Das Highlight ist 2 Spalten breit.",
                        "const a = h.rect('.highlight').width; const b = h.qa('.bild')[1].getBoundingClientRect().width; return Math.abs(a - (2 * b + 10)) < 2 || 'Das erste Bild ist noch nicht 2 Spalten breit.';"),
                ],
                PreviewHeight = 220,
            },
            new()
            {
                Id = "l10-e2",
                Title = "Seitenlayout mit Bereichen",
                Task = """
                    <p>Ordne die vier Bereiche mit <code>grid-template-areas</code> so an:</p>
                    <pre><code>kopf   kopf
                    inhalt seite
                    fuss   fuss</code></pre>
                    <p>Die Seitenleiste steht also <strong>rechts</strong> und ist <code>180px</code> breit, der Inhalt bekommt den Rest (<code>1fr</code>).
                    Die <code>grid-area</code>-Zuordnungen der Kinder sind schon vorhanden.</p>
                    """,
                Html = """
                    <div class="layout">
                      <header>Kopf</header>
                      <main>Inhalt</main>
                      <aside>Seitenleiste</aside>
                      <footer>Fuß</footer>
                    </div>
                    """,
                StarterCss = """
                    .layout {
                      gap: 8px;
                    }

                    header { grid-area: kopf; background: #ffcdd2; }
                    main   { grid-area: inhalt; background: #c8e6c9; min-height: 80px; }
                    aside  { grid-area: seite; background: #fff9c4; }
                    footer { grid-area: fuss; background: #bbdefb; }

                    .layout > * { padding: 10px; }
                    """,
                SolutionCss = """
                    .layout {
                      gap: 8px;
                      display: grid;
                      grid-template-columns: 1fr 180px;
                      grid-template-areas:
                        "kopf   kopf"
                        "inhalt seite"
                        "fuss   fuss";
                    }

                    header { grid-area: kopf; background: #ffcdd2; }
                    main   { grid-area: inhalt; background: #c8e6c9; min-height: 80px; }
                    aside  { grid-area: seite; background: #fff9c4; }
                    footer { grid-area: fuss; background: #bbdefb; }

                    .layout > * { padding: 10px; }
                    """,
                Checks =
                [
                    Check.Style(".layout ist ein Grid.", ".layout", "display", "grid"),
                    Check.Js("Seitenleiste steht rechts neben dem Inhalt.",
                        "const m = h.rect('main'); const a = h.rect('aside'); return (a.left > m.right - 1 && Math.abs(a.top - m.top) < 2) || 'Die Seitenleiste steht noch nicht rechts neben dem Inhalt.';"),
                    Check.Js("Seitenleiste ist 180px breit.", "const w = h.rect('aside').width; return Math.abs(w - 180) < 1 || `Aktuell ${Math.round(w)}px.`;"),
                    Check.Js("Kopf und Fuß gehen über die ganze Breite.",
                        "const l = h.rect('.layout'); return ['header', 'footer'].every(s => Math.abs(h.rect(s).width - l.width) < 1) || 'Kopf oder Fuß sind noch nicht ganz breit.';"),
                ],
                PreviewHeight = 220,
            },
        ],
        Project = new()
        {
            Id = "l10-projekt",
            Task = """
                <p>Die Speisekarte des Cafés wird zum Kartenraster:</p>
                <ol>
                  <li><code>.menu-grid</code> wird ein Grid mit <strong>3 gleich breiten Spalten</strong> und <code>gap: 24px</code>.</li>
                  <li>Den <code>margin-bottom</code> der Karten aus Lektion 6 brauchen wir nicht mehr – setze ihn auf <code>0</code>.</li>
                  <li>Die Karten bekommen <code>text-align: center</code>.</li>
                </ol>
                """,
            AddedCss = """
                .menu-grid {
                  display: grid;
                  grid-template-columns: repeat(3, 1fr);
                  gap: 24px;
                }

                .card {
                  margin-bottom: 0;
                  text-align: center;
                }
                """,
            Checks =
            [
                Check.Style("Die Karte ist ein Grid", ".menu-grid", "display", "grid"),
                Check.Js("3 gleich breite Spalten",
                    "const cols = h.cs('.menu-grid', 'grid-template-columns').split(' ').map(parseFloat); return (cols.length === 3 && Math.max(...cols) - Math.min(...cols) < 1) || `Aktuell: ${cols.length} Spalte(n).`;"),
                Check.Style("Abstand zwischen den Karten 24px", ".menu-grid", "column-gap", "24px"),
                Check.Style("Kein zusätzlicher Abstand unter den Karten", ".card", "margin-bottom", "0px"),
                Check.Style("Karten-Text ist zentriert", ".card", "text-align", "center"),
            ],
        },
    };
}
