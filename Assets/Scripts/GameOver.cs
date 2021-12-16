using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject GameOverInterface;

    [Inject]
    PlatformManager PlatformManager;
    [Inject]
    PlayerMovment Player;
    private void OnEnable()
    {
        Enemy.OnPlayerMeetEnemy += ShowGameOverInterface;
    }
    private void OnDisable()
    {
        Enemy.OnPlayerMeetEnemy -= ShowGameOverInterface;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void ShowGameOverInterface()
    {
        GameOverInterface.SetActive(true);
    }

    public void ResetAllToStartPosition()
    {
        Player.ReturnToStartPosition();
        PlatformManager.ResetPlatforms();
    }
}
