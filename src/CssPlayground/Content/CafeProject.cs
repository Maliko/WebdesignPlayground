namespace CssPlayground.Content;

/// <summary>
/// Das HTML der Café-Webseite, die im Laufe des Kurses Schritt für Schritt gestaltet wird.
/// Das HTML bleibt gleich – nur das CSS wächst mit jeder Lektion.
/// </summary>
public static class CafeProject
{
    public const string Html = """
<header class="site-header">
  <div class="container header-inner">
    <a href="#start" class="logo">☕ Café Kaffeebohne</a>
    <nav class="main-nav">
      <ul>
        <li><a href="#ueber-uns">Über uns</a></li>
        <li><a href="#karte">Karte</a></li>
        <li><a href="#zeiten">Öffnungszeiten</a></li>
        <li><a href="#kontakt">Kontakt</a></li>
      </ul>
    </nav>
  </div>
</header>

<main>
  <section id="start" class="hero">
    <div class="container">
      <h1>Frisch geröstet. Mit Liebe serviert.</h1>
      <p class="hero-text">Dein gemütliches Café mitten in der Altstadt – mit hausgemachtem Kuchen und Kaffee aus eigener Röstung.</p>
      <a href="#karte" class="button">Zur Karte</a>
    </div>
  </section>

  <section id="ueber-uns" class="section">
    <div class="container">
      <h2>Über uns</h2>
      <p>Seit 2012 rösten wir unsere Bohnen selbst – in kleinen Mengen und mit viel Geduld. So entfaltet jede Sorte ihr volles Aroma.</p>
      <p>Bei uns bekommst du nicht nur guten Kaffee, sondern auch einen Ort zum Durchatmen: zum Lesen, Arbeiten oder Plaudern.</p>
    </div>
  </section>

  <section id="karte" class="section section-alt">
    <div class="container">
      <h2>Unsere Karte</h2>
      <div class="menu-grid">
        <article class="card">
          <h3>Espresso</h3>
          <p>Kräftig und aromatisch, mit feiner Crema.</p>
          <span class="price">2,20 €</span>
        </article>
        <article class="card featured">
          <span class="badge">Beliebt</span>
          <h3>Cappuccino</h3>
          <p>Espresso mit cremigem Milchschaum.</p>
          <span class="price">3,40 €</span>
        </article>
        <article class="card">
          <h3>Latte Macchiato</h3>
          <p>Viel Milch, ein Schuss Espresso, drei Schichten.</p>
          <span class="price">3,80 €</span>
        </article>
        <article class="card">
          <h3>Chai Latte</h3>
          <p>Gewürztee mit aufgeschäumter Milch.</p>
          <span class="price">3,60 €</span>
        </article>
        <article class="card">
          <h3>Käsekuchen</h3>
          <p>Nach Omas Rezept, jeden Morgen frisch.</p>
          <span class="price">3,90 €</span>
        </article>
        <article class="card">
          <h3>Apfelstrudel</h3>
          <p>Warm serviert, mit Vanillesoße.</p>
          <span class="price">4,50 €</span>
        </article>
      </div>
    </div>
  </section>

  <section id="zeiten" class="section">
    <div class="container">
      <h2>Öffnungszeiten</h2>
      <table class="hours">
        <tr><th>Montag – Freitag</th><td>7:30 – 18:00 Uhr</td></tr>
        <tr><th>Samstag</th><td>9:00 – 18:00 Uhr</td></tr>
        <tr><th>Sonntag</th><td>10:00 – 17:00 Uhr</td></tr>
      </table>
    </div>
  </section>

  <section id="kontakt" class="section section-alt">
    <div class="container">
      <h2>Kontakt</h2>
      <form class="contact-form">
        <label for="name">Name</label>
        <input type="text" id="name" placeholder="Dein Name">
        <label for="nachricht">Nachricht</label>
        <textarea id="nachricht" rows="4" placeholder="Was möchtest du uns sagen?"></textarea>
        <button type="submit" class="button">Absenden</button>
      </form>
    </div>
  </section>
</main>

<footer class="site-footer">
  <div class="container">
    <p>© 2026 Café Kaffeebohne · Altstadtgasse 7 · 12345 Musterstadt</p>
  </div>
</footer>
""";
}
