using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //�V���A�������Ă���Bcharadata��Player1���w��B
    [SerializeField] private charadata charadata;

    //�����Q�[���I�u�W�F�N�g�ɐN�������u�ԂɌĂяo��
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy") && !other.CompareTag("BossEnemy"))
        {
            return;
        }

        //other�̃Q�[���I�u�W�F�N�g�̃C���^�[�t�F�[�X���Ăяo��
        IDamageable damageable = other.GetComponent<IDamageable>();

        //damageable�̃_���[�W�������\�b�h���Ăяo���B�����Ƃ���Player��ATK���w��
        damageable.Damage(charadata.ATK);
    }

}