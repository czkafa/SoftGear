using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoftGear.Weapon
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

        public void Init(Action<Weapon> checkOthers)
        {
            this.checkOthers = checkOthers;
            button.onClick.AddListener(Select);
            button.onClick.AddListener(Attack);
            CheckLocking();
        }

        public void SelectWeapon()
        {
            selected = true;
        }

        public void UnselectWeapon()
        {
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

        public virtual void Lock(bool shouldBeLocked)
        {
            lockIcon.SetActive(!shouldBeLocked);
            button.interactable = shouldBeLocked;
        }

        public virtual void CheckWeapon()
        {
            button.interactable = true;
        }
    }
}