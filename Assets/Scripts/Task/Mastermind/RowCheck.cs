using UnityEngine;

namespace Task.Mastermind
{
    public class RowCheck : MonoBehaviour
    {
        
        public GameObject master;
        [Header("Sprites")]
        public Sprite black;
        public Sprite white;
        
        private int[] _expectedSolution = new int[4];
        public int _correctColors = 0;
        public int _correctPosition = 0;
        private bool _wasChecked;
        
        void OnEnable()
        {
            _correctColors = 0;
            _correctPosition = 0;
            _wasChecked = false;
            _expectedSolution = master.GetComponent<global::Task.Mastermind.Mastermind>().expectedValue;
            for (int i = 0; i < transform.childCount-1; i++)
            {
                transform.GetChild(i).GetComponent<Collider2D>().enabled = true;
            }
            DrawSolutionSocket();
        }

        // Update is called once per frame
        void Update()
        {
            if (IsFull() && !_wasChecked)
            {
                _expectedSolution = master.GetComponent<global::Task.Mastermind.Mastermind>().expectedValue;
                _wasChecked = true;
                CheckColors();
                DrawSolutionSocket();
                if (_correctPosition == 4)
                {
                    master.GetComponent<global::Task.Mastermind.Mastermind>().HandleCompletion();
                }
                else
                {
                    DisplayNextRow();
                }
            }
        }
        /**
         * <summary>Detects the next inactive Row to set it Active</summary>
         */
        public void DisplayNextRow()
        {
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (!transform.parent.GetChild(i).gameObject.activeSelf)
                {
                    transform.parent.GetChild(i).gameObject.SetActive(true);
                    break;
                }
            }
        }
        /**
         * <summary>Checks if every Spot in the Row is filled</summary>
         */
        private bool IsFull()
        {
            bool b = true;
            for (int i = 0; i < transform.childCount-1; i++)
            {
                if (transform.GetChild(i).transform.childCount < 1)
                {
                    b = false;
                }
            }
            return b;
        }
        // ReSharper disable Unity.PerformanceAnalysis
        /**
         * <summary>Calls the 2 methods to check Position and colors</summary>
         */
        private void CheckColors()
        {
            CountCorrectColors();
            CountCorrectPositions();
        }

        private void CountCorrectColors()
        {
            int[] hitPositions = {-1,-1,-1,-1};
            
            for (int i = 0; i < transform.childCount-1; i++) 
            {
                int colorID = transform.GetChild(i).transform.GetChild(0).GetComponent<LampAttributes>().colorID;
                for (int j = 0; j < _expectedSolution.Length; j++)
                {
                    if (colorID == _expectedSolution[j] && !alreadyCounted(hitPositions,j))
                    {
                        hitPositions[i] = j;
                        _correctColors++;
                        break;
                    }
                }
            }
        }
        private void CountCorrectPositions()
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                int colorID = transform.GetChild(i).transform.GetChild(0).GetComponent<LampAttributes>().colorID;
                if (colorID == _expectedSolution[i])
                {
                    _correctPosition++;
                }
            }
        }
        /**
         * <summary>Checks if a Lamp has already been counted, so it won't count it multiple Times</summary>
         */
        private bool alreadyCounted(int[] hP, int pos)
        {
            foreach (int n in hP)
            {
                if (n == pos) return true;
            }
            return false;
        }
        /**
         * <summary>Displays the correct Sprites for the amounts of <c>_correctPosition</c> and <c>_correctColors</c></summary>
         */
        private void DrawSolutionSocket()
        {
            int corPos = _correctPosition;
            int corCol = _correctColors;
            for (int i = 0; i < 4; i++)
            {
                SpriteRenderer sR = transform.Find("SolutionSocket").GetChild(i).GetComponent<SpriteRenderer>();
                if (corPos != 0)
                {
                    sR.enabled = true;
                    sR.sprite = black;
                    corPos--;
                    corCol--;
                }
                else if(corCol != 0)
                {
                    sR.enabled = true;
                    sR.sprite = white;
                    corCol--;
                }
                else
                {
                    sR.enabled = false;
                }
            }
        }
    }
}
