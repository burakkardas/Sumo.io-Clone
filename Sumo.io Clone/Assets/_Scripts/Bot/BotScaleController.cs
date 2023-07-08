using System;
using UnityEngine;
using DG.Tweening;

public class BotScaleController : MonoBehaviour, IScaleable
{
    [SerializeField] private float scaleDuration = 0.3f;
    [SerializeField] private int scoreInrement;
    
    
    private Vector3 _currentScale;


    private void Start()
    {
        _currentScale = transform.localScale;
    }
    
    
    public void IncreaseScale(int scoreAmount)
    {
        _currentScale += Vector3.one * 0.05f;
        transform.DOScale(_currentScale, scaleDuration);
    }
}
