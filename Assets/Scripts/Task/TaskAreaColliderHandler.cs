using UnityEngine;

namespace Task
{
    public class TaskAreaTest : MonoBehaviour
    {
        public GameObject worldSpace;
        public GameObject executeThisTask;
        public Camera worldCamera;
        public Camera taskCamera;

        
    
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        private void OnTriggerEnter2D(Collider2D coll)
        {
            print(coll.name+" has entered "+this.name);
            
        }
        private void OnTriggerExit2D(Collider2D coll)
        {
            print(coll.name+" has exited "+this.name);
            
        }
    }
}
