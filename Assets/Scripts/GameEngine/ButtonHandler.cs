using UnityEngine;
using UnityEngine.UI;

namespace GameEngine
{
    public class ButtonHandler : MonoBehaviour
    {
        [Header("Buttons")]
        public Button submitButton;

        private void Start()
        {
        
        }

        private void SubmitAction()
        {
            print("Submitted");
        }
    }
}
