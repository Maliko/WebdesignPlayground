// CSS-Playground: Editor, Live-Vorschau, automatische Prüfungen und Speicherung.
// Die Editoren werden komplett im Browser verwaltet, damit Tippen ohne Server-Roundtrip
// sofort in der Vorschau sichtbar ist.

const DRAFT_PREFIX = "cssplayground.draft.";
const PROGRESS_KEY = "cssplayground.progress.v1";

const instances = new Map();
let nextId = 1;

// ---------------------------------------------------------------- Speicher

function storageGet(key) {
    try { return window.localStorage.getItem(key); } catch { return null; }
}

function storageSet(key, value) {
    try { window.localStorage.setItem(key, value); } catch { /* privates Fenster o. Ä. */ }
}

function storageRemove(key) {
    try { window.localStorage.removeItem(key); } catch { /* ignorieren */ }
}

export function loadProgress() { return storageGet(PROGRESS_KEY); }
export function saveProgress(json) { storageSet(PROGRESS_KEY, json); }

export function getDraft(key) {
    const raw = storageGet(DRAFT_PREFIX + key);
    if (!raw) return null;
    try { return JSON.parse(raw); } catch { return null; }
}

export function resetAll() {
    try {
        const keys = [];
        for (let i = 0; i < window.localStorage.length; i++) {
            const k = window.localStorage.key(i);
            if (k && k.startsWith("cssplayground.")) keys.push(k);
        }
        keys.forEach(k => window.localStorage.removeItem(k));
    } catch { /* ignorieren */ }
}

// ---------------------------------------------------------------- Vorschau

function escapeStyle(css) {
    return css.replace(/<\/style/gi, "<\\/style");
}

function buildDocument(html, css) {
    return "<!DOCTYPE html><html lang=\"de\"><head><meta charset=\"utf-8\">" +
        "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">" +
        "<style id=\"__user_css\">" + escapeStyle(css) + "</style></head><body>" +
        html + "</body></html>";
}

// Links in der Vorschau dürfen nicht die App im iframe laden: Anker scrollen, alles andere wird ignoriert.
function guardLinks(doc) {
    doc.addEventListener("click", ev => {
        const a = ev.target.closest && ev.target.closest("a");
        if (!a) return;
        ev.preventDefault();
        const href = a.getAttribute("href") || "";
        if (href.startsWith("#") && href.length > 1) {
            const target = doc.getElementById(decodeURIComponent(href.substring(1)));
            if (target) target.scrollIntoView({ behavior: "smooth" });
        }
    });
    doc.addEventListener("submit", ev => ev.preventDefault());
}

function writePreview(iframe, html, css, state) {
    const doc = iframe.contentDocument;
    if (!doc) return;
    if (state && state.html === html && doc.getElementById("__user_css")) {
        // Nur CSS geändert: Style austauschen, Scroll-Position bleibt erhalten.
        doc.getElementById("__user_css").textContent = css;
    } else {
        doc.open();
        doc.write(buildDocument(html, css));
        doc.close();
        guardLinks(doc);
    }
    if (state) state.html = html;
}

/** Rendert HTML+CSS einmalig in ein iframe (z. B. für die Projektansicht). */
export function renderStatic(iframe, html, css) {
    writePreview(iframe, html, css, null);
}

// ---------------------------------------------------------------- Editor-Komfort

