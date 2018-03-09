using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HairyIndies.JAT
{
    public class ProgressBar : MonoBehaviour
    {
        Slider slider;

        GameOverScreen gameOverScreen;

        Dictionary<HairTypes, HairPiece> hairPieces;

        int activeHairPieces
        {
            get
            {
                int i = 0;
                foreach (HairPiece piece in hairPieces.Values)
                    if (piece.isActive) i++;
                return i;
            }
        }

        void Awake()
        {
            hairPieces = new Dictionary<HairTypes, HairPiece>();
        }

        void Start()
        {
            gameOverScreen = GameObject.FindObjectOfType<GameOverScreen>();

            slider = GetComponent<Slider>();
            slider.minValue = 0;
            slider.maxValue = 1;
            slider.value = 0;
            slider.wholeNumbers = false;
        }

        void LateUpdate()
        {
            float total = 0f;
            foreach (HairPiece piece in hairPieces.Values)
                if (piece.isActive) total += piece.progress;

            slider.value = total / (activeHairPieces);

            if (slider.value >= 1f)
            {
                gameOverScreen.GameOver();
            }
        }

        public void RegisterHair(HairPiece piece)
        {
            if (hairPieces.ContainsKey(piece.hairType) && hairPieces[piece.hairType] != piece)
            {
                Debug.LogError("Registering a hair piece of type " + piece.hairType + " when one is already registered!");
                return;
            }

            hairPieces.Add(piece.hairType, piece);
        }
    }
}