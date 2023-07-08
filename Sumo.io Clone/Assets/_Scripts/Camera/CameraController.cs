using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineMixingCamera cinemachineMixingCamera = null;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera = null;
    [SerializeField] private Transform cameraTransform = null;
    [SerializeField] private float transitionDuration = 0.5f;


    private float _currentLerp01 = 0.5f;
    private float _currentLerp02 = 0f;



    public void SetSmoothCameraTransition()
    {
        DOTween.To(() => _currentLerp01, x => _currentLerp01 = x, 0f, transitionDuration).OnUpdate(() =>
        {
            cinemachineMixingCamera.m_Weight0 = _currentLerp01;
        });


        DOTween.To(() => _currentLerp02, x => _currentLerp02 = x, 0.5f, transitionDuration).OnUpdate(() =>
        {
            cinemachineMixingCamera.m_Weight1 = _currentLerp02;
        });
    }



    public void SetTarget(Transform target)
    {
        cinemachineVirtualCamera.Follow = target;
        cinemachineVirtualCamera.LookAt = target;
    }
}
