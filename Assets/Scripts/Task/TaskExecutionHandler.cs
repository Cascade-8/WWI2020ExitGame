using GameEngine;
using UnityEngine;

namespace Task
{
    public class TaskExecutionHandler : MonoBehaviour
    {
        public GameObject world;
        
        public void ExecuteTask(string task)
        {
            var gamehandler = world.GetComponent<GameHandler>();
            var taskscene = world.transform.Find("TaskArea/TaskScenes");
            gamehandler.ToggleActiveArea();
            switch (task)
            {
                case "TaskCollider1": taskscene.Find("BinaryDigitTask").gameObject.SetActive(true);
                    break;
                case "TaskCollider2": taskscene.Find("SkeletonTask1").gameObject.SetActive(true);
                    break;
                case "TaskCollider3": taskscene.Find("SkeletonTask2").gameObject.SetActive(true);
                    break;
                case "TaskCollider4": taskscene.Find("IPAdress").gameObject.SetActive(true);
                    break;
                case "TaskCollider5": taskscene.Find("Website").gameObject.SetActive(true);
                    break;
                case "TaskCollider6": taskscene.Find("SkeletonTask3").gameObject.SetActive(true);
                    break;
            
            }
        }
    }
}
