using UnityEngine;

public class TitleController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform = null;


    private void LateUpdate()
    {
        SetTitleRotation();
    }



    private void SetTitleRotation()
    {
        transform.rotation = Quaternion.LookRotation((transform.position - cameraTransform.position).normalized);
    }
}
