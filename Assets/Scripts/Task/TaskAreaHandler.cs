using GameEngine;
using UnityEngine;

namespace Task
{
    public class TaskAreaHandler : MonoBehaviour
    {
        private bool _toggleEsc;
        private bool _taskArea;
        public GameObject gameHandler;
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape) && !_toggleEsc && _taskArea)
            {
                ToggleTaskArea();
                gameHandler.GetComponent<GameHandler>().SelectActiveCamera(0);
            
            }
            else if(Input.GetKeyUp(KeyCode.Escape) && _toggleEsc && _taskArea)
            {
                _toggleEsc = false;
            }

        }

        public void ToggleTaskArea()
        {
            _taskArea = !_taskArea;
        }

        public bool isTaskArea()
        {
            return _taskArea;
        }
    }
}
