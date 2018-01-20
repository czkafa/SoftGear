using SoftGear.Weapon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{

    private static UserInfo instance;
    private UserInfo() { }

    public static UserInfo Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UserInfo();
            }
            return instance;
        }
    }
    private int gearAmount = 0;

    public int GearAmount
    {
        get { return gearAmount; }
        set
        {
            if (gearAmount != value)
            {
                gearAmount = value;
                OnUserInfoUpdated();
            }
        }
    }

    private Dictionary<Weapon, bool> ownedWeapons = new Dictionary<Weapon, bool>();

    public Dictionary<Weapon, bool> OwnedWeapons
    {
        get { return ownedWeapons; }
        set
        {
            ownedWeapons = value;
            OnUserInfoUpdated();

        }
    }

    public delegate void OnUserInfoUpdateHandler();
    public event OnUserInfoUpdateHandler UserInfoUpdate;

    protected virtual void OnUserInfoUpdated()
    {
        OnUserInfoUpdateHandler handler = UserInfoUpdate;
        if (handler != null)
        {
            handler();
        }
    }
}
