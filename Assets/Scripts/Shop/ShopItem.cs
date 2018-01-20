using Assets.Scripts.Common.Enums;
using SoftGear.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoftGear.Shop
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField]
        Image itemImage;
        [SerializeField]
        Text itemName;
        [SerializeField]
        Text itemCost;
        [SerializeField]
        Button buyButton;

        [SerializeField]
        Sprite carrot;
        [SerializeField]
        Sprite gyoza;
        [SerializeField]
        Sprite karaage;

        WeaponName weaponName;
        Weapon weapon;

        public void Init(Weapon weaponToBuy)
        {
            this.weaponName = weaponToBuy.WeaponName;
            this.weapon = weaponToBuy;
            SetImage();
            SetName();
            SetPrice();
            SetBuyButton();
            buyButton.onClick.AddListener(BuyItem);
            UserInfo.Instance.UserInfoUpdate += SetBuyButton;
        }

        void SetImage()
        {
            switch (weaponName)
            {
                case WeaponName.Carrot:
                    itemImage.sprite = carrot;
                    break;
                case WeaponName.Gyoza:
                    itemImage.sprite = gyoza;
                    break;
                case WeaponName.Karaage:
                    itemImage.sprite = karaage;
                    break;
                default:
                    break;
            }
        }

        void SetName()
        {
            itemName.text = weaponName.ToString();
        }

        void SetPrice()
        {
            itemCost.text = GetPriceForItem(weaponName).ToString();
        }

        void SetBuyButton()
        {
            var isAlreadyBought = UserInfo.Instance.OwnedWeapons[weapon];
            var canBeBought = UserInfo.Instance.GearAmount >= GetPriceForItem(weaponName);

            buyButton.interactable = !isAlreadyBought && canBeBought;
        }

        void BuyItem()
        {
            UserInfo.Instance.GearAmount -= GetPriceForItem(weaponName);
            UserInfo.Instance.OwnedWeapons[weapon] = true;
            SetBuyButton();
        }

        int GetPriceForItem(WeaponName weaponName)
        {
            int cost = 0;
            switch (weaponName)
            {
                case WeaponName.Carrot:
                    cost = 0;
                    break;
                case WeaponName.Gyoza:
                    cost = 10;
                    break;
                case WeaponName.Karaage:
                    cost = 25;
                    break;
                default:
                    break;
            }
            return cost;
        }

    }
}
