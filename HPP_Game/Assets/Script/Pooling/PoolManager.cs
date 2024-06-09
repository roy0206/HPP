using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
[SerializeField]
public struct PoolInfo
{
    public GameObject obj;
    public int amount;
}


public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    public List<PoolInfo> poolObjects = new List<PoolInfo>();

    Dictionary<string, (GameObject, GameObject)> poolStorage = new Dictionary<string, (GameObject, GameObject)>();

    private void Awake()
    {
        Instance = this;

        foreach (var poolInfo in poolObjects)
        {
            GameObject poolParent = new GameObject(poolInfo.obj.gameObject.name + "Pool");
            poolStorage.Add(poolInfo.obj.gameObject.name, (poolParent, poolInfo.obj));
            poolParent.transform.parent = this.transform;
            for (int j = 0; j < poolInfo.amount; j++)
            {
                MakeNewPool(poolInfo.obj.gameObject);
            }
        }
    }

    private GameObject MakeNewPool(GameObject obj)
    {
        GameObject clone = Instantiate(obj,
            Vector3.zero,
            Quaternion.identity,
            poolStorage[obj.name].Item1.transform);
        clone.name = obj.name;
        clone.SetActive(false);
        return clone;
    }

    public GameObject GetPool(GameObject obj, Vector3 pos, Quaternion rot)
    {
        if (!poolStorage.ContainsKey(obj.name))
        {
            print("No key in poolStorage");
            return null;
        }

        Transform poolParent = poolStorage[obj.name].Item1.transform;
        for (int i = 0; i < poolParent.childCount; i++)
        {
            GameObject thisPool = poolParent.GetChild(i).gameObject;
            if (thisPool.activeSelf == false)
            {
                thisPool.SetActive(true);
                thisPool.transform.position = pos;
                thisPool.transform.rotation = rot;
                return thisPool;
            }
        }
        GameObject newPool = MakeNewPool(obj);
        newPool.SetActive(true);
        newPool.transform.position = pos;
        newPool.transform.rotation = rot;
        return newPool;
    }

    public GameObject GetPool(string objName, Vector3 pos, Quaternion rot)
    {
        if (!poolStorage.ContainsKey(objName))
        {
            print("No key in poolStorage");
            return null;
        }

        GameObject obj = poolStorage[objName].Item2;

        Transform poolParent = poolStorage[objName].Item1.transform;
        for (int i = 0; i < poolParent.childCount; i++)
        {
            GameObject thisPool = poolParent.GetChild(i).gameObject;
            if (thisPool.activeSelf == false)
            {
                thisPool.SetActive(true);
                thisPool.transform.position = pos;
                thisPool.transform.rotation = rot;
                return thisPool;
            }
        }
        GameObject newPool = MakeNewPool(obj);
        newPool.SetActive(true);
        newPool.transform.position = pos;
        newPool.transform.rotation = rot;
        return newPool;
    }

    List<(GameObject, float)> removingList = new List<(GameObject, float)>();

    private void Update()
    {
        CheckRemovingList();
    }

    void CheckRemovingList()
    {
        for (int i = 0; i < removingList.Count; i++)
        {
            removingList[i] = new(removingList[i].Item1, removingList[i].Item2 - Time.deltaTime);
            if (removingList[i].Item2 <= 0)
            {
                if (removingList[i].Item1) RemovePool(removingList[i].Item1);
                removingList.RemoveAt(i);
                return;
            }

        }
    }

    public void RemovePool(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void RemovePool(GameObject obj, float time)
    {
        removingList.Add((obj, time));
    }
}