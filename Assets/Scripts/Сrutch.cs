using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class Сrutch : MonoBehaviour
{

    [Inject]
    PlayerMovment player;
    [Inject]
    ICountable ScoreCounter;
    [Inject]
    IObjectPooler ObjectPoolPlatforms;
    [Inject]
    PlatformManager PlatformManager;
    [Inject]
    IObjectPooler ObjectPoolEnemys;
    [Inject]
    GameOver GameOver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            player.gameObject.SetActive(false);
            player.ReturnToStartPosition();
            //ObjectPoolPlatforms.DeactivateGameObjects();
            //ObjectPoolEnemys.DeactivateGameObjects();
            PlatformManager.ResetPlatforms();
            GameOver.ResetAllToStartPosition();
            ScoreCounter.Reset();
            player.gameObject.SetActive(true);
        }
    }
}
