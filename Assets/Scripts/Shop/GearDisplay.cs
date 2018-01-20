using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoftGear.Shop
{
    public class GearDisplay : MonoBehaviour
    {
        [SerializeField]
        Text gearAmount;

        void Start()
        {
            UserInfo.Instance.UserInfoUpdate += RefreshCount;
            RefreshCount();
        }

        void RefreshCount()
        {
            gearAmount.text = UserInfo.Instance.GearAmount.ToString();
        }

        private void OnDestroy()
        {
            UserInfo.Instance.UserInfoUpdate -= RefreshCount;

        }
    }
}
