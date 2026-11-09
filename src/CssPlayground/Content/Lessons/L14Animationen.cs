namespace CssPlayground.Content.Lessons;

public static class L14Animationen
{
    public static Lesson Create() => new()
    {
        Number = 14,
        Id = "animationen",
        Title = "Transformationen, Übergänge und Animationen",
        Summary = "Elemente verschieben, drehen und skalieren – und Änderungen weich animieren.",
        Goals =
        [
            "Elemente mit transform verschieben, drehen und skalieren",
            "Zustandswechsel mit transition sanft animieren",
            "Eigene Animationen mit @keyframes definieren",
            "Rücksicht auf Menschen nehmen, die weniger Bewegung wünschen",
        ],
        Sections =
        [
            new()
            {
                Title = "transform",
                Body = """
                    <p><code>transform</code> verändert die Darstellung eines Elements, <strong>ohne</strong> das Layout drumherum zu beeinflussen:</p>
                    <ul>
                      <li><code>translate(20px, 10px)</code> bzw. <code>translateY(-4px)</code> – verschieben</li>
                      <li><code>rotate(15deg)</code> – drehen</li>
                      <li><code>scale(1.2)</code> – vergrößern / verkleinern</li>
                      <li>Kombinationen: <code>transform: translateY(-4px) scale(1.05);</code></li>
                    </ul>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="kachel verschieben">translate</div>
                        <div class="kachel drehen">rotate</div>
                        <div class="kachel skalieren">scale</div>
                        """,
                    Css = """
                        .kachel {
                          display: inline-block;
                          width: 90px;
                          padding: 30px 0;
                          margin: 20px 10px;
                          text-align: center;
                          background-color: darkcyan;
                          color: white;
                        }

                        .verschieben { transform: translate(10px, 20px); }
                        .drehen      { transform: rotate(15deg); }
                        .skalieren   { transform: scale(1.2); }
                        """,
                    PreviewHeight = 160,
                },
            },
            new()
            {
                Title = "Übergänge mit transition",
                Body = """
                    <p>Ändert sich ein Wert (z.&nbsp;B. durch <code>:hover</code>), springt er normalerweise sofort um. Mit <code>transition</code> wird daraus ein weicher Übergang:</p>
                    <pre><code>transition: eigenschaft dauer zeitverlauf;
                    transition: background-color 0.3s ease;</code></pre>
                    <ul>
                      <li>Mehrere Eigenschaften trennst du mit Komma: <code>transition: transform 0.3s, box-shadow 0.3s;</code></li>
                      <li>Zeitverläufe: <code>ease</code> (Standard), <code>linear</code>, <code>ease-in</code>, <code>ease-out</code>, <code>ease-in-out</code></li>
                    </ul>
                    <div class="tip">Die <code>transition</code> gehört in die <strong>normale</strong> Regel, nicht in die <code>:hover</code>-Regel – sonst wird nur das Hineinfahren animiert, nicht das Herausfahren.</div>
                    <p>Fahre über die Karte!</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="karte">Fahr über mich</div>
                        """,
                    Css = """
                        body { padding: 20px; }

                        .karte {
                          width: 200px;
                          padding: 30px;
                          background-color: white;
                          border-radius: 10px;
                          box-shadow: 0 2px 6px rgb(0 0 0 / 0.15);
                          transition: transform 0.3s ease, box-shadow 0.3s ease;
                        }

                        .karte:hover {
                          transform: translateY(-6px);
                          box-shadow: 0 12px 24px rgb(0 0 0 / 0.2);
                        }
                        """,
                    PreviewHeight = 160,
                },
            },
            new()
            {
                Title = "Animationen mit @keyframes",
                Body = """
                    <p>Für Animationen, die von selbst ablaufen, definierst du mit <code>@keyframes</code> die Zwischenschritte und gibst ihnen einen Namen:</p>
                    <pre><code>@keyframes pulsieren {
                      from { transform: scale(1); }
                      to   { transform: scale(1.1); }
                    }</code></pre>
                    <p>Dann wendest du sie mit <code>animation</code> an: <code>animation: name dauer zeitverlauf wiederholungen richtung;</code></p>
                    <ul>
                      <li><code>infinite</code> – endlos wiederholen</li>
                      <li><code>alternate</code> – abwechselnd vorwärts und rückwärts</li>
                      <li>Statt <code>from</code>/<code>to</code> gehen auch Prozentwerte: <code>0%</code>, <code>50%</code>, <code>100%</code></li>
                    </ul>
                    <div class="tip"><strong>Barrierefreiheit:</strong> Manche Menschen reagieren empfindlich auf Bewegung. Mit der Media Query <code>@media (prefers-reduced-motion: reduce)</code> kannst du Animationen für sie abschalten.</div>
                    """,
                Example = new()
                {
                    Html = """
                        <div class="herz">❤️</div>
                        <div class="lader"></div>
                        """,
                    Css = """
                        @keyframes pulsieren {
                          from { transform: scale(1); }
                          to   { transform: scale(1.3); }
                        }

                        @keyframes drehen {
                          to { transform: rotate(360deg); }
                        }

                        .herz {
                          display: inline-block;
                          font-size: 40px;
                          margin: 20px;
                          animation: pulsieren 0.6s ease-in-out infinite alternate;
                        }

                        .lader {
                          display: inline-block;
                          width: 40px;
                          height: 40px;
                          border: 5px solid #ddd;
                          border-top-color: dodgerblue;
                          border-radius: 50%;
                          animation: drehen 1s linear infinite;
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
                Id = "l14-e1",
                Title = "Ein lebendiger Button",
                Task = """
                    <p>Der Button soll beim Überfahren</p>
                    <ul>
                      <li>um <code>1.1</code> vergrößert werden (<code>transform: scale(1.1)</code>) und</li>
                      <li>die Hintergrundfarbe <code>darkorange</code> annehmen.</li>
                    </ul>
                    <p>Beide Änderungen sollen in <code>0.2s</code> sanft übergehen (<code>transition</code> in der normalen <code>.btn</code>-Regel).</p>
                    """,
                Html = """
                    <button class="btn">Jetzt kaufen</button>
                    """,
                StarterCss = """
                    body { padding: 30px; }

                    .btn {
                      background-color: orange;
                      color: white;
                      border: none;
                      padding: 12px 28px;
                      font-size: 18px;
                      border-radius: 8px;
                    }
                    """,
                SolutionCss = """
                    body { padding: 30px; }

                    .btn {
                      background-color: orange;
                      color: white;
                      border: none;
                      padding: 12px 28px;
                      font-size: 18px;
                      border-radius: 8px;
                      transition: transform 0.2s, background-color 0.2s;
                    }

                    .btn:hover {
                      transform: scale(1.1);
                      background-color: darkorange;
                    }
                    """,
                Checks =
                [
                    Check.Contains("Der Button hat einen Übergang von 0.2s.", ".btn", "transition-duration", "0.2s"),
                    Check.Js("Bei :hover wird der Button auf 1.1 skaliert.",
                        "const r = h.findRules(/\\.btn:hover/, { prop: 'transform' }); return (r.length > 0 && /scale\\(\\s*1\\.1\\s*\\)/.test(r[r.length - 1].style.getPropertyValue('transform'))) || 'Keine .btn:hover-Regel mit transform: scale(1.1) gefunden.';"),
                    Check.Js("Bei :hover wird der Hintergrund darkorange.",
                        "const r = h.findRules(/\\.btn:hover/, { prop: 'background-color' }); return (r.length > 0 && h.norm('background-color', r[r.length - 1].style.getPropertyValue('background-color')) === h.norm('background-color', 'darkorange')) || 'Keine .btn:hover-Regel mit background-color: darkorange gefunden.';"),
                    Check.Js("Die transition steht in der normalen Regel, nicht im :hover.",
                        "return !h.findRules(/:hover/).some(r => r.style.getPropertyValue('transition-duration')) || 'Verschiebe transition aus der :hover-Regel in die .btn-Regel.';"),
                ],
                PreviewHeight = 130,
            },
            new()
            {
                Id = "l14-e2",
                Title = "Hüpfender Ball",
                Task = """
                    <p>Erstelle eine Animation namens <code>huepfen</code>, die den Ball von <code>translateY(0)</code> nach <code>translateY(-60px)</code> bewegt.
                    Wende sie mit einer Dauer von <code>0.5s</code>, <code>infinite</code> und <code>alternate</code> auf <code>.ball</code> an.</p>
                    """,
                Html = """
                    <div class="boden">
                      <div class="ball"></div>
                    </div>
                    """,
                StarterCss = """
                    .boden {
                      height: 120px;
                      display: flex;
                      align-items: flex-end;
                      justify-content: center;
                      border-bottom: 4px solid sienna;
                    }

                    .ball {
                      width: 40px;
                      height: 40px;
                      border-radius: 50%;
                      background-color: tomato;
                    }
                    """,
                SolutionCss = """
                    @keyframes huepfen {
                      from { transform: translateY(0); }
                      to   { transform: translateY(-60px); }
                    }

                    .boden {
                      height: 120px;
                      display: flex;
                      align-items: flex-end;
                      justify-content: center;
                      border-bottom: 4px solid sienna;
                    }

                    .ball {
                      width: 40px;
                      height: 40px;
                      border-radius: 50%;
                      background-color: tomato;
                      animation: huepfen 0.5s ease-in-out infinite alternate;
                    }
                    """,
                Checks =
                [
                    Check.Js("@keyframes huepfen ist definiert.", "return h.keyframes().includes('huepfen') || 'Es gibt noch keine @keyframes-Regel namens huepfen.';"),
                    Check.Style("Der Ball nutzt die Animation huepfen.", ".ball", "animation-name", "huepfen"),
                    Check.Style("Dauer 0.5s.", ".ball", "animation-duration", "0.5s"),
                    Check.Style("Endlos wiederholt.", ".ball", "animation-iteration-count", "infinite"),
                    Check.Style("Abwechselnde Richtung.", ".ball", "animation-direction", "alternate"),
                ],
                PreviewHeight = 160,
            },
        ],
        Project = new()
        {
            Id = "l14-projekt",
            Task = """
                <p>Bewegung bringt das Café zum Leben:</p>
                <ol>
                  <li>Die Karten (<code>.card</code>) bekommen einen Übergang für <code>transform</code> und <code>box-shadow</code> von <code>0.3s</code>.
                      Beim Überfahren heben sie sich um <code>4px</code> an (<code>translateY(-4px)</code>) und bekommen einen kräftigeren Schatten, z.&nbsp;B. <code>0 8px 20px rgb(0 0 0 / 0.12)</code>.</li>
                  <li>Buttons (<code>.button</code>) erhalten einen Übergang für <code>background-color</code> von <code>0.2s</code>.</li>
                  <li>Erstelle eine Animation <code>einblenden</code>: von <code>opacity: 0</code> und <code>translateY(20px)</code> zu <code>opacity: 1</code> und <code>translateY(0)</code>.
                      Wende sie auf <code>.hero h1</code> mit einer Dauer von <code>0.8s</code> und <code>ease-out</code> an.</li>
                </ol>
                """,
            AddedCss = """
                .card {
                  transition: transform 0.3s, box-shadow 0.3s;
                }

                .card:hover {
                  transform: translateY(-4px);
                  box-shadow: 0 8px 20px rgb(0 0 0 / 0.12);
                }

                .button {
                  transition: background-color 0.2s;
                }

                @keyframes einblenden {
                  from {
                    opacity: 0;
                    transform: translateY(20px);
                  }
                  to {
                    opacity: 1;
                    transform: translateY(0);
                  }
                }

                .hero h1 {
                  animation: einblenden 0.8s ease-out;
                }
                """,
            Checks =
            [
                Check.Contains("Karten haben einen Übergang von 0.3s", ".card", "transition-duration", "0.3s"),
                Check.Js("Karten heben sich beim Überfahren an",
                    "const r = h.findRules(/\\.card:hover/, { prop: 'transform' }); return (r.length > 0 && /translateY\\(\\s*-4px\\s*\\)/.test(r[r.length - 1].style.getPropertyValue('transform'))) || 'Keine .card:hover-Regel mit transform: translateY(-4px) gefunden.';"),
                Check.Js("Karten bekommen beim Überfahren einen Schatten",
                    "return h.findRules(/\\.card:hover/, { prop: 'box-shadow' }).length > 0 || 'Keine .card:hover-Regel mit box-shadow gefunden.';"),
                Check.Contains("Buttons haben einen Übergang von 0.2s", ".hero .button", "transition-duration", "0.2s"),
                Check.Js("@keyframes einblenden ist definiert", "return h.keyframes().includes('einblenden') || 'Es gibt noch keine @keyframes-Regel namens einblenden.';"),
                Check.Style("Die Hero-Überschrift nutzt die Animation", ".hero h1", "animation-name", "einblenden"),
                Check.Style("Animationsdauer 0.8s", ".hero h1", "animation-duration", "0.8s"),
                Check.Style("Zeitverlauf ease-out", ".hero h1", "animation-timing-function", "ease-out"),
            ],
        },
    };
}
