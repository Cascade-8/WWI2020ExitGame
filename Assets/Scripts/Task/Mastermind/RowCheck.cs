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
        private int _correctColors = 0;
        private int _correctPosition = 0;
        private bool _wasChecked;

        private void OnEnable()
        {
            _correctColors = 0;
            _correctPosition = 0;
            _wasChecked = false;
            _expectedSolution = master.GetComponent<Mastermind>().expectedValue;
            for (int i = 0; i < transform.childCount-1; i++)
            {
                transform.GetChild(i).GetComponent<Collider2D>().enabled = true;
            }
            DrawSolutionSocket();
        }

        // Update is called once per frame
        private void Update()
        {
            if (IsFull() && !_wasChecked)
            {
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                _expectedSolution = master.GetComponent<Mastermind>().expectedValue;
                _wasChecked = true;
                CheckColors();
                DrawSolutionSocket();
                if (_correctPosition == 4)
                {
                    // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                    master.GetComponent<Mastermind>().HandleCompletion();
                }
                else
                {
                    DisplayNextRow();
                }
            }
        }
        // ReSharper disable Unity.PerformanceAnalysis
        /**
         * <summary>Detects the next inactive Row to set it Active</summary>
         */
        public void DisplayNextRow()
        {
            bool lastRow = true;
            for (var i = 0; i < transform.parent.childCount; i++)
            {
                if (!transform.parent.GetChild(i).gameObject.activeSelf)
                {
                    lastRow = false;
                    transform.parent.GetChild(i).gameObject.SetActive(true);
                    break;
                }
            }
            if (lastRow)
            {
                master.GetComponent<Mastermind>().CleanBoard();
                DisplayNextRow();
            }
        }
        /**
         * <summary>Checks if every Spot in the Row is filled</summary>
         */
        private bool IsFull()
        {
            bool b = true;
            for (var i = 0; i < transform.childCount-1; i++)
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
        /**
         * <summary>Checks how many Colors are chosen correctly</summary>
         */
        private void CountCorrectColors()
        {
            int[] tempArray = {_expectedSolution[0],_expectedSolution[1],_expectedSolution[2],_expectedSolution[3]};
            for (var i = 0; i < transform.childCount - 1; i++)
            {
                var colorID = transform.GetChild(i).transform.GetChild(0).GetComponent<LampAttributes>().colorID;
                for (var j = 0; j < tempArray.Length; j++)
                {
                    if (colorID == tempArray[j])
                    {
                        tempArray[j] = -1;
                        _correctColors++;
                        break;
                    }
                }
            }
        }
        /**
         * <summary>Checks how many Colors are at the correct position</summary>
         */
        private void CountCorrectPositions()
        {
            for (var i = 0; i < transform.childCount - 1; i++)
            {
                var colorID = transform.GetChild(i).transform.GetChild(0).GetComponent<LampAttributes>().colorID;
                if (colorID == _expectedSolution[i])
                {
                    _correctPosition++;
                }
            }
        }
        // ReSharper disable Unity.PerformanceAnalysis
        /**
         * <summary>Displays the correct Sprites for the amounts of <c>_correctPosition</c> and <c>_correctColors</c></summary>
         */
        private void DrawSolutionSocket()
        {
            int corPos = _correctPosition;
            int corCol = _correctColors;
            for (int i = 0; i < 4; i++)
            {
                var sR = transform.Find("SolutionSocket").GetChild(i).GetComponent<SpriteRenderer>();
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
