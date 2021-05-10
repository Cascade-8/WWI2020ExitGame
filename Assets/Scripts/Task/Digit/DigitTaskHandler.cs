using System;
using System.Linq;
using Character;
using GameEngine;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Task.Digit
{
    public class DigitTaskHandler : MonoBehaviour
    {
        [Header("Areas")]
        public GameObject digitAreas;
        public GameObject inputAreas;
        public GameObject world;
    
        [Header("Arrays")]
        public string[] digitStrings;
        public char[] expectedChars;

        [Header("Buttons")] 
        public Button submitButton;

        private GameHandler _gameHandler;
        
        private void OnEnable()
        {
            _gameHandler = world.GetComponent<GameHandler>();
            submitButton.onClick.AddListener(HandleSubmitAction);
            digitStrings = new string[4];
            expectedChars = new char[4];
            CreateBinaryCode();
            transform.parent.Find("MinigameTitle").GetComponent<Text>().text = "Binärzahlenrätsel";
        }
        // Update is called once per frame
        private void Update()
        {
            if (!Input.GetKey(KeyCode.Escape)) return;
            gameObject.SetActive(false);
            submitButton.onClick.RemoveListener(HandleSubmitAction);
            _gameHandler.ToggleActiveArea();
        }
        /**
         * <summary>Creates 4 Binary Codes based on the Decimal ASCII Values of the Upper Case Letters</summary>
         */
        private void CreateBinaryCode()
        {
            var random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int randomValue = random.Next(65, 90);
                expectedChars[i] = Convert.ToChar(randomValue);
                digitStrings[i] = Convert.ToString(randomValue, 2);
            }

            FormatDigits();
        }
        /**
         * <summary>Adding spaces between the numbers for aesthetic purposes</summary>
         */
        private void FormatDigits()
        {
            for (var i = 0; i < 4; i++)
            {
                var temp = digitStrings[i].ToCharArray();
                digitStrings[i] = temp[0]+"";
                for (var j = 1; j < 7; j++)
                {
                    digitStrings[i] = digitStrings[i] + "  " + temp[j];
                }
            }
            
            LoadStringsToArea();
        }
        /**
         * <summary>Displays the Strings into the Textobject</summary>
         */
        private void LoadStringsToArea()
        {
            for (var i = 0; i < 4; i++)
            {
                digitAreas.transform.GetChild(i).GetComponent<Text>().text = digitStrings[i];
            }
        }
        // ReSharper disable Unity.PerformanceAnalysis
        /**
         * <summary>Handles the Action when the Submit Button is pressed</summary>
         */
        private void HandleSubmitAction()
        {
            submitButton.GetComponent<ButtonHandler>().PlaySoundeffect(0);
            if (CompareUserInput())
            {
                submitButton.onClick.RemoveListener(HandleSubmitAction);
                Destroy(gameObject);
                var gameArea = world.transform.Find("GameArea");
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetTasks(1);
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetScore(187);
                gameArea.Find("TaskColliders/TaskCollider1").GetComponent<TaskColliderHandler>().ClearTask();
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
            var i = 0;
            return expectedChars.All(c => c + "" == inputAreas.transform.GetChild(i++).GetChild(1).GetComponent<Text>().text.ToUpper());
        }
    }
}
