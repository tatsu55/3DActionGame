using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
public class PlayerWaterTrigger : MonoBehaviour
{
    public Slider slider;
    public ThirdPersonController thirdpersonController;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // プレイヤーがエリアに入ったら
        {
            slider.value = 0;

            GameOver.GameOverShowPanel();
            GameOver.OnGameOver(thirdpersonController);
        }
    }
}
