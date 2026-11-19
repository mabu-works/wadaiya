"use strict";
/* 話題ガチャ - app.js
   データ: chat-topic-bot (src/topics.ts) の内蔵話題 全109件を改変せず埋め込み */

const TOPICS = [
 {
  "category": "最近のこと",
  "text": "最近ハマっていることは？"
 },
 {
  "category": "最近のこと",
  "text": "最近買ってよかったものは？"
 },
 {
  "category": "最近のこと",
  "text": "最近見た夢の話をして"
 },
 {
  "category": "最近のこと",
  "text": "最近の小さな幸せは？"
 },
 {
  "category": "最近のこと",
  "text": "最近覚えた新しい言葉や知識は？"
 },
 {
  "category": "最近のこと",
  "text": "最近食べた美味しいものは？"
 },
 {
  "category": "最近のこと",
  "text": "最近聴いている曲は？"
 },
 {
  "category": "最近のこと",
  "text": "最近見た動画・配信で面白かったものは？"
 },
 {
  "category": "最近のこと",
  "text": "最近のマイブームの食べ物・飲み物は？"
 },
 {
  "category": "最近のこと",
  "text": "最近頑張ったことは？"
 },
 {
  "category": "最近のこと",
  "text": "最近失敗したエピソードは？"
 },
 {
  "category": "最近のこと",
  "text": "最近誰かに親切にしてもらったことは？"
 },
 {
  "category": "最近のこと",
  "text": "最近の睡眠事情は？よく眠れてる？"
 },
 {
  "category": "最近のこと",
  "text": "最近気になっているニュースは？"
 },
 {
  "category": "最近のこと",
  "text": "最近スマホで一番使ったアプリは？"
 },
 {
  "category": "最近のこと",
  "text": "最近「大人になったな」と思った瞬間は？"
 },
 {
  "category": "好み・趣味",
  "text": "一番好きな色とその理由は？"
 },
 {
  "category": "好み・趣味",
  "text": "好きな季節とその理由は？"
 },
 {
  "category": "好み・趣味",
  "text": "休日の理想の過ごし方は？"
 },
 {
  "category": "好み・趣味",
  "text": "好きな飲み物は？（お茶・コーヒー・ジュース何でも）"
 },
 {
  "category": "好み・趣味",
  "text": "好きな匂いは？"
 },
 {
  "category": "好み・趣味",
  "text": "集めているものはある？"
 },
 {
  "category": "好み・趣味",
  "text": "得意料理は？（なければ作ってみたい料理）"
 },
 {
  "category": "好み・趣味",
  "text": "好きな映画のジャンルは？"
 },
 {
  "category": "好み・趣味",
  "text": "カラオケの十八番は？"
 },
 {
  "category": "好み・趣味",
  "text": "好きな動物は？"
 },
 {
  "category": "好み・趣味",
  "text": "旅行するなら山派？海派？"
 },
 {
  "category": "好み・趣味",
  "text": "好きな本や漫画のジャンルは？"
 },
 {
  "category": "好み・趣味",
  "text": "昔から変わらない「好き」は？"
 },
 {
  "category": "好み・趣味",
  "text": "新しく始めてみたい趣味は？"
 },
 {
  "category": "好み・趣味",
  "text": "好きな文房具やガジェットは？"
 },
 {
  "category": "好み・趣味",
  "text": "自分を動物に例えると？"
 },
 {
  "category": "もしも話",
  "text": "もし1億円当たったら何に使う？"
 },
 {
  "category": "もしも話",
  "text": "もし1日だけ透明人間になれたら？"
 },
 {
  "category": "もしも話",
  "text": "もし過去に戻れるなら、いつの自分に何て言う？"
 },
 {
  "category": "もしも話",
  "text": "もし無人島に1つだけ持っていけるなら何を持っていく？"
 },
 {
  "category": "もしも話",
  "text": "もし空を飛べたらまずどこへ行く？"
 },
 {
  "category": "もしも話",
  "text": "もし好きな時代に生きられるなら、いつの時代？"
 },
 {
  "category": "もしも話",
  "text": "もし動物と話せるようになったら、まず何を聞く？"
 },
 {
  "category": "もしも話",
  "text": "もし1週間休みがもらえたら何をする？"
 },
 {
  "category": "もしも話",
  "text": "もし時間を止められるなら何に使う？"
 },
 {
  "category": "もしも話",
  "text": "もし自分の店を持てるなら何の店？"
 },
 {
  "category": "もしも話",
  "text": "もし有名人と1日入れ替われるなら誰と入れ替わる？"
 },
 {
  "category": "もしも話",
  "text": "もし明日世界が終わるなら、今日何をする？"
 },
 {
  "category": "もしも話",
  "text": "もし記憶を1つだけ消せるなら何を消す？"
 },
 {
  "category": "もしも話",
  "text": "もし超能力が1つ使えるなら何がいい？"
 },
 {
  "category": "もしも話",
  "text": "もし未来の自分に手紙を書くなら何て書く？"
 },
 {
  "category": "もしも話",
  "text": "もし宝くじで3,000円当たったら何に使う？"
 },
 {
  "category": "思い出",
  "text": "子どもの頃の夢は何だった？"
 },
 {
  "category": "思い出",
  "text": "小学生の頃の給食で好きだったメニューは？"
 },
 {
  "category": "思い出",
  "text": "修学旅行の思い出を教えて"
 },
 {
  "category": "思い出",
  "text": "子どもの頃に流行っていた遊びは？"
 },
 {
  "category": "思い出",
  "text": "初めて買ったCD・ゲーム・漫画は？"
 },
 {
  "category": "思い出",
  "text": "忘れられない先生の言葉は？"
 },
 {
  "category": "思い出",
  "text": "子どもの頃の宝物は何だった？"
 },
 {
  "category": "思い出",
  "text": "夏休みの思い出といえば？"
 },
 {
  "category": "思い出",
  "text": "初めてのおつかいの思い出は？"
 },
 {
  "category": "思い出",
  "text": "昔ハマっていたおもちゃやカードゲームは？"
 },
 {
  "category": "思い出",
  "text": "子どもの頃、秘密基地はあった？"
 },
 {
  "category": "思い出",
  "text": "遠足で一番楽しかった思い出は？"
 },
 {
  "category": "思い出",
  "text": "昔の自分に自慢できることは？"
 },
 {
  "category": "思い出",
  "text": "初めて自分のお金で買った大きなものは？"
 },
 {
  "category": "思い出",
  "text": "子どもの頃の怖かった話は？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "人生で一番長く遊んだゲームは？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "初めてクリアしたゲームは？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "好きなゲームのBGMは？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "最近遊んでいるゲームの進捗は？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "一番好きなアニメ作品は？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "アニメの推しキャラはいる？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "好きなアーティスト・バンドは？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "初めて行ったライブやイベントの思い出は？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "ゲームで一番苦戦したボスは？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "好きなゲームジャンルは？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "懐かしのゲームといえば？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "最近聴いて感動した曲は？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "アニメ化してほしい漫画・ゲームは？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "好きな声優さんはいる？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "ゲームの実況でよく見る人はいる？"
 },
 {
  "category": "ゲーム・音楽・アニメ",
  "text": "自分がゲームの主人公なら、どんな能力がほしい？"
 },
 {
  "category": "食べ物",
  "text": "最後の晩餐に食べたいものは？"
 },
 {
  "category": "食べ物",
  "text": "好きなラーメンの味は？（醤油・味噌・塩・豚骨）"
 },
 {
  "category": "食べ物",
  "text": "朝ごはんはパン派？ごはん派？"
 },
 {
  "category": "食べ物",
  "text": "好きな駄菓子は？"
 },
 {
  "category": "食べ物",
  "text": "コンビニで必ず買うものは？"
 },
 {
  "category": "食べ物",
  "text": "苦手な食べ物とその理由は？"
 },
 {
  "category": "食べ物",
  "text": "好きな鍋の味は？"
 },
 {
  "category": "食べ物",
  "text": "自分で作る料理で一番の自信作は？"
 },
 {
  "category": "食べ物",
  "text": "好きなアイスの味は？"
 },
 {
  "category": "食べ物",
  "text": "ご飯のお供といえば？"
 },
 {
  "category": "食べ物",
  "text": "好きな寿司ネタは？"
 },
 {
  "category": "食べ物",
  "text": "辛いものは得意？一番辛くて美味しかったものは？"
 },
 {
  "category": "食べ物",
  "text": "好きなファストフード店と定番メニューは？"
 },
 {
  "category": "食べ物",
  "text": "給食の揚げパン、きなこ派だった？思い出の味は？"
 },
 {
  "category": "食べ物",
  "text": "最近食べて衝撃を受けた食べ物は？"
 },
 {
  "category": "季節・日常",
  "text": "今日の天気、どう感じた？"
 },
 {
  "category": "季節・日常",
  "text": "朝型？夜型？自分のリズムは？"
 },
 {
  "category": "季節・日常",
  "text": "今日一番嬉しかったことは？"
 },
 {
  "category": "季節・日常",
  "text": "明日の自分に一言かけるなら？"
 },
 {
  "category": "季節・日常",
  "text": "最近の天気で困ったことは？"
 },
 {
  "category": "季節・日常",
  "text": "季節の変わり目、体調管理で気をつけていることは？"
 },
 {
  "category": "季節・日常",
  "text": "今日のご飯は何だった？"
 },
 {
  "category": "季節・日常",
  "text": "部屋の中で一番落ち着く場所は？"
 },
 {
  "category": "季節・日常",
  "text": "通勤・通学中にしていることは？"
 },
 {
  "category": "季節・日常",
  "text": "今日の服装のポイントは？"
 },
 {
  "category": "季節・日常",
  "text": "最近の天気予報、当たってる？外れてる？"
 },
 {
  "category": "季節・日常",
  "text": "一日のうちで一番好きな時間帯は？"
 },
 {
  "category": "季節・日常",
  "text": "明日天気になあれ、明日したいことは？"
 },
 {
  "category": "季節・日常",
  "text": "最近あった「小さなラッキー」は？"
 },
 {
  "category": "季節・日常",
  "text": "今日を漢字一文字で表すと？"
 }
];

