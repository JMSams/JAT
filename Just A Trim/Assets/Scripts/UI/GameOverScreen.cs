using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HairyIndies.JAT
{
    public class GameOverScreen : MonoBehaviour
    {
        Animator animator;

        bool isGameOver = false;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void GameOver()
        {
            if (!isGameOver)
            {
                isGameOver = true;
                animator.SetTrigger("Open");
            }
        }
    }
}