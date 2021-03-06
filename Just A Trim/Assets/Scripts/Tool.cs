﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HairyIndies.JAT
{
    [RequireComponent(typeof(CanvasGroup))]
    public class Tool : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Tooltip("The type of hair this tool will cut.")]
        public HairTypes hairTypeToCut;

        [Range(0f, 1f)] [Tooltip("The percentage of hair to cut.  If the hair growth is less than this amount, it will all be cut.")]
        public float percentageToCut = 0.25f;
        
        // The position the object was at when the drag started.
        Vector3 startPosition;
        CanvasGroup group;

		//Tool Animation variables
		Animator m_Animator;
		bool m_Tool;

        void Start()
        {
            group = GetComponent<CanvasGroup>();

            startPosition = transform.position;

			//Tool animation hook up
			m_Animator = gameObject.GetComponent<Animator>();
			m_Tool = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Started dragging " + this.name);
            group.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            newPosition.z = startPosition.z;

            transform.position = newPosition;

			//Tool picked up animations
			m_Animator.SetBool("RazorOpening", true);
            m_Animator.SetBool("ScissorsOpening", true);
			m_Animator.SetBool("ClippersOpening", true);
			m_Animator.SetBool("TweezersOpening", true);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("Stopped dragging " + this.name);
            
			//Tool inactive animations
			m_Animator.SetBool("RazorOpening", false);
            m_Animator.SetBool("ScissorsOpening", false);
			m_Animator.SetBool("ClippersOpening", false);
			m_Animator.SetBool("TweezersOpening", false);
        }

        //Should be called from an animation event on the last frame of the animation
        public void DropAnimationFinished()
        {
            transform.position = startPosition;
            group.blocksRaycasts = true;
        }
    }
}