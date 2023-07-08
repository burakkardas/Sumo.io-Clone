using UnityEngine;


public class SushiSpawnController : MonoBehaviour
{
    [SerializeField] private int maxSushiCount;
    [SerializeField] private float spawnRadius;

    private GameObject _sushiInstance = null;

    void Start()
    {
        GenerateSushi();
    }



    private void GenerateSushi()
    {
        for (int i = 0; i < maxSushiCount; i++)
        {
            _sushiInstance = ObjectPooler.Instance.SpawnObject(PoolType.Sushi, transform.position, Quaternion.identity);
            _sushiInstance.transform.position = Random.insideUnitSphere * spawnRadius;
        }
    }
}
