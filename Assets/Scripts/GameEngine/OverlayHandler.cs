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

        private int Score
        {
            get => character.GetComponent<CharacterHandler>().getScore();
        }
        private int Tasks
        {
            get => character.GetComponent<CharacterHandler>().getTasks();
        }
        private void FixedUpdate()
        {
            DrawOverlay();
        }
        public void DrawOverlay()
        {
            completedTasks.text = character.GetComponent<CharacterHandler>().getTasks()+"   6";
            scoreText.text = Score.ToString("D3");
        }
    
    }
}
