using System.Collections.Generic;
using UnityEngine;
interface IObjectPooler
{
    public void InitializePool(int maxCount);
    public GameObject GetOrCreateObject();
    public List<GameObject> GetPool();
    public void DeactivateGameObjects();

}
