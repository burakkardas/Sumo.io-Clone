using UnityEngine;
using DG.Tweening;
using DamageNumbersPro;
using TMPro;

public class PlayerScaleController : MonoBehaviour, IScaleable
{
    [SerializeField] private DamageNumber scoreNumberPrefab = null;
    [SerializeField] private TMP_Text gameKillCountText = null;
    [SerializeField] private TMP_Text gameWonKillCountText;
    [SerializeField] private TMP_Text gameOverKillCountText;
    [SerializeField] private int scoreIncrement;
    [SerializeField] private float scaleDuration = 0.3f;
    [SerializeField] private float scoreNumberHeight;
    [SerializeField] private int playerKillCount = 0;
    
    
    private DamageNumber _scoreNumberInstance = null;
    private Vector3 _currentScale;


    private void Start()
    {
        _currentScale = transform.localScale;
        UpdateKillCountTexts();
    }


    public void IncreaseScale(int scoreAmount)
    {
        _currentScale += Vector3.one * 0.05f;
        transform.DOScale(_currentScale, scaleDuration);
        SpawnScoreNumber();
        GameManager.Instance.Score += scoreAmount;
    }



    private void SpawnScoreNumber()
    {
        _scoreNumberInstance = scoreNumberPrefab.Spawn(GetScoreTextSpawnPosition());
        _scoreNumberInstance.number = scoreIncrement;
    }
    
    
    
    private Vector3 GetScoreTextSpawnPosition()
    {
        return new Vector3(transform.position.x, scoreNumberHeight, transform.position.z);
    }
    
    
    
    public void IncreaseKillCount()
    {
        playerKillCount++;

        UpdateKillCountTexts();
    }


    private void UpdateKillCountTexts()
    {
        gameKillCountText.text = playerKillCount.ToString();
        gameWonKillCountText.text = playerKillCount.ToString();
        gameOverKillCountText.text = playerKillCount.ToString();
    }
}
