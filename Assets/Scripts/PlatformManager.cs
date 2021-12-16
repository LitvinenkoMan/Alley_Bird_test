using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class PlatformManager : MonoBehaviour
{
    [Inject]
    IObjectPooler objectPoolPlatforms;

    [SerializeField]
    List<Platform> platforms = new List<Platform>();
    private void OnEnable()
    {
        Enemy.OnPlayerMeetEnemy += DeactivatePlatforms;
    }
    private void OnDisable()
    {
        Enemy.OnPlayerMeetEnemy -= DeactivatePlatforms;
    }

    void Start()
    {
        objectPoolPlatforms.GetPool().ForEach(x => platforms.Add(x.GetComponent<Platform>()));
    }

    void Update()
    {
        if (objectPoolPlatforms.GetOrCreateObject())
        {
            GameObject newPlatform = objectPoolPlatforms.GetOrCreateObject();
            newPlatform.transform.position = GetPositionOfHighestPlatform() + new Vector3(0, 2, 0);
            if (newPlatform.GetComponent<Platform>())
            {
                newPlatform.GetComponent<Platform>().Reset();
            }
            newPlatform.SetActive(true);
        }
    }

    public Vector3 GetPositionOfHighestPlatform() 
    {
        Vector3 PositionOfHighestPlatform = platforms[0].transform.position;
        foreach (var item in platforms)
        {
            if (item.gameObject.transform.position.y > PositionOfHighestPlatform.y)
            {
                PositionOfHighestPlatform = item.gameObject.transform.position;
            }
        }
        return PositionOfHighestPlatform;
    }

    public void ResetPlatforms() 
    {
        foreach (var item in platforms)
        {
            item.ReturnToStartPosition();
            item.Reset();
        }
    }

    public void DeactivatePlatforms() 
    {
        foreach (var item in platforms)
        {
            item.enabled = false;
        }
    }

    public void ActivatePlatforms() 
    {
        foreach (var item in platforms)
        {
            item.enabled = true;
        }
    }
}
