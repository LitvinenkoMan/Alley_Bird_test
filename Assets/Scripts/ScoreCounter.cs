using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour, ICountable
{
    int Score;

    [SerializeField]
    List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    private void OnEnable()
    {
        Enemy.OnPlayerMeetEnemy += Reset;
        Platform.OnPlayerAbovePlatform += SetScoreOnText;
        Platform.OnPlayerAbovePlatform += OneTick;
    }

    private void OnDisable()
    {
        Enemy.OnPlayerMeetEnemy -= Reset;
        Platform.OnPlayerAbovePlatform -= SetScoreOnText;
        Platform.OnPlayerAbovePlatform -= OneTick;
    }

    void Start()
    {
        Score = 0;
    }

    public void OneTick()
    {
        Score++;
    }

    public float GetCounterNumber()
    {
        return Score;
    }

    public void SetScoreOnText() 
    {
        foreach (var item in texts)
        {
            item.text = Score.ToString();
        }
    }

    public void Reset()
    {
        Score = 0;
    }
}
