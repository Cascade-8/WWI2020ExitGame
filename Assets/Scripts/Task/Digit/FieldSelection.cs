using UnityEngine;
using UnityEngine.UI;

namespace Task.Digit
{
    public class FieldSelection : MonoBehaviour
    {
    
        // Update is called once per frame
    
        public int selector;
        public InputField[] inputFields = new InputField[4];
        private bool _toggleButton;

        void Update()
        {
            if (Input.GetKey(KeyCode.Tab) && !_toggleButton)
            {
                _toggleButton = true;
                if (selector < 3)
                {
                    inputFields[++selector].ActivateInputField();
                }
                else
                {
                    selector = 0;
                    inputFields[selector].ActivateInputField();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Tab) && _toggleButton)
            {
                _toggleButton = false;
            }
        }
    }
}
