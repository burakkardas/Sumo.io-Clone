using UnityEngine;
using NOSurrender;



public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField] private PlayerDataTransmitter playerDataTransmitter = null;
    [SerializeField] private PlayerManager playerManager = null;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.SUSHI))
        {
            playerDataTransmitter.IncreaseScale(100);
            other.gameObject.GetComponent<SushiController>().ReSpawnSushi();
        }



        if (other.gameObject.CompareTag(Tag.WATER))
        {
            playerManager.RemovePlayer(gameObject);
        }
    }
}
