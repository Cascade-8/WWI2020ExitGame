using GameEngine;
using UnityEngine;

namespace Task
{
    public class TaskAreaHandler : MonoBehaviour
    {

        public GameObject world;
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                world.GetComponent<GameHandler>().ToggleActiveArea();
            }
        }
    }
}
