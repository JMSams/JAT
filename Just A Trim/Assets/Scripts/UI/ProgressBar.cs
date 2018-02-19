using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BJGames.JAT
{
    public class ProgressBar : MonoBehaviour
    {
        Image background;

        Image bar;
        RectTransform barTransform;

        public bool showText = false;
        TextMeshProUGUI text;
        public string textPrefix = "Beard";

        float minValue = 0f;
        public float maxValue = 100f;

        float value = 0f;

        Vector2 barOffsetMin, barOffsetMax;

        void Start()
        {
            background = GetComponent<Image>();
            if (background == null)
                Debug.LogError("Progress bar component requires an Image component on the same object!");

            barTransform = transform.Find("BarContainer").Find("Bar") as RectTransform;
            bar = barTransform.GetComponent<Image>();

            barTransform.anchorMin = Vector2.zero;

            Transform textTransform = transform.Find("Text");
            if (showText)
            {
                text = textTransform.GetComponent<TextMeshProUGUI>();
            }
            else if (textTransform != null)
            {
                Destroy(textTransform.gameObject);
            }
            
            UpdateProgress(0f);
        }

#if DEBUG
        void FixedUpdate()
        {
            UpdateProgress(value + Time.fixedDeltaTime);
        }
#endif

        void UpdateProgress(float newValue)
        {
            if (newValue <= minValue) value = minValue;
            else if (newValue >= maxValue) value = maxValue;
            else value = newValue;

            float percentage = value / maxValue;

            barTransform.anchorMax = new Vector2(percentage, 1f);

            if (showText && text != null)
            {
                text.text = string.Format("{0}: {1:000}%", textPrefix, percentage * 100f);
            }
        }
    }
}