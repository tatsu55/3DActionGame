using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //シリアル化している。charadataのPlayer1を指定。
    [SerializeField] private charadata charadata;

    //剣がゲームオブジェクトに侵入した瞬間に呼び出し
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy") && !other.CompareTag("BossEnemy"))
        {
            return;
        }

        //otherのゲームオブジェクトのインターフェースを呼び出す
        IDamageable damageable = other.GetComponent<IDamageable>();

        //damageableのダメージ処理メソッドを呼び出す。引数としてPlayerのATKを指定
        damageable.Damage(charadata.ATK);
    }

}