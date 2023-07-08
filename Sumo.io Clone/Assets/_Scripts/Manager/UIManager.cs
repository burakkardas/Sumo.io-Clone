using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [HideInInspector] public RectTransform startPanelTransform = null;
    [HideInInspector] public RectTransform countDownPanelTransform = null;
    [HideInInspector] public RectTransform gamePanelTransform = null;
    [HideInInspector] public RectTransform gameOverPanelTransform = null;
    [HideInInspector] public RectTransform gameWonPanelTransform = null;
    
    [HideInInspector] public TMP_Text countDownText = null;
    [HideInInspector] public TMP_Text highScoreText = null;
    [HideInInspector] public TMP_Text gamePanelscoreText = null;
    [HideInInspector] public TMP_Text gameOverPanelScoreText = null;
    [HideInInspector] public TMP_Text gameWonPanelScoreText = null;

    [HideInInspector] public Button pauseButton = null;
    [HideInInspector] public Sprite pauseSprite = null;
    [HideInInspector] public Sprite resumeSprite = null;

    [SerializeField] private Vector3 currentCountdownTextScale;
    [SerializeField] private Vector3 targetCountdownTextScale;
    [SerializeField] private int countDown;
    [SerializeField] private float scaleDuration;
    [SerializeField] private float panelAnimationDuration = 0.4f;


    private WaitForSeconds _wait = new WaitForSeconds(1);

    
    private void Start()
    {
        SetHighScoreText();
        SetScoreText(GameManager.Instance.Score);
    }
    
    
    
    public void SetScoreText(float score)
    {
        gamePanelscoreText.text = score.ToString();
        gameOverPanelScoreText.text = "<color=#7D7D7D>SCORE</color>" +"\n" +score.ToString();
        gameWonPanelScoreText.text = "<color=#7D7D7D>SCORE</color>" +"\n" +score.ToString();
    }



    public void PlayGame()
    {
        startPanelTransform.DOLocalMoveY(-2000, panelAnimationDuration).OnComplete(()=> MoveCountDownPanel());
    }



    public void SetPauseButtonIcon()
    {
        if (GameManager.Instance.IsPause)
        {
            pauseButton.image.sprite = resumeSprite;
        }
        else
        {
            pauseButton.image.sprite = pauseSprite;
        }
    }



    private void MoveCountDownPanel()
    {
        countDownPanelTransform.DOLocalMoveY(0, panelAnimationDuration).OnComplete(()=> StartCoroutine(nameof(SetCountdown)));
    }
    
    
    
    private void OnCompleteCountDown()
    {
        countDownPanelTransform.DOLocalMoveY(2000, panelAnimationDuration).OnComplete(()=> MoveGamePanel());
    }
    
    
    private void MoveGamePanel()
    {
        gamePanelTransform.DOLocalMoveY(0, panelAnimationDuration).OnComplete(()=> GameManager.Instance.IsStart = true);
    }


    private void SetHighScoreText()
    {
        highScoreText.text = GameManager.Instance.gameData.highScore.ToString();
    }



    public void MoveGameWonPanel()
    {
        gamePanelTransform.gameObject.SetActive(false);
        gameWonPanelTransform.DOLocalMoveY(0, panelAnimationDuration);
    }
    
    
    
    public void MoveGameOverPanel()
    {
        gamePanelTransform.gameObject.SetActive(false);
        gameOverPanelTransform.DOLocalMoveY(0, panelAnimationDuration);
    }
    
    
    
    private void SetSmoothCountDownTextScale()
    {
        countDownText.transform.DOScale(targetCountdownTextScale, scaleDuration).
            OnComplete(()=> countDownText.transform.DOScale(currentCountdownTextScale, scaleDuration));
    }
    



    private IEnumerator SetCountdown()
    {
        while (countDown > 0)
        {
            SetSmoothCountDownTextScale();
            yield return _wait;
            countDown--;
            countDownText.text = countDown.ToString();
            
            
            if(countDown == 0)
                OnCompleteCountDown();
        }
    }
}

