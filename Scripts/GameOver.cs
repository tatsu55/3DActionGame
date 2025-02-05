using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class GameOver : MonoBehaviour
{

    //�L�����o�X�p
    private static Canvas gameOverCanvas;

    public ThirdPersonController thirdpersonController;

    private void Awake()
    {
        //Canvas�R���|�[�l���g�擾
        gameOverCanvas = GetComponent<Canvas>();
    }

    //�p�l�����J���p�̊֐� static�Ăяo���\
    public static void GameOverShowPanel()
    {
        //�Q�[�����̎��Ԃ��~�߂�
        Time.timeScale = 0f;

        // �}�E�X�J�[�\����\��
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //GameOverCanvas��Canvas�̃`�F�b�N���f�t�H���g�ŊO���Ɗ֐����Ă΂ꂽ����true�ɂȂ�
        gameOverCanvas.enabled = true;
    }

    //�Q�[�����ăX�^�[�g����֐�
    public void ReStartGame()
    {

        // �Q�[�����̎��Ԃ�߂�
        Time.timeScale = 1f;

        // �J�[�\�����\���ɂ��ă��b�N��Ԃɂ���
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //�V�[���ēǂݍ���
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���݂̃V�[�����ēǂݍ���

    }

    public static void OnGameOver(ThirdPersonController thirdpersonController)
    {
        // ThirdPersonController�𖳌������đ�������S�ɒ�~
        thirdpersonController.enabled = false;

    }
}