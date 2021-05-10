using System;
using UnityEngine;

namespace Character
{
    public class CharacterHandler : MonoBehaviour
    {
        private byte _completedTasks;
        private int _score;

        private void Update()
        {
            /*  
            *   Cheats
            */
            if (Input.GetKey(KeyCode.F1))
            {
                _completedTasks = 6;
            }
        }

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
