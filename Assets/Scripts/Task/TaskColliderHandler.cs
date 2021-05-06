using System;
using UnityEngine;

namespace Task
{
    public class TaskColliderHandler : MonoBehaviour
    {
        private bool _isActive;
        private GameObject _parent;
        public bool _isCleared;
        public GameObject Character;
        
        // Start is called before the first frame update
        void Start()
        {
            _parent = transform.parent.gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Space) && _isActive && name != "Door")
            {
                _parent.gameObject.GetComponent<TaskExecutionHandler>().ExecuteTask(name);
            }
        }
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (name != "DoorAreaAbove")
            {
                _isActive = true;
                _parent.GetComponent<TaskNotificationHandler>().SelectTaskMessage(name);
                _parent.GetComponent<TaskNotificationHandler>().SetCanvasActive(true);
                transform.Find("ScreenY").GetComponent<Renderer>().enabled = !_isCleared;
            }
            else {
                Character.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }
        private void OnTriggerExit2D(Collider2D coll)
        {
            _isActive = false;
            _parent.GetComponent<TaskNotificationHandler>().SetCanvasActive(false);
            if (name == "Door")
            {
                GetComponent<Animator>().SetBool("IsOpenTriggered", false);
                transform.Find("ScreenY").GetComponent<Renderer>().enabled = false;
            }
            else if (name == "DoorAreaAbove")
            {
                Character.GetComponent<SpriteRenderer>().sortingOrder = 5;
            }
            else
            {
                transform.Find("ScreenY").GetComponent<Renderer>().enabled = false;
            }
        }
        public void clearTask()
        {
            transform.Find("ScreenG").GetComponent<Renderer>().enabled = true;
            transform.GetComponent<BoxCollider2D>().enabled = false;
            _isCleared = true;
        }
    }
}
