using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class GameOver : MonoBehaviour
{

    //キャンバス用
    private static Canvas gameOverCanvas;

    public ThirdPersonController thirdpersonController;

    private void Awake()
    {
        //Canvasコンポーネント取得
        gameOverCanvas = GetComponent<Canvas>();
    }

    //パネルを開く用の関数 static呼び出し可能
    public static void GameOverShowPanel()
    {
        //ゲーム内の時間を止める
        Time.timeScale = 0f;

        // マウスカーソルを表示
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //GameOverCanvasのCanvasのチェックをデフォルトで外すと関数が呼ばれた時にtrueになる
        gameOverCanvas.enabled = true;
    }

    //ゲームを再スタートする関数
    public void ReStartGame()
    {

        // ゲーム内の時間を戻す
        Time.timeScale = 1f;

        // カーソルを非表示にしてロック状態にする
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //シーン再読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 現在のシーンを再読み込み

    }

    public static void OnGameOver(ThirdPersonController thirdpersonController)
    {
        // ThirdPersonControllerを無効化して操作を完全に停止
        thirdpersonController.enabled = false;

    }
}