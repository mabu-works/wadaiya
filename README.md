# 話題ガチャ

雑談の話題をランダムで引けるガチャ Web アプリ。
Discord Bot「Chat Topic Bot」内蔵の話題109件（7カテゴリ）をそのまま収録。

🌐 公開先: [wadaiya.vercel.app](https://wadaiya.vercel.app)
📜 更新履歴: [CHANGELOG.md](CHANGELOG.md)

## ✨ 機能

- カテゴリ絞り込み、履歴、お気に入り（localStorage）対応
- 結果のコピーと X シェアに対応

## 📝 使い方

1. ガチャを引くと、雑談の話題がランダムで表示されます。
2. カテゴリで絞り込むことができ、引いた話題は履歴に残ります。気に入った話題はお気に入りに登録できます。
3. 結果はコピーや X シェアで共有できます。

## 🪟 Windows 版

`windows/` フォルダに、同じ仕様の Windows アプリ（.NET 8 / WinForms）があります。話題データ全109件・カテゴリ絞り込み・直前と同じ話題を避ける抽選・履歴・お気に入り（ローカルファイルに保存）まで Web 版と同じです。

- ビルド: `windows/build.bat`（Windows）または `windows/build.sh` で `windows/dist/Wadaiya.exe` を生成
- ダウンロード: [GitHub Releases（Windows版 v1.0.0）](https://github.com/mabu-works/wadaiya/releases/tag/v1.0.0)
- Web 版の X シェアは Windows 版にはありません

## 📋 技術メモ

- ビルド不要の静的サイト。そのまま Vercel にデプロイできる。
- 外部 API には依存しない。
