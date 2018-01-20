using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoftGear.Shop
{
    [RequireComponent(typeof(Button))]
    public class ShopButton : MonoBehaviour
    {
        [SerializeField]
        GameObject shopWindow;
        [SerializeField]
        Button shopButton;

        void Start()
        {
            shopButton.onClick.AddListener(OpenUI);
        }

        void OpenUI()
        {
            shopWindow.SetActive(!shopWindow.activeSelf);
        }
    }
}
