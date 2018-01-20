using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SoftGear.Enemy;
using SoftGear.Common;
using SoftGear.Weapon;

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
    [SerializeField]
    GameObject weaponaryTransform;
    [SerializeField]
    Weapon defaultWeapon;
    EnemyUnit currentOpponent;
    Weaponary weaponary;

    void Start()
    {
        var weaponsFromGUI = weaponaryTransform.GetComponentsInChildren<Weapon>();
        List<Weapon> weaponList = new List<Weapon>();
        Dictionary<Weapon, bool> weaponStatusDictionary = new Dictionary<Weapon, bool>();
        foreach (var weaponFromGUI in weaponsFromGUI)
        {
            weaponList.Add(weaponFromGUI);
            var isUnlocked = weaponFromGUI == defaultWeapon;
            weaponStatusDictionary.Add(weaponFromGUI, isUnlocked);

        }
        UserInfo.Instance.OwnedWeapons = weaponStatusDictionary;
        weaponary = new Weaponary();
        weaponary.Init(weaponList, defaultWeapon);
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
