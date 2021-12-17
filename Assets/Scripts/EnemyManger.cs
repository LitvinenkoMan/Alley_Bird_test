using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyManger : MonoBehaviour
{
    [Inject]
    PlatformManager PlatformManager;
    [SerializeField, Range(0, 100)]
    float Chance;
    [Inject(Id = "ObjectPoolEnemies")]
    IObjectPooler ObjectPoolEnemies;

    [Inject]
    IObjectPooler ObjectPoolPlatforms;

    void Start()
    {
        if (Chance == 0)
            Chance = 50;
    }

    void Update()
    {

    }

    private void OnEnable()
    {
        Platform.OnPlayerAbovePlatform += TryToPlaceEnemyWithChanse;
    }

    private void OnDisable()
    {
        Platform.OnPlayerAbovePlatform -= TryToPlaceEnemyWithChanse;
    }

    public void PlaceEnemyOnPlatform()
    {
        GameObject Enemy = ObjectPoolEnemies.GetOrCreateObject();
        if (Enemy)
        {
            Enemy.transform.position = PlatformManager.GetPositionOfHighestPlatform() + new Vector3(Random.Range(-2f, 2f), 2.5f, 0);
            Enemy.SetActive(true);
        }
    }

    public void TryToPlaceEnemyWithChanse()
    {
        if (Random.Range(0, 100) <= Chance)
        {
            PlaceEnemyOnPlatform();
        }
    }

    public void RestartEnemiesPositions() 
    {
        foreach (var item in ObjectPoolPlatforms.GetPool())
        {
            if (item != ObjectPoolPlatforms.GetPool()[0] && Random.Range(0, 100) >= Chance)
            {
                GameObject Enemy = ObjectPoolEnemies.GetOrCreateObject();
                if (Enemy)
                {
                    Enemy.transform.position = item.transform.position + new Vector3(Random.Range(-2f, 2f), 0.5f, 0);
                    Enemy.SetActive(true);
                }
            }
        }
    }

    public void DeactivateEnemys() 
    {
        ObjectPoolEnemies.DeactivateGameObjects();
    }



}
