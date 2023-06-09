using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text ClearPicText;
    public Text OverClearPictext;
    public Text ScoreText;
    public Text BestScoreText;
    public PictureSpawn ManagePicture;
    public GameObject GameOverUI;
    public TimeLimit timelim;

    public Score score;
    public bool gameStart;
    public bool gameOver;

    private void Awake()
    {
        if (instance == null)
        {
            GameManager.instance = this;
        }

        //DontDestroyOnLoad(gameObject);
        gameOver = false;
        gameStart = false;
    }

    private void Update()
    {
        ShowLeft();
        GameOver();
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void ShowLeft()
    {
        ClearPicText.text = "남은 그림 : " + (ManagePicture.PictureList.Count - ManagePicture._ClearCount + 1);
    }

    public void GameOver()
    {
        if ((ManagePicture.PictureList.Count - ManagePicture._ClearCount) == 0 || timelim.LimitTime <= 0f)
        {
            gameOver = true;
            GameOverUI.SetActive(true);
            score.CalScore();
            OverClearPictext.text = ClearPicText.text;
            ScoreText.text = "점수 : " + score.ReturnScore();
        }
    }

    public void BestScore()
    {
        BestScoreText.text = "최고 점수 : " + score.ReturnBestScore();
    }
}