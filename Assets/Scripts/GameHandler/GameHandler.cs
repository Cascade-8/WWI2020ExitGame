using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    [Header("Entitys")]
    public GameObject character;

    [Header("Cameras")]
    public GameObject worldCamera;
    public GameObject taskCamera;

    [Header("Areas")] 
    public GameObject gameArea;
    public GameObject taskArea;
    
    public void SwapCameras()
    {
        if (worldCamera.activeInHierarchy)
        {
            worldCamera.SetActive(false);
            gameArea.SetActive(false);
            taskCamera.SetActive(true);
            taskArea.SetActive(true);
            
        }
        else
        {
            worldCamera.SetActive(true);
            gameArea.SetActive(true);
            taskCamera.SetActive(false);
            taskArea.SetActive(false);
        }
    }
}
