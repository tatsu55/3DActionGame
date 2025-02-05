using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class GameClear : MonoBehaviour
{

    //�L�����o�X�p
    private static Canvas gameClearCanvas;

    public ThirdPersonController thirdpersonController;

    private void Awake()
    {
        //Canvas�R���|�[�l���g�擾
        gameClearCanvas = GetComponent<Canvas>();
    }

    //�p�l�����J���p�̊֐� static�Ăяo���\
    public static void GameClearShowPanel()
    {
        //�Q�[�����̎��Ԃ��~�߂�
        Time.timeScale = 0f;

        // �}�E�X�J�[�\����\��
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        gameClearCanvas.enabled = true;
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

    public static void OnGameClear(ThirdPersonController thirdpersonController)
    {
        // ThirdPersonController�𖳌������đ�������S�ɒ�~
        thirdpersonController.enabled = false;
    }
}