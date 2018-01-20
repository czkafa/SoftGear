using Assets.Scripts.Common;
using SoftGear.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{

    private static UserInfo instance;
    private UserInfo()
    {
    }

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

    public Dictionary<Weapon, int> WeaponPrice;

    public ExtendedDictonary<Weapon, bool> OwnedWeapons;

    public delegate void OnUserInfoUpdateHandler();
    public event OnUserInfoUpdateHandler UserInfoUpdate;

    protected void OnUserInfoUpdated()
    {
        OnUserInfoUpdateHandler handler = UserInfoUpdate;
        if (handler != null)
        {
            handler();
        }
    }


}
