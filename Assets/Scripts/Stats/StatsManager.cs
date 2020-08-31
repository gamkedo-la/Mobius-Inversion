using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public int enemyKillScore = 0;
    public int playerDeaths = 0;
    public int damageDealt = 0;
    public int damageTaken = 0;

    private void Awake()
    {
        PlayerDestroy.StatsOnPlayerDestroyEnemy += IncrementStatPlayerDestroyEnemy;
    }

    private void Start()
    {
        DisplayStats();
    }

    private void Update()
    {
        
    }

    private void DisplayStats()
    {
        
    }
    public void IncrementStatPlayerDestroyEnemy(PlayerShot playerShot, int value)
    {
        enemyKillScore += value;
        Debug.Log(playerShot.FiredFrom.ToString() + " scored a kill");
    }
}