const CATEGORIES = [...new Set(TOPICS.map((t) => t.category))];
const FAV_KEY = "wadai-gacha-favorites-v1";
const ALL = "すべて";

let selectedCategory = ALL;
let current = null;        // 現在表示中の話題 {category, text}
let lastText = null;       // 直前に引いた話題 (連続重複回避用)
let history = [];          // このセッションで引いた履歴 (新しい順に表示)
let favorites = loadFavorites();
let spinning = false;

const $ = (id) => document.getElementById(id);
const els = {
  chips: $("categoryChips"),
  card: $("topicCard"),
  machine: document.querySelector(".capsule-machine"),
  category: $("topicCategory"),
  text: $("topicText"),
  meta: $("topicMeta"),
  gachaBtn: $("gachaBtn"),
  note: $("gachaNote"),
  copyBtn: $("copyBtn"),
  shareLink: $("shareLink"),
  favBtn: $("favBtn"),
  toast: $("toast"),
  statTotal: $("statTotal"),
  statPool: $("statPool"),
  statRemaining: $("statRemaining"),
  statDrawn: $("statDrawn"),
  historyList: $("historyList"),
  historyEmpty: $("historyEmpty"),
  historyCount: $("historyCount"),
  favList: $("favList"),
  favEmpty: $("favEmpty"),
  favCount: $("favCount"),
};

