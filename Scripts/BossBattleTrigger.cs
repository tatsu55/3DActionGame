using UnityEngine;

public class BossBattleTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �v���C���[���G���A�ɓ�������
        {
            BossAreaCanvas.BossAreaShowPanel();
        }
    }
}
