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
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            get => character.GetComponent<CharacterHandler>().GETScore();
        }
        private int Tasks
        {
            get => character.GetComponent<CharacterHandler>().GETTasks();
        }
        private void FixedUpdate()
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            DrawOverlay();
        }
        public void DrawOverlay()
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            completedTasks.text = character.GetComponent<CharacterHandler>().GETTasks()+"   6";
            scoreText.text = Score.ToString("D3");
        }
    
    }
}
