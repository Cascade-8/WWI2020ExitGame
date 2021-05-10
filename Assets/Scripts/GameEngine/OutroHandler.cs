using System;
using UnityEngine;
using UnityEngine.Video;

namespace GameEngine
{
    public class OutroHandler : MonoBehaviour
    {
        public VideoPlayer outro;
        private void OnEnable()
        {
            outro.enabled = true;
            outro.loopPointReached += EndGame;
        }

        private void Start()
        {
            outro.loopPointReached += EndGame;
        }

        private void EndGame(VideoPlayer vp)
        {
            Application.Quit();
        }
    }
}
