using GameEngine;
using UnityEngine;

namespace Task
{
    public class TaskExecutionHandler : MonoBehaviour
    {
        public GameObject world;
        
        // ReSharper disable Unity.PerformanceAnalysis
        /**
         * <summary>Changes the task to the Active Collider name <param name="task"></param></summary>
         */
        public void ExecuteTask(string task)
        {
            var gamehandler = world.GetComponent<GameHandler>();
            var taskscene = world.transform.Find("TaskArea/TaskScenes");
            gamehandler.ToggleActiveArea();
            switch (task)
            {
                case "TaskCollider1": taskscene.Find("BinaryDigit").gameObject.SetActive(true);
                    break;
                case "TaskCollider2": taskscene.Find("Arduino").gameObject.SetActive(true);
                    break;
                case "TaskCollider3": taskscene.Find("Mastermind").gameObject.SetActive(true);
                    break;
                case "TaskCollider4": taskscene.Find("IPAdress").gameObject.SetActive(true);
                    break;
                case "TaskCollider5": taskscene.Find("Website").gameObject.SetActive(true);
                    break;
                case "TaskCollider6": taskscene.Find("SkeletonTask3").gameObject.SetActive(true);
                    break;
                case "Door": 
                    break;
            
            }
        }
    }
}
