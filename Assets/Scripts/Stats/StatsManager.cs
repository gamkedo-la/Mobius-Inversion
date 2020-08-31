using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public int enemyKills = 0;
    public int playerDeaths = 0;
    public int damageDealt = 0;
    public int damageTaken = 0;

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
    public void IncrementStat(int statistic, int value)
    {
        statistic += value;
    }
}
