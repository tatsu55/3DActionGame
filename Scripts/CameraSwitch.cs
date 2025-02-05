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
        // 変数がnullでないか確認
        if (normalCamera == null) Debug.LogError("normalCamera is not assigned!");
        if (lockOnCamera == null) Debug.LogError("lockOnCamera is not assigned!");
        if (virtualCamera == null) Debug.LogError("virtualCamera is not assigned!");
        if (thirdpersonController == null) Debug.LogError("thirdpersonController is not assigned!");

}

    void Update()
    {
        // ロックオン状態のチェック
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
        // LookAtターゲットに設定
        if (thirdpersonController.lockOnTarget != null)
        {
            virtualCamera.LookAt = thirdpersonController.lockOnTarget;

            // ロックオンターゲットが倒れた場合、isLockOnをfalseにする
            if (!thirdpersonController.lockOnTarget.gameObject.activeInHierarchy)
            {
                thirdpersonController.isLockOn = false;
                virtualCamera.LookAt = null; // LookAtターゲットを解除
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
