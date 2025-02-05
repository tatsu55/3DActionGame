# 3DActionGame

## プロジェクト概要

このプロジェクトは、Unity を使用して開発したアクションゲームです。
プレイヤーは 3D のフィールドを移動し、襲い来る敵をたおします。

## 動作環境

- Unity 2022.3.36f1
- Windows 10 / MacOS 13

## 操作方法

- **移動**: WASD
- **弱攻撃**: 左クリック
- **強攻撃**: 右クリック
- **ジャンプ**: space キー
- **回避**:F キー
- **ロックオン/解除**: R キー

# 実装した機能

## ◯ NavMesh を用いた AI 制御

- **NavMesh** を活用し、敵キャラクターがプレイヤーを追跡する AI を実装
- **待機・追跡・攻撃** を導入

## ◯ ダメージ判定と HP バー

- **OnTriggerEnter** を使用し、プレイヤーと敵の攻撃ヒット判定を実装
- **防御力（DEF）によるダメージ計算** を導入し、敵ごとに異なるダメージ処理を設定
- Slider を用いて HP バーを実装
- HP バーを **現在 HP ÷ 最大 HP** の比率で更新
- HP が 0 になったとき、**死亡アニメーション＋ゲームオーバーパネルの表示** を実装
- ゲームオーバー時の Restart ボタンによってゲームをはじめから再開可能

## ◯ 連続攻撃

- 左クリックを連続で押すことで最大 3 回の連続攻撃が可能
- 一段目・二段目の攻撃後に待機モーションへ移行可能
- 攻撃のキャンセルタイミングを設け、スムーズな操作感を実現

### ◯ ロックオン機能（新規追加）

- **R キーでロックオン/解除が可能**
- ロックオン時、カメラが敵を中心に追従
- もう一度 R キーを押すとロックオン解除


### **セットアップ手順（Google Drive からダウンロードしてプレイ）**  

1. **Google Drive のダウンロードリンクにアクセス**  
   - [ダウンロードリンク](https://drive.google.com/drive/folders/1W7YpcVnqSBy6JgrriWgaMmYq1J0U8MZG?usp=sharing)

2. **「ダウンロード」ボタンをクリックし、ファイルを保存**  
   - `Build.zip` をダウンロード  

3. **ダウンロードしたファイルを解凍**  
   - `Build.zip` を右クリック → **「すべて展開」**（Windows）  
   - `Build.app.zip` をダブルクリック → **「展開」**（Mac）  

4. **ゲームを起動**  
   - **Windows:** 'Game.exe' をダブルクリック  
   - **Mac:**　'Game.app' をContents/MacOS/Game の場所にある実行ファイルを使用してゲームを開始します。
