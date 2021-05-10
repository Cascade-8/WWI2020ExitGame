using UnityEngine;

namespace Task.Mastermind
{
    
    public class DragHandling : MonoBehaviour
    {
        private bool _isSnapped = false;
        private Vector3 _startposition;
        private Collider2D _hitCollider;
        private void OnMouseDown()
        {
            _startposition = transform.position;
            transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        private void OnMouseDrag()
        {
            if (_isSnapped) return;
            if (Camera.main is null) return;
            var mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mouseInWorld.x, mouseInWorld.y);
        }
        private void OnMouseUp()
        {
            if (!_isSnapped)
            {
                transform.position = _startposition;
                transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            else
            {
                var transform1 = transform;
                GameObject g = Instantiate(transform1.gameObject, transform1.parent, true);
                g.transform.position = _startposition;
                g.transform.localScale = new Vector3(50, 50, 0);
                g.transform.name = transform.name;
                transform.GetComponent<Collider2D>().enabled = false;
                transform.GetComponent<DragHandling>().enabled = false;
                _hitCollider.GetComponent<Collider2D>().enabled = false;
                transform.SetParent(_hitCollider.transform);
            }
        }
        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.transform.parent.name == "Lamps") return;
            _hitCollider = other.collider;
            _isSnapped = true;
            transform.position = other.transform.position;
        }
    }
}
