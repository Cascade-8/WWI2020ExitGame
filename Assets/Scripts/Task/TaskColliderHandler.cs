using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Task
{
    public class TaskColliderHandler : MonoBehaviour
    {
        public GameObject character;
        public Animator animator;
        private static readonly int IsOpenTriggered = Animator.StringToHash("IsOpenTriggered");
        private static readonly int FadeOut = Animator.StringToHash("FadeOut");
        
        private bool _isActive;
        private GameObject _parent;
        private bool _isCleared;

        // Start is called before the first frame update
        private void Start()
        {
            _parent = transform.parent.gameObject;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) && _isActive && name != "Door")
            {
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
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
                Invoke(nameof(StartFading),5);
                character.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }
        private void OnTriggerExit2D(Collider2D coll)
        {
            _isActive = false;
            _parent.GetComponent<TaskNotificationHandler>().SetCanvasActive(false);
            switch (name)
            {
                case "Door":
                    GetComponent<Animator>().SetBool(IsOpenTriggered, false);
                    transform.Find("ScreenY").GetComponent<Renderer>().enabled = false;
                    break;
                case "DoorAreaAbove":
                    character.GetComponent<SpriteRenderer>().sortingOrder = 5;
                    break;
                default:
                    transform.Find("ScreenY").GetComponent<Renderer>().enabled = false;
                    break;
            }
        }
        // ReSharper disable Unity.PerformanceAnalysis
        /**
         * <summary>Disables the current Task</summary>
         */
        public void ClearTask()
        {
            transform.Find("ScreenG").GetComponent<Renderer>().enabled = true;
            transform.GetComponent<BoxCollider2D>().enabled = false;
            _isCleared = true;
        }

        private void StartFading()
        {
            animator.SetTrigger(FadeOut);
        }
        
    }
}
