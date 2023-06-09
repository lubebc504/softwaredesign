using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float score;
    private float bestscore;

    public void Awake()
    {
        bestscore = PlayerPrefs.GetFloat("BestScore");
        Debug.Log("Bestscore : " + bestscore);
        if (bestscore == 0)
        {
            bestscore = 0;
        }
    }

    public void CalScore()
    {
        score = (GameManager.instance.ManagePicture._ClearCount * 1000) + (GameManager.instance.timelim.LimitTime * 500);

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

    public float ReturnBestScore()
    {
        return bestscore;
    }
}