using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BJGames.JAT
{
    public class Timer : MonoBehaviour
    {
        public string timerPrefix = "";
        public string timerSuffix = "";
        public TextMeshProUGUI timerText;

        int time
        {
            get
            {
                return Mathf.FloorToInt(Time.timeSinceLevelLoad);
            }
        }
        
        void Update()
        {
            timerText.text = string.Format("{1}{0}{2}", time, timerPrefix, timerSuffix);
        }
    }
}