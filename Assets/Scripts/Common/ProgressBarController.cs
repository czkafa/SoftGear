using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace SoftGear.Common
{
    [RequireComponent(typeof(Image))]
    public class ProgressBarController : MonoBehaviour
    {
        [SerializeField]
        Image gaugeImage;
        [SerializeField]
        float tick;

        float minValue = 0;
        float maxValue = 100;
        float currentValue;
        float newValue;
        bool isInitialized = false;
        Coroutine currentCoroutine;
        int toSubstract = 0;

        public void Init(int initValue)
        {
            this.toSubstract = 0;
            this.currentValue = initValue;
            this.maxValue = initValue;
            this.isInitialized = true;
            this.gaugeImage.fillAmount = 1;
        }

        public void Substract(int newValueToSubstract)
        {
            if (newValueToSubstract <= 0)
                return;

            toSubstract += newValueToSubstract;
            if (isInitialized && currentValue > 0)
            {
                if (currentCoroutine != null)
                    StopCoroutine(currentCoroutine);
                currentCoroutine = StartCoroutine(SetAnimation(maxValue - toSubstract));

                return;
            }
        }

        IEnumerator SetAnimation(float i)
        {
            float valueToAddOnTick = (i - currentValue) / tick;
            while (currentValue > i)
            {
                currentValue += valueToAddOnTick;
                gaugeImage.fillAmount = currentValue / maxValue;
                if (currentValue <= 0)
                {
                    this.enabled = false;
                    OnEmptyProgressBar();
                    break;
                }
                yield return null;
            }
        }
        public delegate void OnProgressBarEmpty();
        public event OnProgressBarEmpty ProgressBarEmpty;

        protected void OnEmptyProgressBar()
        {
            OnProgressBarEmpty handler = ProgressBarEmpty;
            if (handler != null)
            {
                handler();
            }
        }
    }
}
