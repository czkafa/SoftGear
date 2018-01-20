using Assets.Scripts.Common.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoftGear.Weapons
{
    public class Gyoza : Weapon
    {
        public override void Attack()
        {

        }
        public override void CheckWeapon()
        {
            button.interactable = true;
        }
    }
}