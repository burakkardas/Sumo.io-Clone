using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator = null;



    public void SetTrigger(string animationType)
    {
        animator.SetTrigger(animationType);
    }



    public void SetBoolean(string animationType, bool value)
    {
        animator.SetBool(animationType, value);
    }
}
