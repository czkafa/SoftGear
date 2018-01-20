using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SoftGear.Enemy;
using SoftGear.Common;
using SoftGear.Weapons;
using Assets.Scripts.Common;

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
        ExtendedDictonary<Weapon, bool> weaponStatusDictionary = new ExtendedDictonary<Weapon, bool>();

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
        progressBar.Init(enemyLife);
        progressBar.ProgressBarEmpty += SpawningNewOpponent;

        UserInfo.Instance.UserInfoUpdate += RefreshingLocksForAllWeapons;
        UserInfo.Instance.OwnedWeapons.DictionaryUpdate += RefreshingLocksForAllWeapons;
    }

    void RefreshingLocksForAllWeapons()
    {
        weaponary.WeaponList.ForEach(x => x.CheckLocking());
    }

    void SpawningNewOpponent()
    {
        if (currentOpponent != null)
        {
            var coroutine = StartCoroutine(currentOpponent.RunningAway(() =>
            {
                UserInfo.Instance.GearAmount += 5;
                DestroyImmediate(currentOpponent.gameObject);
                currentOpponent = GameObject.Instantiate(enemyPrefab, spawnPoint);
                currentOpponent.Init();
                StartCoroutine(currentOpponent.Coming(() =>
                {
                    progressBar.Init(enemyLife);
                }));
            }));
        }
        else
        {
            currentOpponent = GameObject.Instantiate(enemyPrefab, spawnPoint);
            currentOpponent.Init();
            progressBar.Init(enemyLife);
            StartCoroutine(currentOpponent.Coming(() =>
            {
            }));

        }

    }

    int enemyLife = 100;
    public void FeedEnemy()
    {
        progressBar.Substract(weaponary.AttackDamage());
    }
}
