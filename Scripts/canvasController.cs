using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasController : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    void Update()
    {
        //EnemyGaugeをMain Cameraへ向かせる
        canvas.transform.rotation =   
            Camera.main.transform.rotation;
    }
}
