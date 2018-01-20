using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SoftGear.Enemy;
using SoftGear.Common;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    EnemyUnit enemyPrefab;
    [SerializeField]
    Button feedButton;
    [SerializeField]
    ProgressBarController progressBar;


    EnemyUnit currentOpponent;

    void Start()
    {
        SpawningNewOpponent();
        feedButton.onClick.AddListener(FeedEnemy);
        progressBar.Init(x);
    }

    void SpawningNewOpponent()
    {
        if (currentOpponent)
        {
            DestroyImmediate(currentOpponent);
        }
        currentOpponent = GameObject.Instantiate(enemyPrefab, spawnPoint);
        currentOpponent.Init();
    }

    int x = 10;
    public void FeedEnemy()
    {
        progressBar.Substract(1);
    }
}
