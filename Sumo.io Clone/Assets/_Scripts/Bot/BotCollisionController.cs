using UnityEngine;
using NOSurrender;

public class BotCollisionController : MonoBehaviour
{
    [SerializeField] private BotDataTransmitter botDataTransmitter = null;
    [SerializeField] private PlayerManager playerManager = null;
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.SUSHI))
        {
            botDataTransmitter.IncreaseScale(100);
            other.gameObject.GetComponent<SushiController>().ReSpawnSushi();
        }


        if (other.gameObject.CompareTag(Tag.WATER))
        {
            if (botDataTransmitter.GetLastAttackingObject().gameObject.CompareTag(Tag.PLAYER))
            {
                botDataTransmitter.GetLastAttackingObject().GetComponent<PlayerDataTransmitter>().IncreaseKillCount();
            }
            IScaleable scaleable = botDataTransmitter.GetLastAttackingObject().GetComponent<IScaleable>();
            scaleable.IncreaseScale(1000);
            playerManager.RemovePlayer(gameObject);
            gameObject.SetActive(false);
        }
    }
}
