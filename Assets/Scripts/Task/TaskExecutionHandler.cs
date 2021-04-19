using System.Collections;
using System.Collections.Generic;
using GameEngine;
using Unity.VisualScripting;
using UnityEngine;

public class TaskExecutionHandler : MonoBehaviour
{
    public GameObject world;
    public void ExecuteTask(string task)
    {
        switch (task)
        {
            case "TaskCollider1": world.GetComponent<GameHandler>().ToggleActiveArea();
                    
                break;
            case "TaskCollider2":   world.GetComponent<GameHandler>().ToggleActiveArea();
                                    world.transform.Find("TaskArea/TaskScenes/BinaryDigitTask").gameObject.SetActive(true);
                break;
            case "TaskCollider3": world.GetComponent<GameHandler>().ToggleActiveArea();
                break;
            case "TaskCollider4": world.GetComponent<GameHandler>().ToggleActiveArea();
                break;
            case "TaskCollider5": world.GetComponent<GameHandler>().ToggleActiveArea();
                break;
            case "TaskCollider6": world.GetComponent<GameHandler>().ToggleActiveArea();
                break;
            
        }
    }
}
