using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HairyIndies.JAT
{
    public class GameOverScreen : MonoBehaviour
    {
        Animator animator;

        bool isGameOver = false;

		//CameraVariables
		Animator m_Animator;
		bool m_Camera;

        void Start()
        {
            animator = GetComponent<Animator>();


			//Camera Animations
			m_Animator = gameObject.GetComponent<Animator>();
			m_Camera = false;
        }

        public void GameOver()
        {
            if (!isGameOver)
            {
                isGameOver = true;
                animator.SetTrigger("Open");


				//moves camera back to the next customer zone
				m_Animator.SetBool("RoundOver", true);
            }
        }
    }
}