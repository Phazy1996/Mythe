using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour {

    public static EnemyPool instance;
    //the objects to pool, in this case the enemies
    public GameObject[] enemyPrefabs;
    // the gameobjects available
    public List<GameObject>[] pooledObjects;
    //the amount of objects to buffer each time 
    public int[] amountToBuffer;

    public int defaultBufferAmount;
    //a cointainer object to not clog up the editor
    protected GameObject containerObject;

    void Awake() {
        instance = this;
    }

    void Start() {
        containerObject = new GameObject("EnemyPool");
        //loop trough the enemy prefabs and create a list for each one because they only work with gameobjects set in the editor
        pooledObjects = new List<GameObject>[enemyPrefabs.Length];
        int i = 0;
        foreach (GameObject objectPrefab in enemyPrefabs)
        {
            pooledObjects[i] = new List<GameObject>();
            int bufferAmount;
            if (i < amountToBuffer.Length) bufferAmount = amountToBuffer[i];
            else
                bufferAmount = defaultBufferAmount;
            for (int n = 0; n < bufferAmount; n++)
            {
                GameObject newObj = Instantiate(objectPrefab) as GameObject;newObj.name = objectPrefab.name;
                PoolObject(newObj);

            }
            i++;

        }
    }

    public GameObject getObjectForType(string objectType,bool onlyPooled){
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            GameObject prefab = enemyPrefabs[i];
            if (prefab.name == objectType)
            {
                if (pooledObjects[i].Count > 0)
                {
                    GameObject pooledObject = pooledObjects[i][0];
                    pooledObjects[i].RemoveAt(0);
                    pooledObject.transform.parent = null;
                    pooledObject.SetActive(true);
                    return pooledObject;
                }
                else if (!onlyPooled)
                {
                    return Instantiate(enemyPrefabs[i]) as GameObject;
                }
                break;

            }
        }
        //If we have gotten here either there was no object of the specified type or non were left in the pool with onlyPooled set to true
        return null;
    }
    //this pools the specified object
    public void PoolObject(GameObject obj)
    {
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            if (enemyPrefabs[i].name == obj.name)
            {
                obj.SetActive(false);
                obj.transform.parent = containerObject.transform;
                pooledObjects[i].Add(obj);
                return;
            }
        }
    }
}
