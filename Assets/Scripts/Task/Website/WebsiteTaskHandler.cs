using Character;
using GameEngine;
using UnityEngine;
using UnityEngine.UI;

namespace Task.Website
{
    public class WebsiteTaskHandler : MonoBehaviour
    {
        public GameObject world;
        public Button submitButton;
        public InputField inputField;
        
        private const string ExpectedString = "80085";
        private GameHandler _gameHandler;

        private void OnEnable()
        {
            _gameHandler = world.GetComponent<GameHandler>();
            submitButton.onClick.AddListener(HandleSubmitAction);
            transform.parent.Find("MinigameTitle").GetComponent<Text>().text = "Websiterätsel";
        }
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                gameObject.SetActive(false);
                _gameHandler.ToggleActiveArea();
            }
        }
        private void HandleSubmitAction()
        {
            if (CompareUserInput())
            {
                
                gameObject.SetActive(false);
                var gameArea = world.transform.Find("GameArea");
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetTasks(1);
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetScore(187);
                gameArea.Find("TaskColliders/TaskCollider5").GetComponent<TaskColliderHandler>().clearTask();
                world.GetComponent<GameHandler>().ToggleActiveArea();
            }
        }
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