function loadFavorites() {
  try {
    const raw = localStorage.getItem(FAV_KEY);
    if (!raw) return [];
    const arr = JSON.parse(raw);
    if (!Array.isArray(arr)) return [];
    // 実在する話題だけを残す
    return arr.filter((x) => x && TOPICS.some((t) => t.text === x.text));
  } catch (e) {
    return [];
  }
}
function saveFavorites() {
  try { localStorage.setItem(FAV_KEY, JSON.stringify(favorites)); } catch (e) { /* 保存不可でも動作継続 */ }
}
function isFav(text) { return favorites.some((f) => f.text === text); }

function getPool() {
  return selectedCategory === ALL ? TOPICS.slice() : TOPICS.filter((t) => t.category === selectedCategory);
}

function showToast(msg) {
  els.toast.textContent = msg;
  window.clearTimeout(showToast._t);
  showToast._t = window.setTimeout(() => { els.toast.textContent = ""; }, 2600);
}

function renderChips() {
  els.chips.innerHTML = "";
  const defs = [{ name: ALL, count: TOPICS.length }]
    .concat(CATEGORIES.map((c) => ({ name: c, count: TOPICS.filter((t) => t.category === c).length })));
  defs.forEach((d) => {
    const b = document.createElement("button");
    b.type = "button";
    b.className = "chip" + (selectedCategory === d.name ? " active" : "");
    b.innerHTML = "";
    b.appendChild(document.createTextNode(d.name));
    const sm = document.createElement("small");
    sm.textContent = d.count + "件";
    b.appendChild(sm);
    b.addEventListener("click", () => {
      selectedCategory = d.name;
      renderChips();
      updateStats();
      els.note.textContent = d.name === ALL
        ? "全" + TOPICS.length + "件からランダム表示（直前と同じ話題は出ません）"
        : "「" + d.name + "」の " + d.count + " 件からランダム表示（直前と同じ話題は出ません）";
    });
    els.chips.appendChild(b);
  });
}

