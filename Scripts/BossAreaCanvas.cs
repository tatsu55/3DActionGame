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
        //Canvas�R���|�[�l���g�擾
        bossAreaCanavs = GetComponent<Canvas>();
    }

    //�p�l�����J���p�̊֐� static�Ăяo���\
    public static void BossAreaShowPanel()
    {
        bossAreaCanavs.enabled = true;
    }
}