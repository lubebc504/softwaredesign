using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    public float LimitTime = 300f;

    public Slider TimeSlider;
    public Image TimdSliderFillImage;

    // Start is called before the first frame update
    private void Start()
    {
        TimeSlider.maxValue = 300f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameManager.instance.gameOver)
        {
            LimitTime -= Time.deltaTime;
        }

        if (LimitTime <= 0f)
        {
            LimitTime = 0f;
        }
        if (LimitTime < 120f)
        {
            TimdSliderFillImage.color = Color.yellow;
        }
        if (LimitTime < 60f)
        {
            TimdSliderFillImage.color = Color.red;
        }
        TimeSlider.value = LimitTime;
    }
}