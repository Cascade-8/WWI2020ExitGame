using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Task.Mastermind
{
    
    public class DragHandling : MonoBehaviour
    {
        private bool _isSnapped = false;
        public Vector3 _startposition;
        private Collider2D _hitCollider;
        public void OnMouseDown()
        {
            _startposition = transform.position;
            transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        public void OnMouseDrag()
        {
            if (!_isSnapped)
            {
                var mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector2(mouseInWorld.x, mouseInWorld.y);
            }
        }
        public void OnMouseUp()
        {
            if (!_isSnapped)
            {
                transform.position = _startposition;
                transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            else
            {
                GameObject g = Instantiate(transform.gameObject);
                g.transform.SetParent(transform.parent);
                g.transform.position = _startposition;
                g.transform.localScale = new Vector3(50, 50, 0);
                g.transform.name = transform.name;
                Destroy(transform.GetComponent<Collider2D>());
                Destroy(transform.GetComponent<Rigidbody2D>());
                Destroy(transform.GetComponent<DragHandling>());
                Destroy(_hitCollider.GetComponent<Collider2D>());
                transform.SetParent(_hitCollider.transform);
            }
            
        }
        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.transform.parent.name != "Lamps")
            {
                _hitCollider = other.collider;
                _isSnapped = true;
                transform.position = other.transform.position;
            }
        }
    }
}
