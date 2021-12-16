using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    TrailRenderer Trail;
    [SerializeField]
    Vector2 Position;
    [SerializeField]
    float JumpForce = 100;
    [SerializeField]
    float OneStep = 0.1f;

    [SerializeField]
    bool CanMove;
    bool CanJump;

    Rigidbody2D rigidbody2D;
    Vector3 StartPosition;
    int maxJumpCount = 2;
    int CurrentJumpCount;
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

    private void OnEnable()
    {
        Enemy.OnPlayerMeetEnemy += StopMove;
    }

    private void OnDisable()
    {
        Enemy.OnPlayerMeetEnemy -= StopMove;
    }


    void Start()
    {
        StartPosition = gameObject.transform.position;
        CurrentJumpCount = maxJumpCount;
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (OneStep == 0)
            OneStep = 0.1f;
    }

    private void Update()
    {
        if (CanMove)
        {
            if (/*(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || */Input.GetMouseButtonDown(0))
                Jump();
        }
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            if (CanJump)
            {
                
            }
            Move();
        }
        Position = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        XDirection *= -1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CurrentJumpCount = maxJumpCount;
    }

    private void Move()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(OneStep * XDirection, 0);
    }

    public Vector2 GetCurrentPosition()
    {
        return Position;
    }

    void Jump()
    {
        if (rigidbody2D && CurrentJumpCount > 0)
        {
            CurrentJumpCount--;
            rigidbody2D.Sleep();
            rigidbody2D.AddForce(Vector2.up * JumpForce * Time.fixedDeltaTime);
            Debug.Log($"Jumps left: {CurrentJumpCount}");
        }
    }

    public bool GetCanMoveState()
    {
        return CanMove;
    }

    public void StopMove()
    {
        CanMove = false;
    }
    public void StartMove()
    {
        CanMove = true;
    }

    public void ReturnToStartPosition()
    {
        transform.position = StartPosition;
        rigidbody2D.Sleep();
        rigidbody2D.WakeUp();
    }
}
