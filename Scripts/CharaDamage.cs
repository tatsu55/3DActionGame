using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CharaDamage : MonoBehaviour, IDamageable
{
    //�V���A�������Ă���Bcharadata��Mazokusoldier���w��B
    [SerializeField] private charadata charadata;
    //�V���A�����BSlider��HP�Q�[�W�w��
    [SerializeField] Slider Slider;

    [SerializeField] public ThirdPersonController thirdpersonController;

    private Animator anim; // Animator�ϐ���ǉ�
    private bool canMove  = true;

    int HP;
    int MAXHP;
    int ATK;
    int DEF;
    int INT;
    int RES;

    void Start()
    {
        anim = GetComponent<Animator>(); // Animator���擾

        //charadata��null�łȂ����Ƃ��m�F
        if (charadata != null)
        {
            //value��HP�Q�[�W�̃X���C�_�[���ő��1��
            Slider.value = 1;

            //charadata�̍ő�HP�����B
            HP = charadata.MAXHP;
            MAXHP = charadata.MAXHP;
            ATK = charadata.ATK;
            DEF = charadata.DEF;
            INT = charadata.INT;
            RES = charadata.RES;
        }
    }

    // �_���[�W�����̃��\�b�h�@value�ɂ�Player1��ATK�̒l�������Ă�
    public void Damage(int value)
    {

        // charadata��null�łȂ������`�F�b�N
        if (charadata != null && thirdpersonController.isHide == false)
        {
            HP -= value - charadata.DEF;

            // HP�Q�[�W�ɔ��f
            Slider.value = (float)HP / (float)charadata.MAXHP;
            anim.SetTrigger("HitReact");
        }


        // HP��0�ȉ��Ȃ�Death()���\�b�h���Ăяo���B
        if (HP <= 0)
        {
            StartCoroutine(DeathAndGameOver());
        }
    }
    private IEnumerator DeathAndGameOver()
    {
        // ���S�A�j���[�V�������Đ�
        Death();

        if (gameObject.CompareTag("Player"))
        {
            // ���S�A�j���[�V�������I������܂ő҂�
            yield return new WaitForSeconds(1.5f);

            // GameOver��ʂ�\��
            GameOver.GameOverShowPanel();
            GameOver.OnGameOver(thirdpersonController);
        }
        if (gameObject.CompareTag("BossEnemy"))
        {
            // ���S�A�j���[�V�������I������܂ő҂�
            yield return new WaitForSeconds(1.5f);

            // GameClear��ʂ�\��
            GameClear.GameClearShowPanel();
            GameClear.OnGameClear(thirdpersonController);
        }

    }
    // ���S�����̃��\�b�h
    public void Death()
    {
        //���S�A�j���[�V�����J�n�B
        anim.SetInteger("Death", 1);
        canMove = false;

    }
    public void DeathEnd()
    {
        //�Q�[���I�u�W�F�N�g���A�N�e�B�u��
        this.gameObject.SetActive(false);
    }
}