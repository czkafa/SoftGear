using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoftGear.Weapon
{
    public class Weaponary : List<Weapon>
    {
        Weapon currentlySelectedWeapon;
        List<Weapon> weaponList;

        public void Init(List<Weapon> weaponList, Weapon defaultWeapon)
        {
            this.weaponList = weaponList;
            this.currentlySelectedWeapon = defaultWeapon;
            this.weaponList.ForEach(x => x.Init(CheckOthers));
        }

        public void Refresh()
        {

        }

        public void Attack()
        {
            currentlySelectedWeapon.Attack();
        }

        void CheckOthers(Weapon weaponToSelect)
        {
            currentlySelectedWeapon.UnselectWeapon();
            weaponToSelect.SelectWeapon();
        }

    }
}