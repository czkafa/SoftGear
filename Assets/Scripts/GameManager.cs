using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Enemy;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    EnemyUnit enemyPrefab;
    // Use this for initialization
    void Start()
    {
        GameObject.Instantiate(enemyPrefab, spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
