using UnityEngine;

public class PlayerDataTransmitter : MonoBehaviour
{
    [SerializeField] private PlayerScaleController playerScaleController = null;
    [SerializeField] private AnimationController animationController = null;


    #region Scale

    public void IncreaseScale(int scoreAmount)
    {
        playerScaleController.IncreaseScale(scoreAmount);
    }
    
    
    
    public void IncreaseKillCount()
    {
        playerScaleController.IncreaseKillCount();
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
}
