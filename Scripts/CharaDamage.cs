using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CharaDamage : MonoBehaviour, IDamageable
{
    //シリアル化している。charadataのMazokusoldierを指定。
    [SerializeField] private charadata charadata;
    //シリアル化。SliderのHPゲージ指定
    [SerializeField] Slider Slider;

    [SerializeField] public ThirdPersonController thirdpersonController;

    private Animator anim; // Animator変数を追加
    private bool canMove  = true;

    int HP;
    int MAXHP;
    int ATK;
    int DEF;
    int INT;
    int RES;

    void Start()
    {
        anim = GetComponent<Animator>(); // Animatorを取得

        //charadataがnullでないことを確認
        if (charadata != null)
        {
            //valueのHPゲージのスライダーを最大の1に
            Slider.value = 1;

            //charadataの最大HPを代入。
            HP = charadata.MAXHP;
            MAXHP = charadata.MAXHP;
            ATK = charadata.ATK;
            DEF = charadata.DEF;
            INT = charadata.INT;
            RES = charadata.RES;
        }
    }

    // ダメージ処理のメソッド　valueにはPlayer1のATKの値が入ってる
    public void Damage(int value)
    {

        // charadataがnullでないかをチェック
        if (charadata != null && thirdpersonController.isHide == false)
        {
            HP -= value - charadata.DEF;

            // HPゲージに反映
            Slider.value = (float)HP / (float)charadata.MAXHP;
            anim.SetTrigger("HitReact");
        }


        // HPが0以下ならDeath()メソッドを呼び出す。
        if (HP <= 0)
        {
            StartCoroutine(DeathAndGameOver());
        }
    }
    private IEnumerator DeathAndGameOver()
    {
        // 死亡アニメーションを再生
        Death();

        if (gameObject.CompareTag("Player"))
        {
            // 死亡アニメーションが終了するまで待つ
            yield return new WaitForSeconds(1.5f);

            // GameOver画面を表示
            GameOver.GameOverShowPanel();
            GameOver.OnGameOver(thirdpersonController);
        }
        if (gameObject.CompareTag("BossEnemy"))
        {
            // 死亡アニメーションが終了するまで待つ
            yield return new WaitForSeconds(1.5f);

            // GameClear画面を表示
            GameClear.GameClearShowPanel();
            GameClear.OnGameClear(thirdpersonController);
        }

    }
    // 死亡処理のメソッド
    public void Death()
    {
        //死亡アニメーション開始。
        anim.SetInteger("Death", 1);
        canMove = false;

    }
    public void DeathEnd()
    {
        //ゲームオブジェクトを非アクティブに
        this.gameObject.SetActive(false);
    }
}