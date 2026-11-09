namespace CssPlayground.Content.Lessons;

public static class L02Selektoren
{
    public static Lesson Create() => new()
    {
        Number = 2,
        Id = "selektoren",
        Title = "Selektoren",
        Summary = "Gezielt die richtigen Elemente auswählen: Typ, Klasse, ID, Gruppen und Nachfahren.",
        Goals =
        [
            "Typ-, Klassen- und ID-Selektoren einsetzen",
            "Mehrere Selektoren gruppieren",
            "Elemente über ihre Vorfahren auswählen (Nachfahrenselektor)",
            "Den Universalselektor kennen",
        ],
        Sections =
        [
            new()
            {
                Title = "Typselektor",
                Body = """
                    <p>Der einfachste Selektor ist der Name eines HTML-Elements, z.&nbsp;B. <code>p</code>, <code>h2</code> oder <code>li</code>.
                    Er trifft <strong>alle</strong> Elemente dieses Typs auf der Seite.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <h2>Einkaufsliste</h2>
                        <ul>
                          <li>Mehl</li>
                          <li>Zucker</li>
                          <li>Eier</li>
                        </ul>
                        """,
                    Css = """
                        li {
                          color: purple;
                        }
                        """,
                    PreviewHeight = 180,
                },
            },
            new()
            {
                Title = "Klassenselektor",
                Body = """
                    <p>Oft sollen nur <em>bestimmte</em> Elemente gestaltet werden. Dafür vergibst du im HTML eine <strong>Klasse</strong> mit dem Attribut
                    <code>class</code> und wählst sie in CSS mit einem <strong>Punkt</strong> aus: <code>.wichtig</code>.</p>
                    <ul>
                      <li>Eine Klasse darf beliebig oft auf einer Seite vorkommen.</li>
                      <li>Ein Element kann mehrere Klassen haben, getrennt durch Leerzeichen: <code>class="karte hervorgehoben"</code>.</li>
                      <li>Typ und Klasse lassen sich kombinieren: <code>p.wichtig</code> trifft nur Absätze mit der Klasse <code>wichtig</code>.</li>
                    </ul>
                    <p>Klassen sind das wichtigste Werkzeug beim Gestalten – du wirst sie ständig verwenden.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <p>Ein normaler Absatz.</p>
                        <p class="wichtig">Dieser Absatz ist wichtig!</p>
                        <p>Noch ein normaler Absatz.</p>
                        <p class="wichtig leise">Wichtig, aber leise.</p>
                        """,
                    Css = """
                        .wichtig {
                          color: crimson;
                          font-weight: bold;
                        }

                        .leise {
                          font-size: 13px;
                        }
                        """,
                },
            },
            new()
            {
                Title = "ID-Selektor",
                Body = """
                    <p>Eine <strong>ID</strong> ist auf einer Seite <em>einmalig</em>. In CSS wird sie mit einer Raute ausgewählt: <code>#kopfbereich</code>.</p>
                    <p>IDs werden vor allem für Sprungmarken (<code>&lt;a href="#kontakt"&gt;</code>) und JavaScript genutzt. Zum Gestalten sind Klassen meist die bessere Wahl,
                    weil sie wiederverwendbar sind und – wie du später lernst – leichter zu überschreiben.</p>
                    """,
                Example = new()
                {
                    Html = """
                        <div id="banner">Großer Sommerschlussverkauf!</div>
                        <p>Weiterer Inhalt der Seite.</p>
                        """,
                    Css = """
                        #banner {
                          background-color: gold;
                          font-size: 22px;
                          text-align: center;
                        }
                        """,
                    PreviewHeight = 140,
                },
            },
            new()
            {
                Title = "Gruppieren und Nachfahren",
                Body = """
                    <p><strong>Gruppieren:</strong> Sollen mehrere Selektoren dieselben Deklarationen bekommen, trennst du sie mit einem <strong>Komma</strong>:</p>
                    <pre><code>h1, h2, h3 { font-family: Georgia, serif; }</code></pre>
                    <p><strong>Nachfahrenselektor:</strong> Ein <strong>Leerzeichen</strong> zwischen zwei Selektoren bedeutet „innerhalb von“.
                    <code>nav a</code> trifft also nur Links, die irgendwo in einem <code>nav</code> stehen – Links im Fließtext bleiben unberührt.</p>
                    <p><strong>Kindselektor:</strong> Mit <code>&gt;</code> werden nur <em>direkte</em> Kinder getroffen: <code>ul &gt; li</code>.</p>
                    <p><strong>Universalselektor:</strong> <code>*</code> trifft jedes Element. Du wirst ihn später beim Box-Modell brauchen.</p>
                    <div class="tip">Achtung: <code>h1, p</code> (mit Komma) und <code>h1 p</code> (ohne Komma) bedeuten etwas völlig anderes!</div>
                    """,
                Example = new()
                {
                    Html = """
                        <nav>
                          <a href="#">Start</a> | <a href="#">Blog</a>
                        </nav>
                        <h1>Titel</h1>
                        <h2>Untertitel</h2>
                        <p>Ein <a href="#">Link im Text</a> bleibt unverändert.</p>
                        """,
                    Css = """
                        h1, h2 {
                          font-family: Georgia, serif;
                          color: darkslateblue;
                        }

                        nav a {
                          color: white;
                          background-color: darkslateblue;
                          text-decoration: none;
                        }
                        """,
                },
            },
        ],
        Exercises =
        [
            new()
            {
                Id = "l02-e1",
                Title = "Klassen gezielt einsetzen",
                Task = """
                    <p>Im HTML gibt es Aufgaben mit der Klasse <code>erledigt</code>. Gestalte sie so:</p>
                    <ul>
                      <li>Textfarbe <code>gray</code></li>
                      <li>durchgestrichen mit <code>text-decoration: line-through;</code></li>
                    </ul>
                    <p>Die übrigen Aufgaben sollen unverändert bleiben.</p>
                    """,
                Html = """
                    <h2>To-do</h2>
                    <ul>
                      <li class="erledigt">Wäsche waschen</li>
                      <li>Blumen gießen</li>
                      <li class="erledigt">CSS-Lektion 1</li>
                      <li>CSS-Lektion 2</li>
                    </ul>
                    """,
                SolutionCss = """
                    .erledigt {
                      color: gray;
                      text-decoration: line-through;
                    }
                    """,
                Hint = "Eine Klasse wählst du mit einem Punkt vor dem Namen aus: .erledigt",
                Checks =
                [
                    Check.Style("Erledigte Aufgaben sind grau.", ".erledigt", "color", "gray"),
                    Check.Contains("Erledigte Aufgaben sind durchgestrichen.", ".erledigt", "text-decoration-line", "line-through"),
                    Check.Style("Offene Aufgaben bleiben schwarz.", "li:not(.erledigt)", "color", "black"),
                ],
            },
            new()
            {
                Id = "l02-e2",
                Title = "Nur die Links im Menü",
                Task = """
                    <p>Die Links im <code>nav</code>-Bereich sollen <code>white</code> sein und keine Unterstreichung haben (<code>text-decoration: none;</code>).
                    Der Link im Fließtext soll dabei <strong>nicht</strong> verändert werden.</p>
                    <p>Gib außerdem allen <code>h1</code>- und <code>h2</code>-Überschriften mit <strong>einer</strong> gruppierten Regel die Farbe <code>teal</code>.</p>
                    """,
                Html = """
                    <nav style="background-color: teal; padding: 8px;">
                      <a href="#">Start</a>
                      <a href="#">Rezepte</a>
                      <a href="#">Kontakt</a>
                    </nav>
                    <h1>Rezepte</h1>
                    <h2>Kürbissuppe</h2>
                    <p>Das ganze Rezept findest du <a href="#">hier</a>.</p>
                    """,
                SolutionCss = """
                    nav a {
                      color: white;
                      text-decoration: none;
                    }

                    h1, h2 {
                      color: teal;
                    }
                    """,
                Hint = "Nachfahrenselektor: nav a. Gruppieren mit Komma: h1, h2.",
                Checks =
                [
                    Check.Style("Menülinks sind weiß.", "nav a", "color", "white"),
                    Check.Style("Menülinks sind nicht unterstrichen.", "nav a", "text-decoration-line", "none"),
                    Check.Contains("Der Link im Text ist weiterhin unterstrichen.", "p a", "text-decoration-line", "underline"),
                    Check.Style("h1 ist teal.", "h1", "color", "teal"),
                    Check.Style("h2 ist teal.", "h2", "color", "teal"),
                    Check.Js("Für h1 und h2 wird eine gruppierte Regel verwendet.",
                        "return h.findRules(/(^|,)\\s*h1\\s*,|,\\s*h1\\s*$/).length > 0 || 'Schreibe h1 und h2 mit Komma getrennt in einen Selektor.';"),
                ],
            },
        ],
        Project = new()
        {
            Id = "l02-projekt",
            Task = """
                <p>Jetzt wählst du gezielt Teile der Café-Seite aus. Schau dir dafür das HTML an – dort findest du Klassen wie <code>logo</code>, <code>main-nav</code> und <code>price</code>.</p>
                <ol>
                  <li>Die Preise (Klasse <code>price</code>) sollen fett sein: <code>font-weight: bold;</code></li>
                  <li>Die Links in der Navigation (<code>.main-nav a</code>) sollen nicht unterstrichen sein.</li>
                  <li>Das Logo (Klasse <code>logo</code>) soll ebenfalls nicht unterstrichen sein.</li>
                  <li>Alle <code>h2</code>- und <code>h3</code>-Überschriften bekommen in einer gruppierten Regel die Schrift <code>Georgia, serif</code>.</li>
                </ol>
                """,
            AddedCss = """
                .price {
                  font-weight: bold;
                }

                .main-nav a,
                .logo {
                  text-decoration: none;
                }

                h2, h3 {
                  font-family: Georgia, serif;
                }
                """,
            Hint = "Klassen beginnen mit einem Punkt. Für die Navigation brauchst du einen Nachfahrenselektor (.main-nav a).",
            Checks =
            [
                Check.Style("Preise sind fett.", ".price", "font-weight", "700"),
                Check.Style("Navigationslinks sind nicht unterstrichen.", ".main-nav a", "text-decoration-line", "none"),
                Check.Style("Das Logo ist nicht unterstrichen.", ".logo", "text-decoration-line", "none"),
                Check.Contains("h2 nutzt Georgia.", "h2", "font-family", "georgia"),
                Check.Contains("h3 nutzt Georgia.", "h3", "font-family", "georgia"),
                Check.Contains("Andere Links (z. B. „Zur Karte“) bleiben unterstrichen – wähle gezielt aus.",".hero .button", "text-decoration-line", "underline"),
            ],
        },
    };
}
