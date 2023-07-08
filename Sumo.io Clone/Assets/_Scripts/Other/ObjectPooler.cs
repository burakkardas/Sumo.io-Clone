using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private static ObjectPooler _instance = null;
    public static ObjectPooler Instance => _instance;


    [SerializeField] private List<PooleableObject> pooleableObjects = null;

    private GameObject _object;


    private void Awake()
    {
        _instance = this;
        if (pooleableObjects == null)
            pooleableObjects = new List<PooleableObject>();

        GenerateAllPool();
    }


    private void Start()
    {
        
    }


    public void GenerateAllPool()
    {
        for (int i = 0; i < pooleableObjects.Count; i++)
        {
            pooleableObjects[i].GeneretePool(transform.position);
        }
    }


    public GameObject SpawnObject(PoolType poolType, Vector3 position, Quaternion quaternion)
    {
        foreach (var poolObject in pooleableObjects)
        {
            if (poolObject.poolType == poolType)
                _object = poolObject.GetObjectFromPool(position, quaternion);
        }

        return _object;
    }


    public void DeSpawnObject(PoolType poolType, GameObject gameObject)
    {
        foreach (var poolObject in pooleableObjects)
        {
            if (poolObject.poolType == poolType)
                poolObject.ReturnObjectToPool(gameObject);
        }
    }
}


[System.Serializable]
public class PooleableObject
{
    public Queue<GameObject> poolList = new Queue<GameObject>();
    public PoolType poolType;
    public GameObject objectPrefab;
    public int poolSize;


    public void GeneretePool(Vector3 position)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject _newObject = GameObject.Instantiate(objectPrefab, position, Quaternion.identity);
            _newObject.SetActive(false);
            poolList.Enqueue(_newObject);
        }
    }


    public GameObject GetObjectFromPool(Vector3 position, Quaternion quaternion)
    {
        if (poolList.Count > 1)
        {
            GameObject _obj = poolList.Dequeue();
            _obj.transform.position = position;
            _obj.transform.rotation = quaternion;
            _obj.SetActive(true);
            return _obj;
        }
        else
        {
            GameObject _newObject = GameObject.Instantiate(objectPrefab, Vector3.zero, Quaternion.identity);
            poolList.Enqueue(_newObject);
            _newObject.SetActive(true);
            return _newObject;
        }
    }


    public void ReturnObjectToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        poolList.Enqueue(gameObject);
    }
}


/// <summary>
///  Write the name of the object you added to the pool 
/// </summary>
public enum PoolType
{
    Sushi,
}