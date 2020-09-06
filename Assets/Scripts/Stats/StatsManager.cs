using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ScoreRating { S, A, B, C, D}

public class StatsManager : MonoBehaviour
{
    // Fade
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private float fadeTime = 1.5f;
    [SerializeField] private GameObject statsObjects;

    // Stats UI Objects    
    [SerializeField] private StatsSlider enemiesKilledSliderUI;
    [SerializeField] private StatsPoints totalPointsUI;
    [SerializeField] private GameObject noRespawnsUsed;
    [SerializeField] private GameObject allEnemiesKilled;
    [SerializeField] private TMP_Text gradeText;

    // Stats Values
    [SerializeField] private int overallScore = 0;
    [SerializeField] private int enemiesKilled = 0;
    public int totalNumberOfEnemies = 0;
    [SerializeField] private int enemyKillScore = 0;
    [SerializeField] private int playerDeaths = 0;
    [SerializeField] private int playerDeathPenaltyValue = 500;
    [SerializeField] private float efficiency;
    [SerializeField] private ScoreRating scoreRating;

    private void Awake()
    {
        PlayerDestroy.StatsOnPlayerDestroyEnemy += IncrementStatPlayerDestroyEnemy;
        PlayerControl.StatsOnPlayerDeath += IncrementStatPlayerDeaths;
    }

    private void Start()
    {
        statsObjects.GetComponent<CanvasGroup>().alpha = 0;
        totalNumberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        // Test values
        //totalNumberOfEnemies = 100;
        //enemiesKilled = 100;
        //overallScore = 10000;
        //playerDeaths = 100;
        //ShowStatsScreen();
    }

    private void IncrementStatPlayerDeaths(PlayerControl playerControl)
    {
        playerDeaths++;
        Debug.Log(playerControl.thisShip + " ship suffered critical damage");
        overallScore -= playerDeathPenaltyValue;
        CalculateRating();
    }

    private void IncrementStatPlayerDestroyEnemy(PlayerShot playerShot, int value)
    {
        enemiesKilled++;
        enemyKillScore += value;
        Debug.Log(playerShot.FiredFrom.ToString() + " scored a kill");
        overallScore += value;
        CalculateRating();
    }

    public void ShowStatsScreen()
    {      
        // Fade and show stats screen
        StartCoroutine(StatsScreenRoutine());
    }

    IEnumerator StatsScreenRoutine()
    {
        yield return FadeStatsScreen();
        yield return new WaitForSeconds(3);
        ShowOverallScore();
        StartEnemiesKilledSlider();
        yield return new WaitForSeconds(3);
        StartCoroutine(ShowBonuses());
        CalculateRating();
    }

    IEnumerator FadeStatsScreen()
    {
        // Fade
        fadeAnimator.SetTrigger("FadeTrigger");
        yield return new WaitForSeconds(fadeTime);
        statsObjects.GetComponent<CanvasGroup>().alpha = 1;
        // Unfade
        fadeAnimator.SetTrigger("FadeTrigger");
    }

    private void ShowOverallScore()
    {
        //Debug.Log("ShowOverallScore");
        totalPointsUI.targetValue = overallScore;
        totalPointsUI.StartPointsOnScreen();        
    }

    private void StartEnemiesKilledSlider()
    {
        //Debug.Log("StartEnemiesKilledSlider");
        float sliderTarget = enemiesKilled / totalNumberOfEnemies;
        enemiesKilledSliderUI.targetValue = sliderTarget;
        enemiesKilledSliderUI.StartSlider();
        
    }
    IEnumerator ShowBonuses()
    {
        //Debug.Log("ShowBonuses");
        if (playerDeaths == 0)
        {
            noRespawnsUsed.SetActive(true);
            overallScore *= 2; // Double points if no HP bars used
            ShowOverallScore();
        }
        yield return new WaitForSeconds(1);
        if (enemiesKilled / totalNumberOfEnemies == 1)
        {
            allEnemiesKilled.SetActive(true);
        }

    }
    private void CalculateRating()
    {
        //Debug.Log("CalculateRating");
        //efficiency = (((enemiesKilled - playerDeaths) / totalNumberOfEnemies) * 100);
        efficiency = enemiesKilled - playerDeaths;
        efficiency /= totalNumberOfEnemies;
        efficiency *= 100;

        //Debug.Log("efficiency:" + efficiency);

        if (efficiency >= 85)
        {
            scoreRating = ScoreRating.S;
        }
        else if (efficiency >= 75)
        {
            scoreRating = ScoreRating.A;
        }
        else if (efficiency >= 65)
        {
            scoreRating = ScoreRating.B;
        }
        else if (efficiency >= 55)
        {
            scoreRating = ScoreRating.C;
        }
        else if (efficiency < 55)
        {
            scoreRating = ScoreRating.D;
        }
        gradeText.text = scoreRating.ToString();
    }
}
