using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField]
    PlayerMovment player;
    [SerializeField]
    ScoreCounter ScoreCounter;
    [SerializeField]
    ObjectPool ObjectPoolPlatforms;
    [SerializeField]
    PlatformManager PlatformManager;
    [SerializeField]
    ObjectPool ObjectPoolEnemys;
    [SerializeField]
    GameOver GameOver;

    public override void InstallBindings()
    {
        Container.BindInstance(player);
        Container.BindInstance(GameOver);
        Container.BindInstance(PlatformManager);
        Container.BindInstance<ICountable>(ScoreCounter);
        Container.BindInstance<IObjectPooler>(ObjectPoolPlatforms);
        Container.BindInstance<IObjectPooler>(ObjectPoolEnemys).WithId("ObjectPoolEnemies");
    }
}