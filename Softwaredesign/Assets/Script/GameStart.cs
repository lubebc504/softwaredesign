using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject ScoreUI;

    public void StartGame()
    {
        this.gameObject.SetActive(false);
        GameManager.instance.gameStart = true;
    }

    public void ShowScore()
    {
        ScoreUI.SetActive(true);
        GameManager.instance.BestScore();
    }
}