function enhanceTextarea(ta, onChange) {
    ta.addEventListener("keydown", ev => {
        if (ev.key === "Tab" && !ev.ctrlKey && !ev.altKey && !ev.metaKey) {
            ev.preventDefault();
            insertText(ta, "  ");
        } else if (ev.key === "Enter" && !ev.shiftKey && !ev.ctrlKey && !ev.metaKey) {
            // Einrückung der aktuellen Zeile übernehmen, nach "{" eine Stufe mehr.
            const before = ta.value.substring(0, ta.selectionStart);
            const line = before.substring(before.lastIndexOf("\n") + 1);
            let indent = (line.match(/^\s*/) || [""])[0];
            if (/\{\s*$/.test(line)) indent += "  ";
            ev.preventDefault();
            insertText(ta, "\n" + indent);
        } else if (ev.key === "}") {
            // Schließende Klammer automatisch ausrücken.
            const before = ta.value.substring(0, ta.selectionStart);
            const line = before.substring(before.lastIndexOf("\n") + 1);
            if (/^\s+$/.test(line) && line.length >= 2) {
                ev.preventDefault();
                ta.setSelectionRange(ta.selectionStart - 2, ta.selectionStart);
                insertText(ta, "}");
            }
        }
    });
    ta.addEventListener("input", onChange);
}

function insertText(ta, text) {
    // execCommand erhält die Undo-Historie; Fallback für Browser ohne Unterstützung.
    ta.focus();
    if (!document.execCommand || !document.execCommand("insertText", false, text)) {
        const s = ta.selectionStart, e = ta.selectionEnd;
        ta.value = ta.value.substring(0, s) + text + ta.value.substring(e);
        ta.selectionStart = ta.selectionEnd = s + text.length;
        ta.dispatchEvent(new Event("input"));
    }
}

// ---------------------------------------------------------------- Instanzen

/**
 * Bindet zwei Textareas und ein iframe zu einem Playground zusammen.
 * opts: { html, css, draftKey }
 * Gibt eine Instanz-ID und den tatsächlich geladenen Code zurück.
 */
export function mount(htmlTa, cssTa, iframe, opts) {
    const id = nextId++;
    let html = opts.html ?? "";
    let css = opts.css ?? "";
    let restored = false;
    if (opts.draftKey) {
        const draft = getDraft(opts.draftKey);
        if (draft) {
            if (typeof draft.css === "string") css = draft.css;
            if (typeof draft.html === "string" && htmlTa && !htmlTa.readOnly) html = draft.html;
            restored = true;
        }
    }

    const inst = { htmlTa, cssTa, iframe, draftKey: opts.draftKey, state: { html: null }, timer: 0, saveTimer: 0 };
    instances.set(id, inst);

    if (htmlTa) htmlTa.value = html;
    cssTa.value = css;

    const update = () => {
        clearTimeout(inst.timer);
        inst.timer = setTimeout(() => render(inst), 120);
        if (inst.draftKey) {
            clearTimeout(inst.saveTimer);
            inst.saveTimer = setTimeout(() => saveDraft(inst), 400);
        }
    };
    if (htmlTa && !htmlTa.readOnly) enhanceTextarea(htmlTa, update);
    enhanceTextarea(cssTa, update);

    render(inst);
    return { id, restored };
}

function currentHtml(inst) {
    return inst.htmlTa ? inst.htmlTa.value : (inst.fixedHtml ?? "");
}

function render(inst) {
    writePreview(inst.iframe, currentHtml(inst), inst.cssTa.value, inst.state);
}

function saveDraft(inst) {
    if (!inst.draftKey) return;
    storageSet(DRAFT_PREFIX + inst.draftKey, JSON.stringify({ html: currentHtml(inst), css: inst.cssTa.value }));
}

export function setCode(id, html, css, clearDraft) {
    const inst = instances.get(id);
    if (!inst) return;
    if (inst.htmlTa && html !== null && html !== undefined) inst.htmlTa.value = html;
    inst.cssTa.value = css;
    inst.state.html = null;
    render(inst);
    if (clearDraft && inst.draftKey) storageRemove(DRAFT_PREFIX + inst.draftKey);
    else saveDraft(inst);
}

export function getCode(id) {
    const inst = instances.get(id);
    if (!inst) return null;
    return { html: currentHtml(inst), css: inst.cssTa.value };
}

export function setPreviewWidth(id, width) {
    const inst = instances.get(id);
    if (!inst) return;
    inst.iframe.style.width = width ? width + "px" : "100%";
}

export function dispose(id) {
    const inst = instances.get(id);
    if (!inst) return;
    clearTimeout(inst.timer);
    if (inst.saveTimer) { clearTimeout(inst.saveTimer); saveDraft(inst); }
    instances.delete(id);
}

/** Rendert sofort und führt die Prüfungen aus. */
export function check(id, checks) {
    const inst = instances.get(id);
    if (!inst) return [];
    clearTimeout(inst.timer);
    render(inst);
    saveDraft(inst);
    return runChecks(inst.iframe.contentDocument, checks);
}

// ---------------------------------------------------------------- Prüfungen

const PROBE_TAG = "css-probe";

function normalizeValue(doc, prop, value) {
    const probe = doc.createElement(PROBE_TAG);
    probe.style.setProperty(prop, value);
    if (!probe.style.getPropertyValue(prop)) return String(value).trim();
    // Rahmenbreiten werden nur mit sichtbarem Rahmenstil berechnet.
    const m = prop.match(/^(border(?:-(?:top|right|bottom|left))?|outline)(?:-width)?$/);
    if (m && /width$|^outline$|^border/.test(prop) && !/radius|color|style/.test(prop)) {
        probe.style.setProperty(m[1] + "-style", "solid");
    }
    probe.style.setProperty("display", prop === "display" ? value : "block");
    if (prop !== "display") probe.style.setProperty(prop, value);
    doc.body.appendChild(probe);
    const result = doc.defaultView.getComputedStyle(probe).getPropertyValue(prop);
    probe.remove();
    return result.trim();
}

function canon(prop, value) {
    let v = String(value ?? "").trim().toLowerCase().replace(/\s+/g, " ");
    if (prop === "font-family") v = v.replace(/["']/g, "").replace(/\s*,\s*/g, ",");
    return v;
}

function toNumber(v) {
    const n = parseFloat(v);
    return Number.isNaN(n) ? null : n;
}

function collectRules(list, media, out) {
    for (const rule of Array.from(list || [])) {
        if (rule.type === CSSRule.STYLE_RULE || rule.selectorText !== undefined && rule.style) {
            out.push({ selector: rule.selectorText, style: rule.style, media, rule });
            if (rule.cssRules && rule.cssRules.length) collectRules(rule.cssRules, media, out); // CSS-Nesting
        } else if (rule.media && rule.cssRules) {
            collectRules(rule.cssRules, rule.media.mediaText, out);
        } else if (rule.cssRules) {
            collectRules(rule.cssRules, media, out);
        }
    }
    return out;
}

function helpers(doc) {
    const win = doc.defaultView;
    const sheets = () => Array.from(doc.styleSheets);
    const rules = () => sheets().reduce((acc, s) => { try { collectRules(s.cssRules, null, acc); } catch { } return acc; }, []);
    const toRegex = r => r instanceof RegExp ? r : new RegExp(String(r).replace(/[.*+?^${}()|[\]\\]/g, "\\$&"));
    return {
        q: sel => doc.querySelector(sel),
        qa: sel => Array.from(doc.querySelectorAll(sel)),
        cs: (sel, prop, pseudo) => {
            const el = typeof sel === "string" ? doc.querySelector(sel) : sel;
            return el ? win.getComputedStyle(el, pseudo || null).getPropertyValue(prop).trim() : null;
        },
        norm: (prop, value) => normalizeValue(doc, prop, value),
        rect: sel => { const el = doc.querySelector(sel); return el ? el.getBoundingClientRect() : null; },
        css: () => { const s = doc.getElementById("__user_css"); return s ? s.textContent : ""; },
        rules,
        /** Findet Regeln, deren Selektor auf das Muster passt. opts: { media: true|false|undefined, prop } */
        findRules: (pattern, opts) => {
            const re = toRegex(pattern);
            opts = opts || {};
            return rules().filter(r => r.selector && re.test(r.selector)
                && (opts.media === undefined || (opts.media ? !!r.media : !r.media))
                && (!opts.prop || r.style.getPropertyValue(opts.prop) !== ""));
        },
        /** Angegebener (nicht berechneter) Wert einer Eigenschaft aus der letzten passenden Regel. */
        ruleValue: (pattern, prop, opts) => {
            const found = helpers(doc).findRules(pattern, Object.assign({}, opts, { prop }));
            return found.length ? found[found.length - 1].style.getPropertyValue(prop).trim() : null;
        },
        keyframes: () => {
            const out = [];
            const walk = list => Array.from(list || []).forEach(r => {
                if (r.type === CSSRule.KEYFRAMES_RULE) out.push(r.name);
                else if (r.cssRules) walk(r.cssRules);
            });
            sheets().forEach(s => { try { walk(s.cssRules); } catch { } });
            return out;
        },
        rootVars: () => {
            const names = new Set();
            rules().filter(r => /(^|,)\s*(:root|html)\s*($|,)/.test(r.selector)).forEach(r => {
                for (let i = 0; i < r.style.length; i++) if (r.style[i].startsWith("--")) names.add(r.style[i]);
            });
            return Array.from(names);
        }
    };
}

function runOne(doc, c) {
    const h = helpers(doc);
    if (c.mode === "js") {
        try {
            const fn = new Function("doc", "win", "h", c.script);
            const r = fn(doc, doc.defaultView, h);
            if (r === true) return { passed: true, message: "" };
            return { passed: false, message: typeof r === "string" ? r : "Noch nicht erfüllt." };
        } catch (e) {
            return { passed: false, message: "Prüfung fehlgeschlagen: " + e.message };
        }
    }

    const el = doc.querySelector(c.selector);
    if (!el) return { passed: false, message: `Kein Element für „${c.selector}“ gefunden.` };
    const actualRaw = doc.defaultView.getComputedStyle(el, c.pseudo || null).getPropertyValue(c.property).trim();
    const target = c.selector + (c.pseudo || "");

    switch (c.mode) {
        case "contains": {
            const ok = canon(c.property, actualRaw).includes(canon(c.property, c.expected));
            return ok ? { passed: true, message: "" }
                : { passed: false, message: `${c.property} von ${target} enthält nicht „${c.expected}“ (aktuell: ${actualRaw || "–"}).` };
        }
        case "gte":
        case "lte": {
            const a = toNumber(actualRaw);
            const e = toNumber(normalizeValue(doc, c.property, c.expected));
            const ok = a !== null && e !== null && (c.mode === "gte" ? a >= e - 0.01 : a <= e + 0.01);
            const word = c.mode === "gte" ? "mindestens" : "höchstens";
            return ok ? { passed: true, message: "" }
                : { passed: false, message: `${c.property} von ${target} sollte ${word} ${c.expected} sein (aktuell: ${actualRaw || "–"}).` };
        }
        case "neq": {
            const ok = canon(c.property, actualRaw) !== canon(c.property, normalizeValue(doc, c.property, c.expected));
            return ok ? { passed: true, message: "" }
                : { passed: false, message: `${c.property} von ${target} ist noch „${actualRaw}“ – ändere den Wert.` };
        }
        default: {
            const expected = normalizeValue(doc, c.property, c.expected);
            const ok = canon(c.property, actualRaw) === canon(c.property, expected);
            return ok ? { passed: true, message: "" }
                : { passed: false, message: `${c.property} von ${target}: erwartet ${c.expected}, aktuell ${actualRaw || "–"}.` };
        }
    }
}

export function runChecks(doc, checks) {
    if (!doc || !doc.body) return checks.map(() => ({ passed: false, message: "Vorschau nicht bereit." }));
    return checks.map(c => runOne(doc, c));
}

/** Für den Selbsttest: rendert in ein (verstecktes) iframe und prüft. */
export function evaluate(iframe, html, css, checks) {
    writePreview(iframe, html, css, null);
    return runChecks(iframe.contentDocument, checks);
}

/** Bietet eine vollständige HTML-Datei zum Herunterladen an. */
export function downloadPage(fileName, title, html, css) {
    const page = "<!DOCTYPE html>\n<html lang=\"de\">\n<head>\n<meta charset=\"utf-8\">\n" +
        "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\n" +
        "<title>" + title + "</title>\n<style>\n" + escapeStyle(css) + "\n</style>\n</head>\n<body>\n" + html + "\n</body>\n</html>\n";
    const blob = new Blob([page], { type: "text/html;charset=utf-8" });
    const url = URL.createObjectURL(blob);
    const a = document.createElement("a");
    a.href = url;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();
    a.remove();
    setTimeout(() => URL.revokeObjectURL(url), 1000);
}
