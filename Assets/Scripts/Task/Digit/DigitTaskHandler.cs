using System;
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

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                gameObject.SetActive(false);
                _gameHandler.ToggleActiveArea();
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void CreateBinaryCode()
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int randomValue = random.Next(65, 90);
                expectedChars[i] = Convert.ToChar(randomValue);
                digitStrings[i] = Convert.ToString(randomValue, 2);
            }

            FormatDigits();
        }
        private void FormatDigits()
        {
            for (int i = 0; i < 4; i++)
            {
                char[] temp = digitStrings[i].ToCharArray();
                digitStrings[i] = temp[0]+"";
                for (int j = 1; j < 7; j++)
                {
                    digitStrings[i] = digitStrings[i] + "  " + temp[j];
                }
            }
            
            LoadStringsToArea();
        }
        private void LoadStringsToArea()
        {
            for (int i = 0; i < 4; i++)
            {
                digitAreas.transform.GetChild(i).GetComponent<Text>().text = digitStrings[i];
            }
        }

        private void HandleSubmitAction()
        {
            print("Klick");
            if (CompareUserInput())
            {
                gameObject.SetActive(false);
                var gameArea = world.transform.Find("GameArea");
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetTasks(1);
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetScore(187);
                gameArea.Find("TaskColliders/TaskCollider1").GetComponent<TaskColliderHandler>().clearTask();
                world.GetComponent<GameHandler>().ToggleActiveArea();
                
            }
        }

        private bool CompareUserInput()
        {
            int i = 0;
            foreach(char c in expectedChars)
            {
                if (c+"" != inputAreas.transform.GetChild(i++).GetChild(1).GetComponent<Text>().text.ToUpper())
                {
                    return false;
                }
            }
            submitButton.onClick.RemoveListener(HandleSubmitAction);
            Destroy(gameObject);
            return true;
        }
    }
}
