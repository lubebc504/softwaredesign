using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text OriginalText;
    public GameObject HintButton;
    public GameObject scoreui;
    public GameObject LeftUI;

    public void BackButton()
    {
        scoreui.gameObject.SetActive(false);
    }

    public void Awake()
    {
        if (!GameManager.instance.gameStart)
        {
            OriginalText.gameObject.SetActive(false);
            HintButton.gameObject.SetActive(false);
            LeftUI.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!GameManager.instance.gameOver && GameManager.instance.gameStart)
        {
            if (!OriginalText.IsActive() && !HintButton.gameObject.activeInHierarchy && !LeftUI.gameObject.activeInHierarchy)
            {
                OriginalText.gameObject.SetActive(true);
                HintButton.gameObject.SetActive(true);
                LeftUI.gameObject.SetActive(true);
            }
        }
    }
}