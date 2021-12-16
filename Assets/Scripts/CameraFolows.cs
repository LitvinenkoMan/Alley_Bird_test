using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraFolows : MonoBehaviour
{
    [Inject]
    PlayerMovment player;

    Camera camera;

    bool startFollow;

    void Start()
    {
        startFollow = false;
        camera = Camera.main;
    }

    void Update()
    {
        if (startFollow)
        {
            SetPosition(new Vector2(0, player.GetCurrentPosition().y + 2));
        }
    }

    private void SetPosition(Vector2 newPosition)
    {
        camera.transform.position = newPosition;
    }

    public void StartFollow() 
    {
        startFollow = true;
    }

    public void StopFollow() 
    {
        startFollow = false;
    }
}
