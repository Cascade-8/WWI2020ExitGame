using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameEngine
{
    public class GameHandler : MonoBehaviour
    {
        [Header("Cameras")]
        public GameObject worldCamera;
        public GameObject taskCamera;

        [Header("Areas")] 
        public GameObject gameArea;
        public GameObject taskArea;

        [Header("Timer")]
        public Text timerText;

        private float _startTime;

        private void Start()
        {
            worldCamera.SetActive(true);
            gameArea.SetActive(true);
            taskCamera.SetActive(false);
            taskArea.SetActive(false);
            _startTime = Time.time;
        }

        private void Update()
        {
            var t = Time.time - _startTime;
            var minutes = ((int) t / 60).ToString("00");
            var seconds = ((int) t % 60).ToString("00");
            timerText.text = minutes+":"+seconds;
        }

        public void ToggleActiveArea()
        {
            worldCamera.SetActive(!worldCamera.activeSelf);
            taskCamera.SetActive(!taskCamera.activeSelf);
            gameArea.SetActive(!gameArea.activeSelf);
            taskArea.SetActive(!taskArea.activeSelf);
        }
    }
}
