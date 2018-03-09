using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HairyIndies.JAT
{
    public class GameOverScreen : MonoBehaviour
    {
        Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void GameOver()
        {
            animator.SetTrigger("Open");
        }
    }
}