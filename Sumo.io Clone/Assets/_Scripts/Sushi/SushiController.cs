using UnityEngine;
using DG.Tweening;

public class SushiController : MonoBehaviour
{
    [SerializeField] private Vector3 rotateDirection;
    [SerializeField] private Ease rotateEase;
    [SerializeField] private Ease fallEase;
    [SerializeField] private float fallHeight;
    [SerializeField] private float fallDuration;
    [SerializeField] private float rotateDuration = 5f;


    private void Start()
    {
        FallMoveSushi();
    }
    


    private void FallMoveSushi()
    {
        transform.DOMoveY(fallHeight, fallDuration).SetEase(fallEase).OnComplete(() => RotateSushi());
    }


    
    private void RotateSushi()
    {
        transform.DORotate(rotateDirection, rotateDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart)
            .SetRelative().SetEase(rotateEase);
    }



    public void ReSpawnSushi()
    {
        transform.position = Random.insideUnitSphere * 15f;
        transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
        FallMoveSushi();
    }
}
