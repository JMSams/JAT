using UnityEngine;

namespace BJGames.JAT
{
    public class HairAnimator : MonoBehaviour
    {
        public int framesPerSecond = 2f;
        float secondsPerFrame { get { return 1f / framesPerSecond; } }
        
        public List <Sprite> frames;
        
        public int currentFrame { get; protected set; }
        int lastFrame { get { return frames.Length-1; } }
    }
}