using System.Collections;
using System.Collections.Generic;
using Character;
using GameEngine;
using Task;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
public class Mastermind : MonoBehaviour
{
    public GameObject world;
    // Start is called before the first frame update
    private GameHandler _gameHandler;
    public int[] expectedValue = {0,0,0,0};
    void Start()
    {
        _gameHandler = world.GetComponent<GameHandler>();
        transform.parent.Find("MinigameTitle").GetComponent<Text>().text = "Mastermind";
        expectedValue = generateValues();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            _gameHandler.ToggleActiveArea();
        }
        
    }

    public void handleCompletion()
    {
        gameObject.SetActive(false);
        var gameArea = world.transform.Find("GameArea");
        gameArea.Find("Character").GetComponent<CharacterHandler>().SetTasks(1);
        gameArea.Find("Character").GetComponent<CharacterHandler>().SetScore(187);
        Destroy(this.gameObject);
        gameArea.Find("TaskColliders/TaskCollider3").GetComponent<TaskColliderHandler>().clearTask();
        _gameHandler.ToggleActiveArea();
    }

    public int[] generateValues()
    {
        Random random = new Random();
        int[] t = new int[4];
        for (int i = 0; i < 4; i++)
        {
            t[i] = random.Next(0, 3);
        }
        return t;
    }
}
