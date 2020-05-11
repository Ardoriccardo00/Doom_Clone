using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public List<EnemyBehaviour> activeEnemies = new List<EnemyBehaviour>();

    #region Singleton
    public static EnemyHandler Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start()
    {
        EnemyBehaviour[] allEnemies = FindObjectsOfType<EnemyBehaviour>();
        foreach(EnemyBehaviour enemy in allEnemies)
        {
            activeEnemies.Add(enemy);
        }
    }

    public void AddEnemy(EnemyBehaviour newEnemy)
    {
        activeEnemies.Add(newEnemy);
    }

    public void RemoveEnemy(EnemyBehaviour enemyToRemove)
    {
        activeEnemies.Remove(enemyToRemove);
    }
} 