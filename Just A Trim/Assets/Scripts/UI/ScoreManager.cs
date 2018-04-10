using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace HairyIndies.JAT
{
    public class ScoreManager : MonoBehaviour
    {
        int _s = 0;
        public int score
        {
            get
            {
                return _s;
            }
            set
            {
                _s = value;
                scoreText.text = score.ToString();
            }
        }

        [Tooltip("The text used to display the score.")]
        public Text scoreText;

        void Awake()
        {
            score = 0;
        }
    }
}