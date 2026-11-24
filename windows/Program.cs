using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using System.Windows.Forms;

namespace Wadaiya
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }

    internal sealed class TopicItem
    {
        public string Category { get; set; } = "";
        public string Text { get; set; } = "";
    }

    internal sealed class MainForm : Form
    {
        // Web版（wadaiya）と同じ話題データ全109件（chat-topic-bot 内蔵話題）
        private static readonly (string Category, string Text)[] Topics =
        {
            ("最近のこと", "最近ハマっていることは？"),
            ("最近のこと", "最近買ってよかったものは？"),
            ("最近のこと", "最近見た夢の話をして"),
            ("最近のこと", "最近の小さな幸せは？"),
            ("最近のこと", "最近覚えた新しい言葉や知識は？"),
            ("最近のこと", "最近食べた美味しいものは？"),
            ("最近のこと", "最近聴いている曲は？"),
            ("最近のこと", "最近見た動画・配信で面白かったものは？"),
            ("最近のこと", "最近のマイブームの食べ物・飲み物は？"),
            ("最近のこと", "最近頑張ったことは？"),
            ("最近のこと", "最近失敗したエピソードは？"),
            ("最近のこと", "最近誰かに親切にしてもらったことは？"),
            ("最近のこと", "最近の睡眠事情は？よく眠れてる？"),
            ("最近のこと", "最近気になっているニュースは？"),
            ("最近のこと", "最近スマホで一番使ったアプリは？"),
            ("最近のこと", "最近「大人になったな」と思った瞬間は？"),
            ("好み・趣味", "一番好きな色とその理由は？"),
            ("好み・趣味", "好きな季節とその理由は？"),
            ("好み・趣味", "休日の理想の過ごし方は？"),
            ("好み・趣味", "好きな飲み物は？（お茶・コーヒー・ジュース何でも）"),
            ("好み・趣味", "好きな匂いは？"),
            ("好み・趣味", "集めているものはある？"),
            ("好み・趣味", "得意料理は？（なければ作ってみたい料理）"),
            ("好み・趣味", "好きな映画のジャンルは？"),
            ("好み・趣味", "カラオケの十八番は？"),
            ("好み・趣味", "好きな動物は？"),
            ("好み・趣味", "旅行するなら山派？海派？"),
            ("好み・趣味", "好きな本や漫画のジャンルは？"),
            ("好み・趣味", "昔から変わらない「好き」は？"),
            ("好み・趣味", "新しく始めてみたい趣味は？"),
            ("好み・趣味", "好きな文房具やガジェットは？"),
            ("好み・趣味", "自分を動物に例えると？"),
            ("もしも話", "もし1億円当たったら何に使う？"),
            ("もしも話", "もし1日だけ透明人間になれたら？"),
            ("もしも話", "もし過去に戻れるなら、いつの自分に何て言う？"),
            ("もしも話", "もし無人島に1つだけ持っていけるなら何を持っていく？"),
            ("もしも話", "もし空を飛べたらまずどこへ行く？"),
            ("もしも話", "もし好きな時代に生きられるなら、いつの時代？"),
            ("もしも話", "もし動物と話せるようになったら、まず何を聞く？"),
            ("もしも話", "もし1週間休みがもらえたら何をする？"),
            ("もしも話", "もし時間を止められるなら何に使う？"),
            ("もしも話", "もし自分の店を持てるなら何の店？"),
            ("もしも話", "もし有名人と1日入れ替われるなら誰と入れ替わる？"),
            ("もしも話", "もし明日世界が終わるなら、今日何をする？"),
            ("もしも話", "もし記憶を1つだけ消せるなら何を消す？"),
            ("もしも話", "もし超能力が1つ使えるなら何がいい？"),
            ("もしも話", "もし未来の自分に手紙を書くなら何て書く？"),
            ("もしも話", "もし宝くじで3,000円当たったら何に使う？"),
            ("思い出", "子どもの頃の夢は何だった？"),
            ("思い出", "小学生の頃の給食で好きだったメニューは？"),
            ("思い出", "修学旅行の思い出を教えて"),
            ("思い出", "子どもの頃に流行っていた遊びは？"),
            ("思い出", "初めて買ったCD・ゲーム・漫画は？"),
            ("思い出", "忘れられない先生の言葉は？"),
            ("思い出", "子どもの頃の宝物は何だった？"),
            ("思い出", "夏休みの思い出といえば？"),
            ("思い出", "初めてのおつかいの思い出は？"),
            ("思い出", "昔ハマっていたおもちゃやカードゲームは？"),
            ("思い出", "子どもの頃、秘密基地はあった？"),
            ("思い出", "遠足で一番楽しかった思い出は？"),
            ("思い出", "昔の自分に自慢できることは？"),
            ("思い出", "初めて自分のお金で買った大きなものは？"),
            ("思い出", "子どもの頃の怖かった話は？"),
            ("ゲーム・音楽・アニメ", "人生で一番長く遊んだゲームは？"),
            ("ゲーム・音楽・アニメ", "初めてクリアしたゲームは？"),
            ("ゲーム・音楽・アニメ", "好きなゲームのBGMは？"),
            ("ゲーム・音楽・アニメ", "最近遊んでいるゲームの進捗は？"),
            ("ゲーム・音楽・アニメ", "一番好きなアニメ作品は？"),
            ("ゲーム・音楽・アニメ", "アニメの推しキャラはいる？"),
            ("ゲーム・音楽・アニメ", "好きなアーティスト・バンドは？"),
            ("ゲーム・音楽・アニメ", "初めて行ったライブやイベントの思い出は？"),
            ("ゲーム・音楽・アニメ", "ゲームで一番苦戦したボスは？"),
            ("ゲーム・音楽・アニメ", "好きなゲームジャンルは？"),
            ("ゲーム・音楽・アニメ", "懐かしのゲームといえば？"),
            ("ゲーム・音楽・アニメ", "最近聴いて感動した曲は？"),
            ("ゲーム・音楽・アニメ", "アニメ化してほしい漫画・ゲームは？"),
            ("ゲーム・音楽・アニメ", "好きな声優さんはいる？"),
            ("ゲーム・音楽・アニメ", "ゲームの実況でよく見る人はいる？"),
            ("ゲーム・音楽・アニメ", "自分がゲームの主人公なら、どんな能力がほしい？"),
            ("食べ物", "最後の晩餐に食べたいものは？"),
            ("食べ物", "好きなラーメンの味は？（醤油・味噌・塩・豚骨）"),
            ("食べ物", "朝ごはんはパン派？ごはん派？"),
            ("食べ物", "好きな駄菓子は？"),
            ("食べ物", "コンビニで必ず買うものは？"),
            ("食べ物", "苦手な食べ物とその理由は？"),
            ("食べ物", "好きな鍋の味は？"),
            ("食べ物", "自分で作る料理で一番の自信作は？"),
            ("食べ物", "好きなアイスの味は？"),
            ("食べ物", "ご飯のお供といえば？"),
            ("食べ物", "好きな寿司ネタは？"),
            ("食べ物", "辛いものは得意？一番辛くて美味しかったものは？"),
            ("食べ物", "好きなファストフード店と定番メニューは？"),
            ("食べ物", "給食の揚げパン、きなこ派だった？思い出の味は？"),
            ("食べ物", "最近食べて衝撃を受けた食べ物は？"),
            ("季節・日常", "今日の天気、どう感じた？"),
            ("季節・日常", "朝型？夜型？自分のリズムは？"),
            ("季節・日常", "今日一番嬉しかったことは？"),
            ("季節・日常", "明日の自分に一言かけるなら？"),
            ("季節・日常", "最近の天気で困ったことは？"),
            ("季節・日常", "季節の変わり目、体調管理で気をつけていることは？"),
            ("季節・日常", "今日のご飯は何だった？"),
            ("季節・日常", "部屋の中で一番落ち着く場所は？"),
            ("季節・日常", "通勤・通学中にしていることは？"),
            ("季節・日常", "今日の服装のポイントは？"),
            ("季節・日常", "最近の天気予報、当たってる？外れてる？"),
            ("季節・日常", "一日のうちで一番好きな時間帯は？"),
            ("季節・日常", "明日天気になあれ、明日したいことは？"),
            ("季節・日常", "最近あった「小さなラッキー」は？"),
            ("季節・日常", "今日を漢字一文字で表すと？"),
        };

        private const string All = "すべて";

        private static readonly Color Bg = Color.FromArgb(10, 15, 28);
        private static readonly Color Surface = Color.FromArgb(17, 26, 46);
        private static readonly Color TextColor = Color.FromArgb(236, 241, 248);
        private static readonly Color Muted = Color.FromArgb(157, 177, 199);
        private static readonly Color Accent = Color.FromArgb(106, 141, 255);
        private static readonly Color Accent2 = Color.FromArgb(45, 212, 191);
        private static readonly Color Gold = Color.FromArgb(251, 191, 36);

        private readonly Label statsLabel;
        private readonly ComboBox categoryBox;
        private readonly Label noteLabel;
        private readonly Label cardCategory;
        private readonly Label cardText;
        private readonly Label cardMeta;
        private readonly Button gachaBtn;
        private readonly Button copyBtn;
        private readonly Button favBtn;
        private readonly Label toastLabel;
        private readonly Label historyTitle;
        private readonly ListBox historyList;
        private readonly Label historyEmpty;
        private readonly Label favTitle;
        private readonly ListBox favList;
        private readonly Label favEmpty;
        private readonly System.Windows.Forms.Timer spinTimer;

        private string _selectedCategory = All;
        private (string Category, string Text)? _current;
        private string? _lastText;
        private readonly List<(string Category, string Text)> _history = new List<(string, string)>();
        private List<TopicItem> _favorites = new List<TopicItem>();
        private bool _spinning;
        private (string Category, string Text) _finalTopic;
        private int _spinTicks;
        private bool _suppressDisplay;

        public MainForm()
        {
            Text = "話題ガチャ for Windows";
            ClientSize = new Size(640, 856);
            MinimumSize = new Size(656, 895);
            BackColor = Bg;
            ForeColor = TextColor;
            Font = new Font("Yu Gothic UI", 10F);

            var title = new Label
            {
                Text = "話題ガチャ",
                Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold),
                ForeColor = TextColor,
                Location = new Point(20, 14),
                AutoSize = true
            };
            Controls.Add(title);

            statsLabel = new Label
            {
                Text = "",
                ForeColor = Muted,
                Location = new Point(20, 54),
                AutoSize = true
            };
            Controls.Add(statsLabel);

            var catHead = new Label
            {
                Text = "カテゴリで絞り込む",
                ForeColor = Muted,
                Location = new Point(20, 86),
                AutoSize = true
            };
            Controls.Add(catHead);

            categoryBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(20, 112),
                Width = 300,
                BackColor = Surface,
                ForeColor = TextColor
            };
            categoryBox.Items.Add($"{All}（{Topics.Length}件）");
            foreach (var c in Categories())
            {
                int n = 0;
                foreach (var t in Topics) if (t.Category == c) n++;
                categoryBox.Items.Add($"{c}（{n}件）");
            }
            categoryBox.SelectedIndex = 0;
            categoryBox.SelectedIndexChanged += (s, e) =>
            {
                var cats = Categories();
                _selectedCategory = categoryBox.SelectedIndex == 0 ? All : cats[categoryBox.SelectedIndex - 1];
                var pool = GetPool();
                noteLabel.Text = _selectedCategory == All
                    ? $"全{Topics.Length}件からランダム表示（直前と同じ話題は出ません）"
                    : $"「{_selectedCategory}」の {pool.Count} 件からランダム表示（直前と同じ話題は出ません）";
                UpdateStats();
            };
            Controls.Add(categoryBox);

            noteLabel = new Label
            {
                Text = $"全{Topics.Length}件からランダム表示（直前と同じ話題は出ません）",
                ForeColor = Muted,
                Font = new Font("Yu Gothic UI", 9F),
                Location = new Point(20, 144),
                AutoSize = true
            };
            Controls.Add(noteLabel);

            var card = new Panel
            {
                Location = new Point(20, 172),
                Size = new Size(600, 124),
                BackColor = Surface
            };
            Controls.Add(card);
            cardCategory = new Label
            {
                Text = "準備OK",
                ForeColor = Accent2,
                Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold),
                Location = new Point(16, 12),
                AutoSize = true
            };
            card.Controls.Add(cardCategory);
            cardText = new Label
            {
                Text = "ボタンを押すと、話題が1つ出てくるよ。何が出るかはお楽しみ！",
                ForeColor = TextColor,
                Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold),
                Location = new Point(16, 42),
                Size = new Size(568, 48)
            };
            card.Controls.Add(cardText);
            cardMeta = new Label
            {
                Text = "",
                ForeColor = Muted,
                Font = new Font("Yu Gothic UI", 9F),
                Location = new Point(16, 96),
                AutoSize = true
            };
            card.Controls.Add(cardMeta);

            gachaBtn = new Button
            {
                Text = "🎲 ガチャを回す",
                Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold),
                BackColor = Accent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(20, 308),
                Size = new Size(600, 44)
            };
            gachaBtn.FlatAppearance.BorderSize = 0;
            gachaBtn.Click += (s, e) => Spin();
            Controls.Add(gachaBtn);

            copyBtn = SubButton("📋 結果をコピー", 20, 364, 180);
            copyBtn.Enabled = false;
            copyBtn.Click += (s, e) => CopyCurrent();
            Controls.Add(copyBtn);

            favBtn = SubButton("☆ お気に入り", 212, 364, 180);
            favBtn.Enabled = false;
            favBtn.Click += (s, e) => ToggleFavorite();
            Controls.Add(favBtn);

            toastLabel = new Label
            {
                Text = "",
                ForeColor = Accent2,
                Location = new Point(20, 408),
                AutoSize = true
            };
            Controls.Add(toastLabel);

            historyTitle = SectionTitle("🕘 引いた履歴（0）", 438);
            Controls.Add(historyTitle);
            var clearHistoryBtn = SubButton("履歴を消す", 480, 434, 140);
            clearHistoryBtn.Click += (s, e) =>
            {
                _history.Clear();
                _lastText = _current?.Text;
                RenderHistory();
                UpdateStats();
                ShowToast("履歴を消しました");
            };
            Controls.Add(clearHistoryBtn);

            historyEmpty = EmptyLabel("まだ引いていません。ガチャを回してみよう！", 470);
            Controls.Add(historyEmpty);
            historyList = new ListBox
            {
                Location = new Point(20, 468),
                Size = new Size(600, 140),
                BackColor = Surface,
                ForeColor = TextColor,
                BorderStyle = BorderStyle.FixedSingle
            };
            historyList.SelectedIndexChanged += (s, e) =>
            {
                if (_suppressDisplay || historyList.SelectedIndex < 0) return;
                DisplayTopic(_history[historyList.SelectedIndex], 0);
            };
            Controls.Add(historyList);

            favTitle = SectionTitle("⭐ お気に入り（0）", 622);
            Controls.Add(favTitle);
            var clearFavBtn = SubButton("全部外す", 480, 618, 140);
            clearFavBtn.Click += (s, e) =>
            {
                _favorites.Clear();
                SaveFavorites();
                RenderFavorites();
                ShowToast("お気に入りを全部外しました");
            };
            Controls.Add(clearFavBtn);

            favEmpty = EmptyLabel("気に入った話題は ☆ ボタンで保存できます（この端末に保存されます）。", 654);
            Controls.Add(favEmpty);
            favList = new ListBox
            {
                Location = new Point(20, 652),
                Size = new Size(600, 140),
                BackColor = Surface,
                ForeColor = TextColor,
                BorderStyle = BorderStyle.FixedSingle
            };
            favList.SelectedIndexChanged += (s, e) =>
            {
                if (_suppressDisplay || favList.SelectedIndex < 0) return;
                var f = _favorites[favList.SelectedIndex];
                DisplayTopic((f.Category, f.Text), 0);
            };
            Controls.Add(favList);

            var removeFavBtn = SubButton("選択中をお気に入りから外す", 20, 804, 240);
            removeFavBtn.Click += (s, e) =>
            {
                if (favList.SelectedIndex < 0) return;
                var f = _favorites[favList.SelectedIndex];
                _favorites.RemoveAll(x => x.Text == f.Text);
                SaveFavorites();
                RenderFavorites();
                ShowToast("お気に入りから外しました");
            };
            Controls.Add(removeFavBtn);

            spinTimer = new System.Windows.Forms.Timer { Interval = 70 };
            spinTimer.Tick += SpinTimer_Tick;

            _favorites = LoadFavorites();
            RenderHistory();
            RenderFavorites();
            UpdateStats();
            UpdateActions();
        }

        private Button SubButton(string text, int x, int y, int w)
        {
            var b = new Button
            {
                Text = text,
                BackColor = Surface,
                ForeColor = TextColor,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(x, y),
                Size = new Size(w, 36)
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }

        private Label SectionTitle(string text, int y)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold),
                ForeColor = TextColor,
                Location = new Point(20, y),
                AutoSize = true
            };
        }

        private Label EmptyLabel(string text, int y)
        {
            return new Label
            {
                Text = text,
                ForeColor = Muted,
                Location = new Point(20, y),
                AutoSize = true
            };
        }

        private static List<string> Categories()
        {
            var list = new List<string>();
            foreach (var t in Topics)
                if (!list.Contains(t.Category)) list.Add(t.Category);
            return list;
        }

        private List<(string Category, string Text)> GetPool()
        {
            var pool = new List<(string, string)>();
            foreach (var t in Topics)
                if (_selectedCategory == All || t.Category == _selectedCategory) pool.Add(t);
            return pool;
        }

        private void ShowToast(string msg)
        {
            toastLabel.Text = msg;
        }

        private void UpdateStats()
        {
            var pool = GetPool();
            var drawn = new HashSet<string>();
            foreach (var h in _history)
                foreach (var p in pool)
                    if (p.Text == h.Text) drawn.Add(h.Text);
            statsLabel.Text = $"全話題 {Topics.Length}件 ／ 表示中の話題数 {pool.Count}件 ／ まだ引いてない {Math.Max(0, pool.Count - drawn.Count)}件 ／ 引いた回数 {_history.Count}回";
            historyTitle.Text = $"🕘 引いた履歴（{_history.Count}）";
            favTitle.Text = $"⭐ お気に入り（{_favorites.Count}）";
        }

        private bool IsFav(string text) => _favorites.Exists(f => f.Text == text);

        private void UpdateActions()
        {
            bool has = _current != null;
            copyBtn.Enabled = has;
            favBtn.Enabled = has;
            if (has)
            {
                bool fav = IsFav(_current!.Value.Text);
                favBtn.Text = fav ? "★ お気に入り済み" : "☆ お気に入り";
                favBtn.ForeColor = fav ? Gold : TextColor;
            }
            else
            {
                favBtn.Text = "☆ お気に入り";
                favBtn.ForeColor = TextColor;
            }
        }

        private void DisplayTopic((string Category, string Text) topic, int count)
        {
            _current = topic;
            cardCategory.Text = topic.Category;
            cardText.Text = topic.Text;
            cardMeta.Text = count > 0 ? $"通算 {count} 回目に引いた話題" : "";
            UpdateActions();
        }

        private void Spin()
        {
            if (_spinning) return;
            var pool = GetPool();
            if (pool.Count == 0) { ShowToast("対象の話題がありません"); return; }

            // 最終候補: 直前と同じ話題は避ける（候補が2件以上ある場合。Web版と同じ）
            var candidates = pool;
            if (pool.Count > 1 && _lastText != null)
            {
                var filtered = pool.FindAll(t => t.Text != _lastText);
                if (filtered.Count > 0) candidates = filtered;
            }
            _finalTopic = candidates[RandomNumberGenerator.GetInt32(candidates.Count)];

            _spinning = true;
            _spinTicks = 0;
            gachaBtn.Enabled = false;
            spinTimer.Start();
        }

        private void SpinTimer_Tick(object? sender, EventArgs e)
        {
            _spinTicks++;
            var pool = GetPool();
            if (_spinTicks * 70 >= 900)
            {
                spinTimer.Stop();
                _spinning = false;
                gachaBtn.Enabled = true;
                _lastText = _finalTopic.Text;
                _history.Insert(0, _finalTopic);
                DisplayTopic(_finalTopic, _history.Count);
                RenderHistory();
                UpdateStats();
                return;
            }
            var r = pool[RandomNumberGenerator.GetInt32(pool.Count)];
            cardCategory.Text = r.Category;
            cardText.Text = r.Text;
        }

        private void RenderHistory()
        {
            _suppressDisplay = true;
            historyList.Items.Clear();
            foreach (var h in _history) historyList.Items.Add($"[{h.Category}] {h.Text}");
            historyList.SelectedIndex = -1;
            _suppressDisplay = false;
            historyEmpty.Visible = _history.Count == 0;
            historyList.Visible = _history.Count > 0;
        }

        private void RenderFavorites()
        {
            _suppressDisplay = true;
            favList.Items.Clear();
            foreach (var f in _favorites) favList.Items.Add($"[{f.Category}] {f.Text}");
            favList.SelectedIndex = -1;
            _suppressDisplay = false;
            favEmpty.Visible = _favorites.Count == 0;
            favList.Visible = _favorites.Count > 0;
            UpdateStats();
            UpdateActions();
        }

        private void CopyCurrent()
        {
            if (_current == null) return;
            try
            {
                Clipboard.SetText(_current.Value.Text);
                ShowToast("コピーしました 📋");
            }
            catch
            {
                ShowToast("コピーできませんでした");
            }
        }

        private void ToggleFavorite()
        {
            if (_current == null) return;
            var cur = _current.Value;
            if (IsFav(cur.Text))
            {
                _favorites.RemoveAll(f => f.Text == cur.Text);
                ShowToast("お気に入りから外しました");
            }
            else
            {
                _favorites.Insert(0, new TopicItem { Category = cur.Category, Text = cur.Text });
                ShowToast("お気に入りに保存しました ⭐");
            }
            SaveFavorites();
            RenderFavorites();
        }

        // ===== お気に入りの保存（Web版 localStorage 相当） =====
        private static string DataPath =>
            Path.Combine(Application.LocalUserAppDataPath, "wadaiya-favorites.json");

        private List<TopicItem> LoadFavorites()
        {
            try
            {
                if (!File.Exists(DataPath)) return new List<TopicItem>();
                var arr = JsonSerializer.Deserialize<List<TopicItem>>(File.ReadAllText(DataPath));
                if (arr == null) return new List<TopicItem>();
                // 実在する話題だけを残す（Web版と同じ）
                var valid = new List<TopicItem>();
                foreach (var x in arr)
                {
                    bool exists = false;
                    foreach (var t in Topics) if (t.Text == x.Text) { exists = true; break; }
                    if (exists) valid.Add(x);
                }
                return valid;
            }
            catch { return new List<TopicItem>(); }
        }

        private void SaveFavorites()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(DataPath)!);
                File.WriteAllText(DataPath, JsonSerializer.Serialize(_favorites));
            }
            catch { /* 保存不可でも動作継続（Web版と同じ） */ }
        }
    }
}
