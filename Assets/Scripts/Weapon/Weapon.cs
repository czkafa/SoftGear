using Assets.Scripts.Common.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoftGear.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        protected Button button;
        [SerializeField]
        protected GameObject lockIcon;
        bool active = false;
        bool selected = false;
        Action<Weapon> checkOthers;

        [SerializeField]
        public int weaponPrice;
        [SerializeField]
        public int weaponDamage;
        [SerializeField]
        public WeaponType WeaponType;
        [SerializeField]
        public WeaponName WeaponName;

        public void Init(Action<Weapon> checkOthers)
        {
            this.checkOthers = checkOthers;
            button.onClick.AddListener(Select);
            button.onClick.AddListener(Attack);
            CheckLocking();
        }

        public void SelectWeapon()
        {
            button.targetGraphic.color = Color.white;
            selected = true;
        }

        public void UnselectWeapon()
        {
            button.targetGraphic.color = Color.gray;
            selected = false;
        }

        public void Select()
        {
            if (selected)
                Attack();
            else
                checkOthers(this);
        }

        public virtual void Attack()
        {

        }

        public void CheckLocking()
        {
            bool tryResult;
            if (UserInfo.Instance.OwnedWeapons.TryGetValue(this, out tryResult))
                Lock(tryResult);

        }

        public virtual void Lock(bool shouldBeUnlocked)
        {
            lockIcon.SetActive(!shouldBeUnlocked);
            button.interactable = shouldBeUnlocked;
        }

        public virtual void CheckWeapon()
        {
            button.interactable = true;
        }
    }
}