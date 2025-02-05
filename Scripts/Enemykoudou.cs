using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

//IEnemy�̃C���^�[�t�F�[�X��錾���Ă���̂ŁApublic int EnemyAIkoudou()�̃��\�b�h�����K�v����B
public class Enemykoudou : MonoBehaviour, IEnemy
{
    //�V���A�������Ă���Bcharadata�̓G���w��B
    [SerializeField] charadata charadata;
    [SerializeField] GameObject Player;
    Vector3 distance; //Player�Ƃ̋���
    int State;

    public int EnemyAIkoudou()
    {
        //�L���������v�Z�̏���
        distance = transform.position - Player.transform.position;
        float distanceX = Mathf.Abs(distance.x);
        float distanceZ = Mathf.Abs(distance.z);

        if (distanceX > distanceZ)
        {
            if (charadata.ShortAttackRange >= distanceX)
            {
                State = 1;
                return State;
            }
        }
        else
        {
            if (charadata.ShortAttackRange >= distanceZ)
            {
                State = 1;
                return State;
            }
        }
        //�����𖞂����Ȃ��ꍇ��State��0�Ƃ��ĕԂ��B�������Ȃ��B
        State = 0;
        return State;
    }
}