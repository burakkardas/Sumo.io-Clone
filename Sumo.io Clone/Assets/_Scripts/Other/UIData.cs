using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIData : MonoBehaviour
{
    [SerializeField] private RectTransform startPanelTransform = null;
    [SerializeField] private RectTransform countDownPanelTransform = null;
    [SerializeField] private RectTransform gamePanelTransform = null;
    [SerializeField] private RectTransform gameOverPanelTransform = null;
    [SerializeField] private RectTransform gameWonPanelTransform = null;
    
    [SerializeField] private Button pauseButton = null;
    [SerializeField] private Sprite resumeSprite = null;
    [SerializeField] private Sprite pauseSprite = null;

    [SerializeField] private TMP_Text countDownText = null;
    [SerializeField] private TMP_Text highScoreText = null;
    [SerializeField] private TMP_Text scoreText = null;
    [SerializeField] private TMP_Text gameOverPanelScoreText = null;
    [SerializeField] private TMP_Text gameWonPanelScoreText = null;


    private void Awake()
    {
        UIManager.Instance.startPanelTransform = startPanelTransform;
        UIManager.Instance.countDownPanelTransform = countDownPanelTransform;
        UIManager.Instance.gamePanelTransform = gamePanelTransform;
        UIManager.Instance.gameOverPanelTransform = gameOverPanelTransform;
        UIManager.Instance.gameWonPanelTransform = gameWonPanelTransform;
        UIManager.Instance.pauseButton = pauseButton;
        UIManager.Instance.resumeSprite = resumeSprite;
        UIManager.Instance.pauseSprite = pauseSprite;
        UIManager.Instance.countDownText = countDownText;
        UIManager.Instance.highScoreText = highScoreText;
        UIManager.Instance.gamePanelscoreText = scoreText;
        UIManager.Instance.gameOverPanelScoreText = gameOverPanelScoreText;
        UIManager.Instance.gameWonPanelScoreText = gameWonPanelScoreText;
    }



    public void PlayGame()
    {
        UIManager.Instance.PlayGame();
    }



    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
        GameManager.Instance.IsStart = false;
        GameManager.Instance.IsGameEnd = false;
    }
    
    
    
    public void PauseAndResume()
    {
        GameManager.Instance.PauseAndResume();
    }
}
