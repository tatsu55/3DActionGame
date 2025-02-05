using Cinemachine;
using UnityEngine;
using StarterAssets;
public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera normalCamera;
    public CinemachineVirtualCamera lockOnCamera;
    private CinemachineBrain brain;
    public ThirdPersonController thirdpersonController;
    public CinemachineVirtualCamera virtualCamera;


    void Start()
    {
        brain = Camera.main.GetComponent<CinemachineBrain>();
        // �ϐ���null�łȂ����m�F
        if (normalCamera == null) Debug.LogError("normalCamera is not assigned!");
        if (lockOnCamera == null) Debug.LogError("lockOnCamera is not assigned!");
        if (virtualCamera == null) Debug.LogError("virtualCamera is not assigned!");
        if (thirdpersonController == null) Debug.LogError("thirdpersonController is not assigned!");

}

    void Update()
    {
        // ���b�N�I����Ԃ̃`�F�b�N
        if (thirdpersonController.isLockOn)
        {
            SwitchToLockOnView();
        }
        else
        {
            SwitchToNormalView();
        }
    }

    void SwitchToLockOnView()
    {
        normalCamera.gameObject.SetActive(false);
        lockOnCamera.gameObject.SetActive(true);
        // LookAt�^�[�Q�b�g�ɐݒ�
        if (thirdpersonController.lockOnTarget != null)
        {
            virtualCamera.LookAt = thirdpersonController.lockOnTarget;

            // ���b�N�I���^�[�Q�b�g���|�ꂽ�ꍇ�AisLockOn��false�ɂ���
            if (!thirdpersonController.lockOnTarget.gameObject.activeInHierarchy)
            {
                thirdpersonController.isLockOn = false;
                virtualCamera.LookAt = null; // LookAt�^�[�Q�b�g������
            }
        }
    }

    void SwitchToNormalView()
    {
        lockOnCamera.gameObject.SetActive(false);
        normalCamera.gameObject.SetActive(true);
        virtualCamera.LookAt = null;
    }
}
