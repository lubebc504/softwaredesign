using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text ClearPicText;
    public Text OverClearPictext;
    public Text ScoreText;
    public PictureSpawn ManagePicture;
    public GameObject GameOverUI;
    public TimeLimit timelim;
    public PlayerHeart heart;
    public Score score;
    public bool gameOver;

    private void Awake()
    {
        if (instance == null)
        {
            GameManager.instance = this;
        }

        //DontDestroyOnLoad(gameObject);
        gameOver = false;
    }

    public void GameOver()
    {
        if ((ManagePicture.PictureList.Count - ManagePicture._ClearCount) == 0 || timelim.LimitTime <= 0f || heart.health == 0f)
        {
            gameOver = true;
            GameOverUI.SetActive(true);
            score.CalScore();
            OverClearPictext.text = ClearPicText.text;
            ScoreText.text = "Á¡¼ö : " + score.ReturnScore();
        }
    }
}