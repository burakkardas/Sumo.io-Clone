using System.Collections.Generic;
using UnityEngine;
using NOSurrender;

public class PlayerManager : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();

    [SerializeField] private GameObject playerObject = null;
    [SerializeField] private CameraController cameraController = null;

    public void RemovePlayer(GameObject playerObject)
    {
        players.Remove(playerObject);
        CheckPlayerWon();
        SetCameraTarget();
    }


    private void CheckPlayerWon()
    {
        if (players.Count == 1 && players[0].gameObject.CompareTag(Tag.PLAYER))
        {
            cameraController.SetSmoothCameraTransition();
            players[0].gameObject.GetComponent<PlayerDataTransmitter>().SetBoolean(AnimationType.DANCE, true);
            GameManager.Instance.IsGameEnd = true;
            UIManager.Instance.MoveGameWonPanel();
        }
        else if(players.Count == 1 && !players.Contains(playerObject))
        {
            GameManager.Instance.IsGameEnd = true;
            UIManager.Instance.MoveGameOverPanel();
        }
    }
    
    
    
    
    public void SetCameraTarget()
    {
        if (!players.Contains(playerObject))
        {
            cameraController.SetTarget(players[Util.GetRandomIndex(players.Count)].transform);
        }
    }
}
