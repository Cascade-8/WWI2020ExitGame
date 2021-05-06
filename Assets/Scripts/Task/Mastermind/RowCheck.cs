using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace Task.Mastermind
{
    public class RowCheck : MonoBehaviour
    {

        public bool _isFull = false;
        public bool isCorrect = false;
        public GameObject master;
        public int[] expectedSolution = new int[4];
        public int correctColors = 0;
        public int correctPosition = 0;
        public Sprite black;
        public Sprite white;

        private bool _wasChecked = false;
        // Start is called before the first frame update
        void Start()
        {
            expectedSolution = master.GetComponent<global::Mastermind>().expectedValue;
            drawSolutionSocket();
        }

        // Update is called once per frame
        void Update()
        {
            if (isFull() && !_wasChecked)
            {
                _wasChecked = true;
                checkColors();
                drawSolutionSocket();
                if (correctPosition == 4)
                {
                    master.GetComponent<global::Mastermind>().handleCompletion();
                }
                else
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
                
            }
            
        }
        bool isFull()
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
        void checkColors() {
            int[] hitPositions = {-1,-1,-1,-1};
            for (int i = 0; i < transform.childCount-1; i++) 
            {
                int colorID = transform.GetChild(i).transform.GetChild(0).GetComponent<LampAttributes>().colorID;
                string colorName = transform.GetChild(i).transform.GetChild(0).GetComponent<LampAttributes>().colorName;
                for (int j = 0; j < expectedSolution.Length; j++)
                {
                    Debug.Log("Comparing ColorID:"+colorID+" with Solution:"+expectedSolution[j]+" at i: "+i+" and j:"+j+" where alreadyCounted is:"+alreadyCounted(hitPositions,j));
                    if (colorID == expectedSolution[j] && !alreadyCounted(hitPositions,j))
                    {
                        hitPositions[i] = j;
                        Debug.Log("Found Hit:"+colorID+" --> "+colorName);
                        correctColors++;
                        if (i == j)
                        {
                            correctPosition++;
                        }
                        break;
                    }
                }
            }
        }
        bool alreadyCounted(int[] hP, int pos)
        {
            foreach (int n in hP)
            {
                if (n == pos)
                {
                    return true;
                }
            }

            return false;
        }
        void drawSolutionSocket()
        {
            int corPos = correctPosition;
            int corCol = correctColors;
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
                else if(corPos == 0 && corCol != 0)
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
