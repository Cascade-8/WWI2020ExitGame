using System;
using GameEngine;
using UnityEngine;

namespace Task
{
    public class TaskAreaHandler : MonoBehaviour
    {

        public GameObject world;
        private GameHandler _gameHandler;

        private void OnEnable()
        {
            _gameHandler = world.GetComponent<GameHandler>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                
                //_gameHandler.ToggleActiveArea();
            }
        }
    }
}
