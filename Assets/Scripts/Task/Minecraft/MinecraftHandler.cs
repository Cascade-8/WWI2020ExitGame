using Character;
using GameEngine;
using UnityEngine;
using UnityEngine.UI;

namespace Task.Minecraft
{
    public class MinecraftHandler : MonoBehaviour {

        
        public GameObject world;
        public Button submitButton;
        public InputField inputField;
        
        private const string ExpectedString = "187";
        private GameHandler _gameHandler;

        private void OnEnable()
        {
            _gameHandler = world.GetComponent<GameHandler>();
            submitButton.onClick.AddListener(HandleSubmitAction);
            transform.parent.Find("MinigameTitle").GetComponent<Text>().text = "Minecraft";
        }
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                gameObject.SetActive(false);
                submitButton.onClick.RemoveListener(HandleSubmitAction);
                _gameHandler.ToggleActiveArea();
            }
        }
        /**
         * <summary>Handles the Action when the Submit Button is pressed</summary>
         */
        private void HandleSubmitAction()
        {
            submitButton.GetComponent<ButtonHandler>().PlaySoundeffect(0);
            if (CompareUserInput())
            {
                gameObject.SetActive(false);
                var gameArea = world.transform.Find("GameArea");
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetTasks(1);
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetScore(187);
                gameArea.Find("TaskColliders/TaskCollider6").GetComponent<TaskColliderHandler>().ClearTask();
                world.GetComponent<GameHandler>().ToggleActiveArea();
            }
            else
            {
                submitButton.GetComponent<ButtonHandler>().PlaySoundeffect(1);
            }
        }
        /**
         * <summary>Compares the User input to the expected Solution</summary>
         */
        private bool CompareUserInput()
        {
            if (ExpectedString != inputField.transform.GetChild(1).GetComponent<Text>().text)
            {
                return false;
            }
            submitButton.onClick.RemoveListener(HandleSubmitAction);
            Destroy(gameObject);
            return true;
        }
    }
}
