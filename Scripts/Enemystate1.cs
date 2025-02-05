using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemystate1 : MonoBehaviour
{
    Animator anim;
    [SerializeField] charadata charadata;
    [SerializeField] MonoBehaviour Enemykinsetu;

    int State;
    bool koudou;
    IEnemy Enemykoudou;

    void Start()
    {
        anim = GetComponent<Animator>();
        //IEnemy�̃C���^�[�t�F�[�X��錾�����R���|�[�l���g(�X�N���v�g)����ɓ���AEnemykoudou�֑���B
        Enemykoudou = GetComponent<IEnemy>();
    }


    void Update()
    {
        StartCoroutine(Enemytime());

        //Attack�p�����[�^�̒l������0���傫���Ȃ�U�����Ȃ̂�return;���ď������I������B
        int Attack = anim.GetInteger("Attack");
        if (Attack > 0)
        {
            return;
        }

        //�l�������Ă��Ȃ��ꍇ�ɔ���null�`�F�b�N�B
        if (Enemykoudou != null)
        {
            //�X�N���v�g��EnemyAIkoudou()���Ăяo���A�Ԃ��Ă����l��State�ɑ������B
            State = Enemykoudou.EnemyAIkoudou();


            koudou = true;
            //Switch����State�̒l�ɉ����ď�������B
            switch (State)
            {
                //State��0�Ȃ��~�B
                case 0:

                    anim.SetInteger("Attack", 0);
                    break;

                //State��1�Ȃ�U���B
                case 1:

                    anim.SetInteger("Attack", 1);
                    break;
            }
        }

    }

    IEnumerator Enemytime()
    {
        yield return new WaitForSeconds(charadata.Enemytime);
        koudou = false;
    }
}