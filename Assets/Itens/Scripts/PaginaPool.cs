using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaginaPool : MonoBehaviour
{
    public static PaginaPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public PaginaPool _inimigo_Control;

    void Awake()
    {
        SharedInstance = this;
        _inimigo_Control = Camera.main.GetComponent<PaginaPool>();
    }
    //
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
            //_inimigo_Control.iniList_1.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
