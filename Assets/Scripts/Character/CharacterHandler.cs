using GameEngine;
using Task;
using Task.Digit;
using UnityEngine;

namespace Character
{
    public class CharacterHandler : MonoBehaviour
    {
        private byte _completedTasks;
        private int _score;

        public int GETScore()
        {
            return _score;
        }
        public void SetScore(int s)
        {
            _score += s;
        }
        public byte GETTasks()
        {
            return _completedTasks;
        }
        public void SetTasks(byte t)
        {
            _completedTasks += t;
        }
    }
}
