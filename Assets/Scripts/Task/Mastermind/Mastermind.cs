using Character;
using GameEngine;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
namespace Task.Mastermind
{
    public class Mastermind : MonoBehaviour
    {
        public GameObject world;
        public GameObject sockets;
        private GameHandler _gameHandler;
    
        public int[] expectedValue = {0,0,0,0};
        private void OnEnable()
        {
            _gameHandler = world.GetComponent<GameHandler>();
            transform.parent.Find("MinigameTitle").GetComponent<Text>().text = "Mastermind";
            expectedValue = GenerateValues();
            sockets.transform.GetChild(0).GetComponent<RowCheck>().DisplayNextRow();
        }
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                CleanBoard();
                gameObject.SetActive(false);
                _gameHandler.ToggleActiveArea();
            }
        }
        // ReSharper disable Unity.PerformanceAnalysis
        /**
         * <summary>Method that handles the Completion of the Task</summary>
         */
        public void HandleCompletion()
        {
            gameObject.SetActive(false);
            var gameArea = world.transform.Find("GameArea");
            gameArea.Find("Character").GetComponent<CharacterHandler>().SetTasks(1);
            gameArea.Find("Character").GetComponent<CharacterHandler>().SetScore(187);
            Destroy(this.gameObject);
            gameArea.Find("TaskColliders/TaskCollider3").GetComponent<TaskColliderHandler>().ClearTask();
            _gameHandler.ToggleActiveArea();
        }
        /**
         * <summary>Generate the wanted Solution from Random Numbers</summary>
         */
        private int[] GenerateValues()
        {
            Random random = new Random();
            int[] t = new int[4];
            for (int i = 0; i < 4; i++)
            {
                t[i] = random.Next(0, 3);
            }
            return t;
        }
        /**
         * <summary>Removes the Lamps from the current Board</summary>
         */
        public void CleanBoard()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (sockets.transform.GetChild(i).GetChild(j).childCount > 0)
                    {
                        Destroy(sockets.transform.GetChild(i).GetChild(j).GetChild(0).gameObject); // Deletes Lamps from Sockets
                    }
                }
                sockets.transform.GetChild(i).gameObject.SetActive(false); // Changing Row to inactive
            }
        }
    }
}
