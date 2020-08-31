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
        PlayerControl.StatsOnPlayerDeath += IncrementStatPlayerDeaths;
    }

    private void IncrementStatPlayerDeaths(PlayerControl playerControl)
    {
        playerDeaths++;
        Debug.Log(playerControl.thisShip + " ship suffered critical damage");
    }

    private void IncrementStatPlayerDestroyEnemy(PlayerShot playerShot, int value)
    {
        enemyKillScore += value;
        Debug.Log(playerShot.FiredFrom.ToString() + " scored a kill");
    }
}
