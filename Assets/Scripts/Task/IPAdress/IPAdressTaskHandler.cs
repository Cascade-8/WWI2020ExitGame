using System;
using Character;
using GameEngine;
using UnityEngine;
using UnityEngine.UI;

namespace Task.IPAdress
{
    public class IPAdressTaskHandler : MonoBehaviour
    {
        [Header("Areas")]
        public GameObject inputAreas;
        public GameObject world;
    
        [Header("Buttons")] 
        public Button submitButton;
    
        private readonly byte[] _expectedValues = {141,031,111,222};
        private GameHandler _gameHandler;
        void OnEnable()
        {
            _gameHandler = world.GetComponent<GameHandler>();
            submitButton.onClick.AddListener(HandleSubmitAction);
            transform.parent.Find("MinigameTitle").GetComponent<Text>().text = "IP-Adressrätsel";
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                gameObject.SetActive(false);
                _gameHandler.ToggleActiveArea();
            }
        }
        /**
         * <summary>Handles the Action when the Submit Button is pressed</summary>
         */
        private void HandleSubmitAction()
        {
            if (CompareUserInput())
            {
                gameObject.SetActive(false);
                var gameArea = world.transform.Find("GameArea");
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetTasks(1);
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetScore(187);
                gameArea.Find("TaskColliders/TaskCollider4").GetComponent<TaskColliderHandler>().ClearTask();
                _gameHandler.ToggleActiveArea();
            }
        }
        /**
         * <summary>Compares the User input to the expected Solution</summary>
         */
        private bool CompareUserInput()
        {
            int i = 0;
            foreach(byte b in _expectedValues)
            {
                if (b != Byte.Parse(inputAreas.transform.GetChild(i++).GetChild(1).GetComponent<Text>().text)) {
                    return false;
                }
            }
            submitButton.onClick.RemoveListener(HandleSubmitAction);
            Destroy(this.gameObject);
            return true;
        }
    }
}
