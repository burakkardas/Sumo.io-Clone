using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoSingleton<GameManager>
{
    public GameData gameData = null;
    
    public bool IsStart { get; set; }
    public bool IsGameEnd { get; set; }
    
    private int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            UIManager.Instance.SetScoreText(score);
            UpdateHighScore();
        }
    }


    private bool _isPause;
    public bool IsPause => _isPause;


    private void Awake()
    {
        LoadGameData();
    }

    
    
    
    public void UpdateHighScore()
    {
        if(score > gameData.highScore)
        {
            gameData.highScore = score;
            Save();
        }
    }
    
    
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void PauseAndResume()
    {
        if(_isPause)
        {
            Time.timeScale = 1f;
            _isPause = false;
        }
        else
        {
            Time.timeScale = 0f;
            _isPause = true;
        }
        
        
        UIManager.Instance.SetPauseButtonIcon();
    }


    #region Save&Load

    private void LoadGameData()
    {
        if (File.Exists(Application.persistentDataPath + "/GameData.json"))
        {
            Load(); 
        }
    }
    
    

    private void Save()
    {
        var json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(Application.persistentDataPath + "/GameData.json", json);
    }



    private void Load()
    {
        var json = File.ReadAllText(Application.persistentDataPath + "/GameData.json");
        gameData = JsonUtility.FromJson<GameData>(json);
    }

    #endregion
}



[System.Serializable]
public class GameData
{
    public float highScore = 0f;
}