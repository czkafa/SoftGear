using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoftGear.Enemy
{
    public class EnemyUnit : MonoBehaviour
    {
        [SerializeField]
        RectTransform recTransform;
        [SerializeField]
        float runnningTempo=0.1f;
        public void Init()
        {

        }

        public IEnumerator RunningAway(Action callback)
        {
            while (true)
            {
                recTransform.anchoredPosition = new Vector2(recTransform.anchoredPosition.x - runnningTempo, recTransform.anchoredPosition.y);

                if (recTransform.position.x <= -12)
                {
                    callback();
                    break;
                }
                yield return null;
            }
        }
        public IEnumerator Coming(Action callback)
        {
            while (true)
            {
                recTransform.anchoredPosition= new Vector2(recTransform.anchoredPosition.x - runnningTempo, recTransform.anchoredPosition.y);

                if (recTransform.position.x <= 0)
                {
                    if(callback!=null)
                    callback();
                    break;
                }
                yield return null;
            }
        }

    }
}
