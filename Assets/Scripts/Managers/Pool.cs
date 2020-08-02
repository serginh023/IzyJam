using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
    public Vector3 initalPosition;
}

public class Pool : MonoBehaviour
{
    public static Pool singleton;
    public List<PoolItem> items;
    public List<GameObject> pooledItems;


    private void Awake()
    {
        singleton = this;
    }

    public GameObject Get(string tag)
    {
        for (int i = 0; i < pooledItems.Count; i++)
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
                return pooledItems[i];

        foreach(PoolItem item in items)
        {
            if(item.prefab.tag == tag && item.expandable)
            {
                GameObject go = Instantiate(item.prefab);
                go.SetActive(false);
                pooledItems.Add(go);
                return go;
            }
        }

        return null;
    }


    public void PopulatePool(Level level)
    {
        pooledItems = new List<GameObject>();

        foreach (PoolItem item in items)
        {
            if (item.prefab.gameObject.tag == "knife")
                item.amount = level.knivesCount;

            for (int i = 0; i < item.amount; i++)
            {
                GameObject go = Instantiate(item.prefab);
                go.SetActive(false);
                pooledItems.Add(go);
            }

        }
    }
}
