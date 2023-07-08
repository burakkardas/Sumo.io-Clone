using System.Collections;
using UnityEngine;
using TMPro;


public class TimerController : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText = null;
    [SerializeField] private int minute;
    [SerializeField] private int second;

    
    private WaitForSeconds wait = new WaitForSeconds(1f);

    private void Start()
    {
        StartCoroutine(nameof(SetTime));
    }



    private IEnumerator SetTime()
    {
        while (minute > 0 || second > 0)
        {
            SetSecond();
            yield return wait; 
        }
    }



    private void SetSecond()
    {
        second--;
        
        if(second < 0)
        {
            minute--;
            second = 59;
        }
        
        
        if(second == 0 && minute == 0)
        {
            GameManager.Instance.IsGameEnd = true;
            UIManager.Instance.MoveGameOverPanel();
        }
        
        SetTimerText();
    }



    private void SetTimerText()
    {
        timerText.text = minute.ToString("00") + ":" + second.ToString("00");
    }
}
