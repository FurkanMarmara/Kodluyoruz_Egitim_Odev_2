using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    #region Singleton 
    public static ObjectPooler instance;
    public ObjectPooler()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    [SerializeField]
    private List<PoolItemData> _poolableList = new List<PoolItemData>();
    Dictionary<PoolObjectType, Queue<GameObject>> _objectPool = new Dictionary<PoolObjectType, Queue<GameObject>>();


    private void Start()
    {
        SpawnPoolableObjects();
    }

    private void SpawnPoolableObjects()
    {
        for (int i = 0; i < _poolableList.Count; i++)
        {
            Queue<GameObject> poolObjects = new Queue<GameObject>();
            for (int j = 0; j < _poolableList[i].count; j++)
            {
                GameObject gO = Instantiate(_poolableList[i].gO,new Vector3(0,0,0),Quaternion.identity);
                gO.SetActive(false);
                poolObjects.Enqueue(gO);
            }
            _objectPool.Add(_poolableList[i].objectType,poolObjects);
        }
    }


    public void SpawnFromPool(PoolObjectType objectType,Vector3 spawnPos,Quaternion rotation)
    {
        GameObject gO = _objectPool[objectType].Dequeue();
        gO.transform.position = spawnPos;
        gO.transform.rotation = rotation;
        gO.SetActive(true);

        
    }

    public void DestroyPool(PoolObjectType objectType,GameObject gO)
    {
        gO.SetActive(false);
        _objectPool[objectType].Enqueue(gO);
        gO.transform.position = Vector3.zero;
        gO.transform.rotation = Quaternion.identity;
    }


}

[System.Serializable]
public class PoolItemData
{
    public PoolObjectType objectType;
    public GameObject gO;
    public int count;
}

public enum PoolObjectType
{
    Meteor
}
