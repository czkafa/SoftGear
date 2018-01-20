using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoftGear.Weapons
{
    public class Weaponary
    {
        Weapon currentlySelectedWeapon;
        public List<Weapon> WeaponList;

        public void Init(List<Weapon> weaponList, Weapon defaultWeapon)
        {
            this.WeaponList = weaponList;
            this.currentlySelectedWeapon = defaultWeapon;
            this.WeaponList.ForEach(x => { if (!x.Equals(defaultWeapon)) x.UnselectWeapon(); });
            this.WeaponList.ForEach(x => x.Init(CheckOthers));
        }

        public void Refresh()
        {

        }

        public int AttackDamage()
        {
            return currentlySelectedWeapon.weaponDamage;
        }

        void CheckOthers(Weapon weaponToSelect)
        {
            currentlySelectedWeapon.UnselectWeapon();
            weaponToSelect.SelectWeapon();
            currentlySelectedWeapon = weaponToSelect;
        }

    }
}