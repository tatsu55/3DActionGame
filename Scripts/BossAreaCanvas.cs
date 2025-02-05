using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class BossAreaCanvas : MonoBehaviour
{
    private static Canvas bossAreaCanavs;
    private void Awake()
    {
        //Canvasコンポーネント取得
        bossAreaCanavs = GetComponent<Canvas>();
    }

    //パネルを開く用の関数 static呼び出し可能
    public static void BossAreaShowPanel()
    {
        bossAreaCanavs.enabled = true;
    }
}