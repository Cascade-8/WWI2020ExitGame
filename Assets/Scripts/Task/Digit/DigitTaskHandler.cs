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
    
        [Header("Arrays")]
        public string[] digitStrings;
        public char[] expectedChars;

        [Header("Buttons")] 
        public Button submitButton;
        
        private void OnEnable()
        {
            submitButton.onClick.AddListener(HandleSubmitAction);
            digitStrings = new string[4];
            expectedChars = new char[4];
            CreateBinaryCode();
            transform.parent.Find("MinigameTitle").GetComponent<Text>().text = "Binärzahlenrätsel";
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
            GameObject world = transform.parent.transform.parent.transform.parent.gameObject;
            if (CompareUserInput())
            {
                gameObject.SetActive(false);
                world.transform.Find("GameArea/Character").GetComponent<CharacterHandler>().SetTasks(1);
                world.transform.Find("GameArea/Character").GetComponent<CharacterHandler>().SetScore(187);
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
            return true;
        }
    }
}