function updateStats() {
  const pool = getPool();
  const drawnInPool = new Set(history.filter((h) => pool.some((p) => p.text === h.text)).map((h) => h.text));
  els.statTotal.textContent = String(TOPICS.length);
  els.statPool.textContent = String(pool.length);
  els.statRemaining.textContent = String(Math.max(0, pool.length - drawnInPool.size));
  els.statDrawn.textContent = String(history.length);
  els.historyCount.textContent = String(history.length);
  els.favCount.textContent = String(favorites.length);
}

function updateActions() {
  const has = !!current;
  els.copyBtn.disabled = !has;
  els.favBtn.disabled = !has;
  if (has) {
    const shareText = "【話題ガチャ】" + current.text + "（カテゴリ: " + current.category + "） #話題ガチャ #まぶ鯖";
    els.shareLink.href = "https://twitter.com/intent/tweet?text=" + encodeURIComponent(shareText);
    els.shareLink.removeAttribute("aria-disabled");
    els.favBtn.textContent = isFav(current.text) ? "★ お気に入り済み" : "☆ お気に入り";
    els.favBtn.classList.toggle("is-fav", isFav(current.text));
  } else {
    els.shareLink.href = "#";
    els.shareLink.setAttribute("aria-disabled", "true");
    els.favBtn.textContent = "☆ お気に入り";
    els.favBtn.classList.remove("is-fav");
  }
}

function displayTopic(topic, count) {
  current = topic;
  els.category.textContent = topic.category;
  els.text.textContent = topic.text;
  els.meta.textContent = count ? ("通算 " + count + " 回目に引いた話題") : "";
  els.card.classList.remove("pop");
  void els.card.offsetWidth; // アニメーション再発火
  els.card.classList.add("pop");
  updateActions();
}

