# 話題ガチャ

雑談の話題をランダムで引けるガチャ Web アプリ。

| 項目 | 内容 |
|---|---|
| バージョン | –（日付管理） |
| 状態 | 公開中 |
| 公開先 | [wadaiya.vercel.app](https://wadaiya.vercel.app) |
| 実装 | HTML / CSS / JavaScript（静的サイト） |
| 更新履歴 | [CHANGELOG.md](CHANGELOG.md) |

## 📖 概要

Discord Bot「Chat Topic Bot」内蔵の話題109件（7カテゴリ）をそのまま収録。

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

## 📁 ファイル構成

| パス | 役割 |
|---|---|
| `index.html` | ページ本体 |
| `app.js` | ガチャの動作ロジック |
| `style.css` | スタイル |
| `sw.js` | Service Worker |
| `manifest.webmanifest` | PWA マニフェスト |
| `icons/` | アイコン |
| `windows/` | Windows 版（.NET 8 / WinForms） |
| `vercel.json` | Vercel の設定 |
