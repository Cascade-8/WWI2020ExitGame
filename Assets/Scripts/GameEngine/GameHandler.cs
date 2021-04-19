using System;
using UnityEngine;

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

        private void Start()
        {
            worldCamera.SetActive(true);
            gameArea.SetActive(true);
            taskCamera.SetActive(false);
            taskArea.SetActive(false);
            //transform.Find("TaskArea/TaskScenes/BinaryDigitTask").gameObject.SetActive(false);
            
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
