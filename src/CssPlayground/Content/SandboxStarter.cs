namespace CssPlayground.Content;

/// <summary>Startinhalt der Spielwiese.</summary>
public static class SandboxStarter
{
    public const string Html = """
<div class="karte">
  <h1>Hallo Spielwiese!</h1>
  <p>Ändere HTML und CSS nach Lust und Laune.</p>
  <button>Klick mich</button>
</div>
""";

    public const string Css = """
body {
  font-family: system-ui, sans-serif;
  display: grid;
  place-items: center;
  min-height: 100vh;
  margin: 0;
  background: linear-gradient(135deg, #a1c4fd, #c2e9fb);
}

.karte {
  background: white;
  padding: 32px;
  border-radius: 16px;
  box-shadow: 0 10px 30px rgb(0 0 0 / 0.1);
  text-align: center;
}

button {
  background: #4361ee;
  color: white;
  border: none;
  padding: 10px 24px;
  border-radius: 999px;
  font: inherit;
  cursor: pointer;
}
""";
}
