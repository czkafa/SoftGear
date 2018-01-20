using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SoftGear.Weapons;

namespace SoftGear.Shop
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField]
        Button closeButton;
        [SerializeField]
        RectTransform weaponaryTransform;
        [SerializeField]
        RectTransform shopItemSpawnPoint;
        [SerializeField]
        ShopItem shopItemPrefab;

        List<ShopItem> shopItemList;

        void Start()
        {
            var weaponsFromGUI = weaponaryTransform.GetComponentsInChildren<Weapon>();
            List<Weapon> weaponList = new List<Weapon>();
            shopItemList = new List<ShopItem>();
            foreach (var weaponfromGUI in weaponsFromGUI)
            {
                var currentOpponent = GameObject.Instantiate(shopItemPrefab, shopItemSpawnPoint);
                currentOpponent.Init(weaponfromGUI);
                shopItemList.Add(currentOpponent);
            }
            closeButton.onClick.AddListener(ClosePopup);
        }


        void ClosePopup()
        {
            this.gameObject.SetActive(false);
        }

    }
}
