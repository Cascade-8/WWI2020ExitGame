using UnityEngine;

namespace GameEngine
{
    public class GameHandler : MonoBehaviour
    {

        [Header("Entitys")]
        public GameObject character;

        [Header("Cameras")]
        public GameObject worldCamera;
        public GameObject taskCamera;

        [Header("Areas")] 
        public GameObject gameArea;
        public GameObject taskArea;
    
        public void SelectActiveCamera(int selector)
        {
            switch (selector)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:     worldCamera.SetActive(true);
                            gameArea.SetActive(true);
                            taskCamera.SetActive(false);
                            taskArea.SetActive(false);
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                default:    worldCamera.SetActive(false);
                            gameArea.SetActive(false);
                            taskCamera.SetActive(true);
                            taskArea.SetActive(true);
                            break;


            }
        }
    }
}
