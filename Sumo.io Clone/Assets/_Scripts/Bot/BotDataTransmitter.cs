using UnityEngine;

public class BotDataTransmitter : MonoBehaviour
{
    [SerializeField] private BotScaleController botScaleController = null;
    [SerializeField] private AnimationController animationController = null;
    [SerializeField] private AttackController attackController = null;

    
    
    #region Attack

    public GameObject GetLastAttackingObject()
    {
        return attackController.GetLastAttackingObject();
    }

    #endregion
    
    
    #region Animation

    public void SetTrigger(string animationType)
    {
        animationController.SetTrigger(animationType);
    }
    
    
    public void SetBoolean(string animationType, bool value)
    {
        animationController.SetBoolean(animationType, value);
    }

    #endregion
    

    #region Scale

    public void IncreaseScale(int scoreAmount)
    {
        botScaleController.IncreaseScale(scoreAmount);
    }

    #endregion
}
