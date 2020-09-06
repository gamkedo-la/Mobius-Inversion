using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StatsPoints : MonoBehaviour
{
    private int scoreGrowthRate = 100;
    public int pointsValue = 0;
    public int pointsTextValue = 0;
    public int targetValue = 10000;
    public bool statsPointsActive = false;

    public TMP_Text pointsText;

    private void Awake()
    {
        pointsText = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        if (statsPointsActive)
        {
            UpdatePointsOnScreen();
        }
    }

    public void StartPointsOnScreen()
    {
        statsPointsActive = true;
    }

    private void UpdatePointsOnScreen()
    {
        pointsTextValue = Convert.ToInt32(pointsText.text);

        if (pointsTextValue >= targetValue)
        {
            pointsValue = targetValue;
            StopPointsOnScreen();
        }
        else
        {
            pointsValue += scoreGrowthRate;
        }

        pointsText.text = pointsValue.ToString();
    }

    private void StopPointsOnScreen()
    {
        statsPointsActive = false;
    }
}
