using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

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


        // Start is called before the first frame update
        void Start()
        {
            tasks.GetComponent<TaskHandler>().HandleTaskScreen(-1);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Space) && _coll != null && _coll.name != "Door")
            {
                taskArea.GetComponent<TaskAreaHandler>().ToggleTaskArea();
                gameHandler.GetComponent<GameHandler>().SwapCameras();
            }
        }

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.name == "Door")
            {
                if (_completedTasks == 6)
                {
                    doorAnimator.SetBool("IsOpenTriggered", true);
                }
                else
                {
                    tasks.GetComponent<TaskHandler>().SelectTaskMessage(coll);
                }
            }
            else
            {
                _coll = coll;
                tasks.GetComponent<TaskHandler>().SelectTaskMessage(coll);
            }
        }

        private void OnTriggerExit2D(Collider2D coll)
        {
            if (coll.name == "Door")
            {
                doorAnimator.SetBool("IsOpenTriggered", false);
                tasks.GetComponent<TaskHandler>().HandleTaskScreen(-1);
            }
            else
            {
                _coll = null;
                tasks.GetComponent<TaskHandler>().HandleTaskScreen(-1);
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
