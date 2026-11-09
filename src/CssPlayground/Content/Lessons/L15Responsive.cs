namespace CssPlayground.Content.Lessons;

public static class L15Responsive
{
    public static Lesson Create() => new()
    {
        Number = 15,
        Id = "responsive",
        Title = "Responsive Design",
        Summary = "Mit Media Queries passt sich die Seite an Smartphone, Tablet und Desktop an.",
        Goals =
        [
            "Verstehen, warum Webseiten auf allen Bildschirmgrößen funktionieren müssen",
            "Media Queries mit min-width und max-width schreiben",
            "Layouts für schmale Bildschirme umbauen",
            "Den Mobile-First-Ansatz kennen",
            "Flüssige Größen mit clamp() einsetzen",
        ],
        Sections =
        [
            new()
            {
                Title = "Media Queries",
                Body = """
                    <p>Über die Hälfte aller Webseitenaufrufe kommt von Smartphones. Eine Seite muss daher auf schmalen <em>und</em> breiten Bildschirmen gut aussehen.
                    Das Werkzeug dafür sind <strong>Media Queries</strong>: CSS-Regeln, die nur unter bestimmten Bedingungen gelten.</p>
                    <pre><code>@media (max-width: 600px) {
                      .spalten {
                        flex-direction: column;
                      }
                    }</code></pre>
                    <p>Die Regeln in den geschweiften Klammern gelten nur, solange das Fenster höchstens 600px breit ist.</p>
                    <p>Nutze die Breiten-Schalter über der Vorschau (📱 / 💻), um die Wirkung zu sehen!</p>
                    <div class="tip">Damit Media Queries auf echten Smartphones funktionieren, braucht jede Seite im HTML-Kopf: <code>&lt;meta name="viewport" content="width=device-width, initial-scale=1"&gt;</code>. Die Vorschau hier fügt diese Zeile automatisch ein.</div>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="spalten">
                          <div>Spalte A</div>
                          <div>Spalte B</div>
                          <div>Spalte C</div>
                        </div>
                        <p class="info"></p>
                        """,
                    Css = """
                        .spalten {
                          display: flex;
                          gap: 10px;
                        }

                        .spalten div {
                          flex: 1;
                          padding: 20px;
                          background-color: lightskyblue;
                        }

                        .info::after { content: "Breiter Bildschirm 💻"; }

                        @media (max-width: 600px) {
                          .spalten {
                            flex-direction: column;
                          }

                          .spalten div {
                            background-color: lightpink;
                          }

                          .info::after { content: "Schmaler Bildschirm 📱"; }
                        }
                        """,
                    PreviewHeight = 260,
                },
            },
            new()
            {
                Title = "Mobile First",
                Body = """
                    <p>Es gibt zwei Strategien:</p>
                    <ul>
                      <li><strong>Desktop First:</strong> Erst das Layout für große Bildschirme, dann mit <code>max-width</code>-Queries für kleinere anpassen.</li>
                      <li><strong>Mobile First:</strong> Erst das einfache, einspaltige Layout für Smartphones, dann mit <code>min-width</code>-Queries für größere Bildschirme erweitern.</li>
                    </ul>
                    <p>Mobile First gilt als bewährte Praxis: Das Basis-CSS ist schlanker, und man denkt zuerst an die wichtigsten Inhalte.
                    Typische Umbruchpunkte (<em>Breakpoints</em>) sind z.&nbsp;B. <code>600px</code>, <code>900px</code> und <code>1200px</code> – richte dich aber lieber nach deinem Inhalt
                    als nach bestimmten Geräten.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="raster">
                          <div>1</div><div>2</div><div>3</div><div>4</div>
                        </div>
                        """,
                    Css = """
                        /* Basis: Smartphone, eine Spalte */
                        .raster {
                          display: grid;
                          gap: 8px;
                        }

                        .raster div {
                          background-color: mediumaquamarine;
                          padding: 20px;
                        }

                        /* Ab 500px: zwei Spalten */
                        @media (min-width: 500px) {
                          .raster { grid-template-columns: 1fr 1fr; }
                        }

                        /* Ab 800px: vier Spalten */
                        @media (min-width: 800px) {
                          .raster { grid-template-columns: repeat(4, 1fr); }
                        }
                        """,
                    PreviewHeight = 260,
                },
            },
            new()
            {
                Title = "Flüssige Größen mit clamp()",
                Body = """
                    <p>Nicht jede Anpassung braucht eine Media Query. Mit <code>clamp(minimum, bevorzugt, maximum)</code> wächst ein Wert stufenlos mit:</p>
                    <pre><code>h1 { font-size: clamp(1.75rem, 5vw, 3rem); }</code></pre>
                    <p>Die Überschrift ist 5&nbsp;% der Fensterbreite groß, aber nie kleiner als 1.75rem und nie größer als 3rem.
                    Auch das <code>auto-fit</code>-Raster aus der Grid-Lektion ist ein Beispiel für Layouts, die ganz ohne Media Queries responsiv sind.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <h1>Ich wachse mit</h1>
                        """,
                    Css = """
                        h1 {
                          font-size: clamp(1.5rem, 8vw, 4rem);
                          color: indigo;
                        }
                        """,
                    PreviewHeight = 140,
                },
            },
        ],
        Exercises =
        [
            new()
            {
                Id = "l15-e1",
                Title = "Menü fürs Smartphone",
                Task = """
                    <p>Auf breiten Bildschirmen stehen Logo und Menü nebeneinander. Schreibe eine Media Query für Bildschirme bis <code>600px</code> Breite, in der</p>
                    <ul>
                      <li><code>.kopf</code> die Richtung <code>column</code> bekommt (Logo über dem Menü) und</li>
                      <li><code>.menu</code> ebenfalls <code>flex-direction: column</code> erhält.</li>
                    </ul>
                    <p>Teste mit dem 📱-Schalter über der Vorschau.</p>
                    """,
                Html = """
                    <header class="kopf">
                      <div class="logo">Bäckerei Krume</div>
                      <nav class="menu">
                        <a href="#">Brot</a>
                        <a href="#">Kuchen</a>
                        <a href="#">Filialen</a>
                      </nav>
                    </header>
                    """,
                StarterCss = """
                    .kopf {
                      display: flex;
                      justify-content: space-between;
                      align-items: center;
                      gap: 10px;
                      padding: 12px;
                      background-color: burlywood;
                    }

                    .logo {
                      font-size: 22px;
                      font-weight: bold;
                    }

                    .menu {
                      display: flex;
                      gap: 16px;
                    }
                    """,
                SolutionCss = """
                    .kopf {
                      display: flex;
                      justify-content: space-between;
                      align-items: center;
                      gap: 10px;
                      padding: 12px;
                      background-color: burlywood;
                    }

                    .logo {
                      font-size: 22px;
                      font-weight: bold;
                    }

                    .menu {
                      display: flex;
                      gap: 16px;
                    }

                    @media (max-width: 600px) {
                      .kopf {
                        flex-direction: column;
                      }

                      .menu {
                        flex-direction: column;
                      }
                    }
                    """,
                Checks =
                [
                    Check.Js("Es gibt eine Media Query mit max-width: 600px.",
                        "return h.rules().some(r => r.media && /max-width:\\s*600px/.test(r.media)) || 'Keine Regel in @media (max-width: 600px) gefunden.';"),
                    Check.Js(".kopf wird im Smartphone-Layout zur Spalte.",
                        "return h.findRules(/\\.kopf/, { media: true, prop: 'flex-direction' }).some(r => /max-width:\\s*600px/.test(r.media) && r.style.getPropertyValue('flex-direction') === 'column') || 'In der Media Query fehlt flex-direction: column für .kopf.';"),
                    Check.Js(".menu wird im Smartphone-Layout zur Spalte.",
                        "return h.findRules(/\\.menu/, { media: true, prop: 'flex-direction' }).some(r => /max-width:\\s*600px/.test(r.media) && r.style.getPropertyValue('flex-direction') === 'column') || 'In der Media Query fehlt flex-direction: column für .menu.';"),
                ],
                PreviewHeight = 200,
            },
        ],
        Project = new()
        {
            Id = "l15-projekt",
            Task = """
                <p>Das Café muss auch auf dem Smartphone gut aussehen. Schreibe eine Media Query für Bildschirme bis <code>700px</code> Breite:</p>
                <ol>
                  <li><code>.header-inner</code>: <code>flex-direction: column</code> und <code>gap: 12px</code> – Logo über der Navigation.</li>
                  <li><code>.main-nav ul</code>: <code>flex-wrap: wrap</code>, <code>justify-content: center</code> und <code>gap: 12px</code>.</li>
                  <li><code>.menu-grid</code>: nur noch <strong>eine</strong> Spalte (<code>1fr</code>).</li>
                  <li><code>h1</code>: Schriftgröße <code>2rem</code>.</li>
                  <li><code>.hero</code>: Innenabstand <code>64px 0</code>.</li>
                </ol>
                <p>Prüfe das Ergebnis mit den Breiten-Schaltern über der Vorschau!</p>
                """,
            AddedCss = """
                @media (max-width: 700px) {
                  .header-inner {
                    flex-direction: column;
                    gap: 12px;
                  }

                  .main-nav ul {
                    flex-wrap: wrap;
                    justify-content: center;
                    gap: 12px;
                  }

                  .menu-grid {
                    grid-template-columns: 1fr;
                  }

                  h1 {
                    font-size: 2rem;
                  }

                  .hero {
                    padding: 64px 0;
                  }
                }
                """,
            Checks =
            [
                Check.Js("Media Query für max. 700px vorhanden",
                    "return h.rules().some(r => r.media && /max-width:\\s*700px/.test(r.media)) || 'Keine Regel in @media (max-width: 700px) gefunden.';"),
                Check.Js("Header wird zur Spalte",
                    "return h.findRules(/\\.header-inner/, { media: true }).some(r => /700px/.test(r.media) && r.style.getPropertyValue('flex-direction') === 'column') || 'flex-direction: column für .header-inner fehlt in der Media Query.';"),
                Check.Js("Navigation darf umbrechen und ist zentriert",
                    "return h.findRules(/\\.main-nav ul/, { media: true }).some(r => /700px/.test(r.media) && r.style.getPropertyValue('flex-wrap') === 'wrap' && r.style.getPropertyValue('justify-content') === 'center') || 'flex-wrap: wrap und justify-content: center für .main-nav ul fehlen in der Media Query.';"),
                Check.Js("Speisekarte einspaltig",
                    "return h.findRules(/\\.menu-grid/, { media: true }).some(r => /700px/.test(r.media) && r.style.getPropertyValue('grid-template-columns') === '1fr') || 'grid-template-columns: 1fr für .menu-grid fehlt in der Media Query.';"),
                Check.Js("h1 wird kleiner (2rem)",
                    "return h.findRules(/(^|,)\\s*h1\\s*($|,)/, { media: true }).some(r => /700px/.test(r.media) && r.style.getPropertyValue('font-size') === '2rem') || 'font-size: 2rem für h1 fehlt in der Media Query.';"),
                Check.Js("Hero mit weniger Innenabstand",
                    "return h.findRules(/\\.hero$/, { media: true }).some(r => /700px/.test(r.media) && r.style.getPropertyValue('padding-top') === '64px') || 'padding: 64px 0 für .hero fehlt in der Media Query.';"),
            ],
        },
    };
}
