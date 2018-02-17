using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BJGames.JAT
{
    public class Timer : MonoBehaviour
    {
        public string timerPrefix = "Time: ";
        public string timerSuffix = "";
        public Text timerText;

        float time
        {
            get
            {
                return Mathf.Round(Time.timeSinceLevelLoad * 10f) / 10f;
            }
        }
        
        void Update()
        {
            timerText.text = string.Format("{1}{0:0.0}{2}", time, timerPrefix, timerSuffix);
        }
    }
}