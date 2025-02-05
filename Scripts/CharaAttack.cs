using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class CharaAttack : MonoBehaviour
{
    //�V���A�������Ă���Bcharadata���w��B
    [SerializeField] private charadata charadata;
    //���������Ă���Q�[���I�u�W�F�N�g(�e)���w��B
    [SerializeField] GameObject AttackChara;
    public Collider WeaponCollider;

    int HHcount;
    int ATK;
    ICharaAttack Hcount;


    void Start()
    {
        //charadata�̍ő�HP�����B
        ATK = charadata.ATK;
        //ICharaAttack�̃C���^�[�t�F�[�X����`���ꂽ�R���|�[�l���g(�X�N���v�g)��Hcoun�ɑ���B
        Hcount = AttackChara.GetComponent<ICharaAttack>();
    }



    //�����Q�[���I�u�W�F�N�g�ɐN�������u�ԂɌĂяo��
    void OnTriggerEnter(Collider other)
    {
        //ICharaAttack�̃C���^�[�t�F�[�X����`���ꂽ�X�N���v�g��HitCount()���Ăяo���A�Ԃ�l(�c��q�b�g��)��HHcount�ɑ������B
        HHcount = Hcount.HitCount();
        //HHcount��0�ȉ��Ȃ�������Ƀq�b�g���Ă���Breturn;�ŏ������I��点��B
        if (HHcount <= 0)
        {
            return;
        }
        if (other.tag == "Player")
        {
            //�R���C�_�[�̂���Q�[���I�u�W�F�N�g�̃C���^�[�t�F�[�X���Ăяo��
            IDamageable damageable = other.GetComponent<IDamageable>();
            //damageable��null�l�������Ă��Ȃ����`�F�b�N
            if (damageable != null)
            {
                //�_���[�W������̂��m�肵���̂Ńq�b�g��-1
                Hcount.HitCountdown();
                //damageable�̃_���[�W�������\�b�h���Ăяo���B�����Ƃ���charadata��ATK���w��
                damageable.Damage(ATK);
            }

        }

    }
  

}