function spin() {
  if (spinning) return;
  const pool = getPool();
  if (pool.length === 0) { showToast("対象の話題がありません"); return; }
  spinning = true;
  els.gachaBtn.disabled = true;
  els.card.classList.add("shuffling");
  if (els.machine) els.machine.classList.add("spinning");

  // 最終候補: 直前と同じ話題は避ける (候補が2件以上ある場合)
  let candidates = pool;
  if (pool.length > 1 && lastText) {
    const filtered = pool.filter((t) => t.text !== lastText);
    if (filtered.length > 0) candidates = filtered;
  }
  const finalTopic = candidates[Math.floor(Math.random() * candidates.length)];

  const started = Date.now();
  const timer = window.setInterval(() => {
    const r = pool[Math.floor(Math.random() * pool.length)];
    els.category.textContent = r.category;
    els.text.textContent = r.text;
    if (Date.now() - started >= 900) {
      window.clearInterval(timer);
      spinning = false;
      els.gachaBtn.disabled = false;
      els.card.classList.remove("shuffling");
      if (els.machine) els.machine.classList.remove("spinning");
      lastText = finalTopic.text;
      history.unshift(finalTopic);
      displayTopic(finalTopic, history.length);
      renderHistory();
      updateStats();
    }
  }, 70);
}

function renderHistory() {
  els.historyList.innerHTML = "";
  els.historyEmpty.style.display = history.length ? "none" : "";
  history.forEach((h) => {
    els.historyList.appendChild(makeListItem(h, false));
  });
}
function renderFavorites() {
  els.favList.innerHTML = "";
  els.favEmpty.style.display = favorites.length ? "none" : "";
  favorites.forEach((f) => {
    els.favList.appendChild(makeListItem(f, true));
  });
  updateStats();
  updateActions();
}
function makeListItem(topic, isFavList) {
  const li = document.createElement("li");
  const main = document.createElement("div");
  main.className = "li-main";
  const cat = document.createElement("span");
  cat.className = "li-cat";
  cat.textContent = topic.category;
  const tx = document.createElement("span");
  tx.className = "li-text";
  tx.textContent = topic.text;
  main.appendChild(cat);
  main.appendChild(tx);
  main.title = "タップで表示";
  main.addEventListener("click", () => { displayTopic(topic, 0); window.scrollTo({ top: 0, behavior: "smooth" }); });
  li.appendChild(main);
  if (isFavList) {
    const del = document.createElement("button");
    del.type = "button";
    del.className = "li-del";
    del.textContent = "★";
    del.title = "お気に入りから外す";
    del.addEventListener("click", () => {
      favorites = favorites.filter((f) => f.text !== topic.text);
      saveFavorites();
      renderFavorites();
      showToast("お気に入りから外しました");
    });
    li.appendChild(del);
  }
  return li;
}

els.gachaBtn.addEventListener("click", spin);

els.copyBtn.addEventListener("click", async () => {
  if (!current) return;
  const text = current.text;
  try {
    await navigator.clipboard.writeText(text);
    showToast("コピーしました 📋");
  } catch (e) {
    const ta = document.createElement("textarea");
    ta.value = text;
    document.body.appendChild(ta);
    ta.select();
    try { document.execCommand("copy"); showToast("コピーしました 📋"); }
    catch (e2) { showToast("コピーできませんでした"); }
    document.body.removeChild(ta);
  }
});

els.favBtn.addEventListener("click", () => {
  if (!current) return;
  if (isFav(current.text)) {
    favorites = favorites.filter((f) => f.text !== current.text);
    showToast("お気に入りから外しました");
  } else {
    favorites.unshift({ category: current.category, text: current.text });
    showToast("お気に入りに保存しました ⭐");
  }
  saveFavorites();
  renderFavorites();
});

$("clearHistoryBtn").addEventListener("click", () => {
  history = [];
  lastText = current ? current.text : null;
  renderHistory();
  updateStats();
  showToast("履歴を消しました");
});
$("clearFavBtn").addEventListener("click", () => {
  favorites = [];
  saveFavorites();
  renderFavorites();
  showToast("お気に入りを全部外しました");
});

// 初期化
renderChips();
renderHistory();
renderFavorites();
updateStats();
updateActions();
