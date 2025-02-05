using UnityEngine;

public class BossBattleTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // プレイヤーがエリアに入ったら
        {
            BossAreaCanvas.BossAreaShowPanel();
        }
    }
}
