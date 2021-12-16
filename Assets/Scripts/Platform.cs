using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Platform : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D platformCollider;
    [SerializeField]
    TextMeshProUGUI scoreCountText;


    [Inject]
    PlayerMovment player;
    [Inject]
    ICountable ScoreCounter;
    [SerializeField]
    Vector3 StartPosition;
    bool IsPlayerAbove = false;

    public delegate void PlayerAbovePlatform();
    public static event PlayerAbovePlatform OnPlayerAbovePlatform;
    void Start()
    {
        StartPosition = transform.position;
        if (!platformCollider)
        {
            platformCollider = GetComponent<BoxCollider2D>();
        }
    }

    void Update()
    {
        if (CheckForPlayerAbove())
        {
            platformCollider.enabled = true;
            scoreCountText.enabled = true;
            if (!IsPlayerAbove)
            {
                SetScoreOnPlatform();
                IsPlayerAbove = true;
                OnPlayerAbovePlatform?.Invoke();
            }
        }
        else platformCollider.enabled = false;

        if (CheckForDistanceBetweenPlayerOnY(6))
        {
            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        IsPlayerAbove = false;
        scoreCountText.text = "";
        scoreCountText.enabled = true;
        
    }

    bool CheckForPlayerAbove() 
    {
        if (transform.position.y < player.GetCurrentPosition().y)
        {
            return true;
        }
        else return false;
    }

    void SetScoreOnPlatform() 
    {
        scoreCountText.text = ScoreCounter.GetCounterNumber().ToString();
    }

    bool CheckForDistanceBetweenPlayerOnY(float distance) 
    {
        if (player.GetCurrentPosition().y - gameObject.transform.position.y > distance)
        {
            return true;
        }
        else return false;
    }

    public void ReturnToStartPosition() 
    {
        gameObject.transform.position = StartPosition;
    }
}
