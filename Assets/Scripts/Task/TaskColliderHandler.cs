using UnityEngine;

namespace Task
{
    public class TaskColliderHandler : MonoBehaviour
    {
        private bool _isActive;
        private GameObject _parent;
        public bool _isCleared;
        
        // Start is called before the first frame update
        void Start()
        {
            _parent = transform.parent.gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Space) && _isActive)
            {
                _parent.gameObject.GetComponent<TaskExecutionHandler>().ExecuteTask(name);
            }
        }
        private void OnTriggerEnter2D(Collider2D coll)
        {
            _isActive = true;
            _parent.GetComponent<TaskNotificationHandler>().SelectTaskMessage(name);
            _parent.gameObject.GetComponent<TaskNotificationHandler>().SetCanvasActive(true);
            transform.Find(_isCleared? "ScreenG":"ScreenY").GetComponent<Renderer>().enabled = true;
        }
        private void OnTriggerExit2D(Collider2D coll)
        {
            _isActive = false;
            _parent.GetComponent<TaskNotificationHandler>().SetCanvasActive(false);
            transform.Find("ScreenG").GetComponent<Renderer>().enabled = false;
            transform.Find("ScreenY").GetComponent<Renderer>().enabled = false;
        }
    }
}
