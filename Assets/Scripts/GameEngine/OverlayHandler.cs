using Character;
using UnityEngine;
using UnityEngine.UI;

namespace GameEngine
{
    public class OverlayHandler : MonoBehaviour
    {
        [Header("Overlay")]
        public Text completedTasks;
        public Text scoreText;

        [Header("Character")]
        public GameObject character;
       
        private int Score => character.GetComponent<CharacterHandler>().GETScore();

        private int Tasks => character.GetComponent<CharacterHandler>().GETTasks();

        private void FixedUpdate()
        {
            DrawOverlay();
        }
        // ReSharper disable Unity.PerformanceAnalysis
        private void DrawOverlay()
        {
            completedTasks.text = character.GetComponent<CharacterHandler>().GETTasks()+"   6";
            scoreText.text = Score.ToString("D3");
        }
    
    }
}
