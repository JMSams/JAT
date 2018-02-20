using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BJGames.JAT
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class HairPiece : MonoBehaviour
    {
        public HairTypes hairType;

        public int framesPerSecond = 2;
        float secondsPerFrame { get { return 1f / framesPerSecond; } }

        public int currentFrame { get; protected set; }
        int lastFrame { get { return frames.Count - 1; } }

        public ProgressBar progressBar;

        public float timeBeforeStart = 0f;
        bool started = false;

        new SpriteRenderer renderer;

        float lastFrameTime = 0f;

        public List<Sprite> frames;

        public delegate void HairGrowthCompleteDelegate(HairTypes hairType);
        public HairGrowthCompleteDelegate hairGrowthCompleteCallback;

        void Start()
        {
            renderer = GetComponent<SpriteRenderer>();

            progressBar.maxValue = lastFrame;
        }

        void Update()
        {
            if (!started
                && Time.time >= timeBeforeStart)
            {
                StartGrowing();
            }

            if (started
                && currentFrame < lastFrame
                && Time.time - lastFrameTime >= secondsPerFrame)
            {
                NextFrame();
            }
        }

        void StartGrowing()
        {
            progressBar.gameObject.SetActive(true);

            lastFrameTime = Time.time;

            started = true;
        }

        void NextFrame()
        {
            lastFrameTime = Time.time;
            currentFrame++;

            if (currentFrame >= lastFrame)
            {
                hairGrowthCompleteCallback(hairType);
            }
        }
    }
}