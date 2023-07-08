using UnityEngine;

public class BotController : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private bool isAlive = true;

    public int Score => score;
    public bool IsAlive => isAlive;
}
