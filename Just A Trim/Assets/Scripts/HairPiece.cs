using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace HairyIndies.JAT
{
    public class HairPiece : MonoBehaviour, IDropHandler
    {
        public HairTypes hairType;

        [Tooltip("The time between this hair starting to grow and it reaching maximum length.")]
        public float timeToMaxGrowth = 20f;

        [Tooltip("The time between the start of the level and this hair starting to grow.")]
        public float startTime = 0f;

        [Tooltip("The sprites for the hair animation, in order.")]
        public List<Sprite> animationSprites;

        int frameCount { get { return animationSprites.Count - 1; } }
        float timeBetweenFrames { get { return timeToMaxGrowth / frameCount; } }

        int _frameIndex = 0;
        int currentFrameIndex
        {
            get
            {
                return _frameIndex;
            }
            set
            {
                if (value < 0)
                {
                    _frameIndex = 0;
                    image.sprite = animationSprites[_frameIndex];
                }
                else if (value <= frameCount)
                {
                    _frameIndex = value;
                    image.sprite = animationSprites[_frameIndex];
                }
            }
        }

        Image image;

        float lastFrameTime;

        public bool isActive { get; protected set; }
        
        public float progress
        {
            get
            {
                Debug.Log(hairType + " frame count: " + frameCount);
                return (currentFrameIndex + 1f + frameProgress) / (frameCount + 1f);
            }
        }

        public float frameProgress
        {
            get
            {
                return (Time.time - lastFrameTime) / timeBetweenFrames;
            }
        }

        ProgressBar progressBar;
    
        void Start()
        {
            isActive = false;

            progressBar = GameObject.FindObjectOfType<ProgressBar>();
            progressBar.RegisterHair(this);

            image = GetComponent<Image>() ?? gameObject.AddComponent<Image>();
            image.sprite = animationSprites[0];
        }

        void Update()
        {
            if (!isActive)
            {
                if (Time.time >= startTime)
                {
                    isActive = true;
                    lastFrameTime = Time.time;
                }
            }
            else
            {
                if (Time.time - lastFrameTime >= timeBetweenFrames)
                {
                    currentFrameIndex++;
                    lastFrameTime = Time.time;
                }
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!isActive)
            {
                Debug.Log(hairType + " not ready for cutting...");
                return;
            }

            Tool droppedTool = eventData.pointerDrag.GetComponent<Tool>();

            if (droppedTool == null)
            {
                Debug.Log("Dropped object was not a tool.");
                return;
            }

            if (hairType != droppedTool.hairTypeToCut)
            {
                Debug.Log(droppedTool.name + " not valid for this hair type (" + hairType + ").");
                return;
            }

            Debug.Log("Dropped correct tool, cutting hair!");
            int framesToCut = Mathf.RoundToInt(frameCount * droppedTool.percentageToCut);
            currentFrameIndex -= framesToCut;
            lastFrameTime = Time.time;
        }
    }
}