using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameManager gamemanager;
    private float score;
    private float bestscore;

    public void Awake()
    {
        bestscore = PlayerPrefs.GetFloat("BestScore");
    }

    public void CalScore()
    {
        score = (gamemanager.ManagePicture._ClearCount * 1000) + (gamemanager.timelim.LimitTime * 500) + (gamemanager.heart.health * 1000);

        if (bestscore == 0)
        {
            PlayerPrefs.SetFloat("BestScore", score);
        }
        else if (score > bestscore)
        {
            PlayerPrefs.SetFloat("BestScore", score);
        }
    }

    public float ReturnScore()
    {
        return score;
    }
}