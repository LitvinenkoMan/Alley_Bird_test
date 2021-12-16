using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Enemy : MonoBehaviour
{
    [Inject]
    PlayerMovment player;
    [SerializeField]
    bool CanMove;
    [SerializeField]
    float OneStep;

    int _xDirection = 1;
    int XDirection
    {
        get { return _xDirection; }
        set
        {
            if (value == -1 || value == 1)
            {
                _xDirection = value;
            }
        }
    }

    public delegate void PlayerMeetEnemy();
    public static event PlayerMeetEnemy OnPlayerMeetEnemy;

    void Start()
    {

    }

    void Update()
    {

        if (CheckForDistanceBetweenPlayerOnY(6))
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            Move();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            OnPlayerMeetEnemy?.Invoke();
            //player.GetComponent<GameOver>().ShowGameOverInterface();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        XDirection *= -1;
    }

    private void Move()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(OneStep * XDirection, 0);
    }

    public void StopMovement()
    {
        CanMove = false;
    }

    public void StartMovement()
    {
        CanMove = true;
    }

    bool CheckForDistanceBetweenPlayerOnY(float distance)
    {
        if (player.GetCurrentPosition().y - gameObject.transform.position.y > distance)
        {
            return true;
        }
        else return false;
    }
}

