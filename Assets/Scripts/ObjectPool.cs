using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour, IObjectPooler
{
    [SerializeField]
    List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField]
    int MaxLenght = 0;
    [SerializeField]
    GameObject example;
    [SerializeField]
    bool InitializeOnStart = true;


    void Start()
    {
        if (InitializeOnStart)
        {
            InitializePool(MaxLenght);
        }
    }

    void Update()
    {

    }

    public GameObject GetOrCreateObject()
    {
        foreach (var item in gameObjects)
        {
            if (!item.activeInHierarchy)
            {
                return item;
            }
            else
            {
                if (example != null && gameObjects.Count < MaxLenght)
                {
                    GameObject gameObject = Instantiate(example);
                    gameObject.SetActive(false);
                    return gameObject;
                }
            }
        }
        return null;
    }

    public void InitializePool(int maxCount)
    {
        MaxLenght = maxCount;
    }

    public List<GameObject> GetPool()
    {
        return gameObjects;
    }

    public void ChangeEnableState() 
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void DeactivateGameObjects()
    {
        foreach (var item in gameObjects)
        {
            item.SetActive(false);
        }
    }
}
