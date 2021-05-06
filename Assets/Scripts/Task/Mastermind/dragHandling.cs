using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Task.Mastermind
{
    public class dragHandling : MonoBehaviour
    {
        private Vector3 _startposition;
        public void OnMouseDown()
        {
            _startposition = transform.position;
        }
        public void OnMouseDrag()
        {
            var mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseInWorld.x, mouseInWorld.y, 1);
        }
        public void OnMouseUp()
        {
            transform.position = _startposition;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(other.transform.name);
        }
    }
}
