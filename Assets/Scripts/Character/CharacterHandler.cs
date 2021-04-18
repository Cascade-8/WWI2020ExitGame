using GameEngine;
using Scripts;
using Task;
using Task.Digit;
using UnityEngine;

namespace Character
{
    public class CharacterHandler : MonoBehaviour
    {
        [Header("GameHandler")]
        public GameObject gameHandler;
        
        [Header("Animators")] 
        public Animator doorAnimator;

        [Header("UI Handlers")] 
        public GameObject tasks;
        public GameObject taskArea;

        private Collider2D _coll;
        private byte _completedTasks;
        private int _score;
        private static readonly int IsOpenTriggered = Animator.StringToHash("IsOpenTriggered");


        // Start is called before the first frame update
        void Start()
        {
            tasks.GetComponent<TaskNotificationHandler>().HandleTaskScreen(-1);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Space) && _coll != null && _coll.name != "Door")
            {
                taskArea.GetComponent<TaskAreaHandler>().ToggleTaskArea();
                taskArea.transform.GetChild(3).GetComponent<DigitTaskHandler>().CreateBinaryCode();
                gameHandler.GetComponent<GameHandler>().SelectActiveCamera(3);
            }
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.name == "Door")
            {
                if (_completedTasks == 6)
                {
                    doorAnimator.SetBool(IsOpenTriggered, true);
                }
                else
                {
                    tasks.GetComponent<TaskNotificationHandler>().SelectTaskMessage(coll);
                }
            }
            else
            {
                _coll = coll;
                tasks.GetComponent<TaskNotificationHandler>().SelectTaskMessage(coll);
            }
        }

        private void OnTriggerExit2D(Collider2D coll)
        {
            if (coll.name == "Door")
            {
                doorAnimator.SetBool(IsOpenTriggered, false);
                tasks.GetComponent<TaskNotificationHandler>().HandleTaskScreen(-1);
            }
            else
            {
                _coll = null;
                tasks.GetComponent<TaskNotificationHandler>().HandleTaskScreen(-1);
            }
        }

        public int getScore()
        {
            return _score;
        }

        public void setScore(int s)
        {
            _score = s;
        }
        public byte getTasks()
        {
            return _completedTasks;
        }

        public void setTasks(byte t)
        {
            _completedTasks = t;
        }
    }
}
