using System;
using Character;
using GameEngine;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Task.Arduino
{
    public class ArduinoTaskHandler : MonoBehaviour
    {
        public GameObject world;
        public Button submitButton;
        public InputField inputField;
        private GameHandler _gameHandler;
        private int _keystate = -1;

        private void OnEnable()
        {
            Random r = new Random();
            _keystate = r.Next(0, 9);
            transform.Find("EncoderValue").GetComponent<Text>().text = ""+_keystate;
            _gameHandler = world.GetComponent<GameHandler>();
            submitButton.onClick.AddListener(HandleSubmitAction);
            transform.parent.Find("MinigameTitle").GetComponent<Text>().text = "Arduino";
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
        // ReSharper disable Unity.PerformanceAnalysis
        private void HandleSubmitAction()
        {
            submitButton.GetComponent<ButtonHandler>().PlaySoundeffect(0);
            if (CompareUserInput())
            {
                gameObject.SetActive(false);
                var gameArea = world.transform.Find("GameArea");
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetTasks(1);
                gameArea.Find("Character").GetComponent<CharacterHandler>().SetScore(187);
                gameArea.Find("TaskColliders/TaskCollider2").GetComponent<TaskColliderHandler>().ClearTask();
                world.GetComponent<GameHandler>().ToggleActiveArea();
            }
        }
        private bool CompareUserInput()
        {
            if (GETSolution(_keystate).ToUpper() != inputField.transform.GetChild(1).GetComponent<Text>().text.ToUpper())
            {
                submitButton.GetComponent<ButtonHandler>().PlaySoundeffect(1);
                return false;
            }
            submitButton.onClick.RemoveListener(HandleSubmitAction);
            Destroy(gameObject);
            return true;
        }

        private string GETSolution(int i)
        {
            return i switch
            {
                0 => "PARMESAN",
                1 => "ZADIK",
                2 => "PHILIP",
                3 => "JULIAN",
                4 => "NICO",
                5 => "LENNARD",
                6 => "MORITZ",
                7 => "JUSTUS",
                8 => "AURELIUS",
                9 => "BIMAZUBUTE",
                _ => "PARMESAN"
            };
        }
    }
}