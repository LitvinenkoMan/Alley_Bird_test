using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour, IObjectPooler
{
    [SerializeField]
    List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField]
    GameObject Example;
    [SerializeField]
    int MaxLenght = 0;
    [SerializeField]
    bool InitializeOnStart = true;


    void Start()
    {
        if (InitializeOnStart)
        {
            InitializePool(MaxLenght);
        }
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
                if (Example != null && gameObjects.Count < MaxLenght)
                {
                    GameObject gameObject = Instantiate(Example);
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
        for (int i = 0; i < MaxLenght; i++)
        {
            gameObjects.Add(GetOrCreateObject());
        }

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
