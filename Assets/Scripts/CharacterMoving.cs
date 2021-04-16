using UnityEngine;
using UnityEngine.UI;

public class CharacterMoving : MonoBehaviour
{
    [Header("Character")]
    public Camera mainCamera;
    public Rigidbody2D rb;
    public float walkingSpeed = 5f;
    public GameObject character;
    
    [Header("Animations")]
    public Animator characterAnimator;
    public Animator doorAnimator;
    
    [Header("InteractionCanvas")]
    public Canvas interactionCanvas;
    public Text interactionTitel;
    public Text interactionMessage;
    public Text interactionHint;
    
    [Header("Tasks")]
    public GameObject tasks;
    
    
    private Vector2 _movement;
    private Collider2D _coll;
    private bool _spacePressed = false;
    private bool _facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        interactionHint.enabled = false;
        interactionHint.text = "Use Spacebar to interact!";
        interactionHint.enabled = true;
        handleTaskScreen(-1);
        print(tasks.transform.GetChild(0).transform.GetChild(0).name);
        interactionCanvas.enabled = false;
        _coll = null;
    }
    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        characterAnimator.SetFloat("Horizontal", _movement.x);
        characterAnimator.SetFloat("Vertical", _movement.y);
        characterAnimator.SetFloat("Speed", _movement.sqrMagnitude);

        if (_movement.x > 0 && !_facingRight || _movement.x < 0 && _facingRight)
        {
            _facingRight = !_facingRight;
            transform.rotation = Quaternion.Euler(0, _facingRight ? 0 : 180, 0);
        }
        
        if (Input.GetKey(KeyCode.Space) && _coll != null && !_spacePressed)
        {
            _spacePressed = true;
            print("Interact with "+_coll.name);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _spacePressed = false;
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * walkingSpeed * Time.deltaTime);
        var rbPosition = rb.position;
        mainCamera.transform.position = new Vector3(rbPosition.x, rbPosition.y, mainCamera.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Door")
        {
            doorAnimator.SetBool("IsOpenTriggered", true);
        }
        else
        {
            _coll = coll;
            selectTaskMessage(coll);
            interactionCanvas.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.name == "Door")
        {
            doorAnimator.SetBool("IsOpenTriggered", false);
        }
        else
        {
            _coll = null;
            interactionTitel.text = "";
            interactionMessage.text = "";
            interactionCanvas.enabled = false;
            handleTaskScreen(-1);
        }
    }
    private void selectTaskMessage(Collider2D coll)
    {
        switch (coll.name)
        {
            case "TaskArea1": interactionTitel.text = "";
                handleTaskScreen(0);
                interactionMessage.text = "This is the text for Task 1!\nPlease execute the following task!";
                break;
            case "TaskArea2": interactionTitel.text = coll.name;
                handleTaskScreen(1);
                interactionMessage.text = "This is the text for Task 2!\nPlease execute the following task!";
                break;
            case "TaskArea3": interactionTitel.text = coll.name;
                handleTaskScreen(2);
                interactionMessage.text = "This is the text for Task 3!\nPlease execute the following task!";
                break;
            case "TaskArea4": interactionTitel.text = coll.name;
                handleTaskScreen(3);
                interactionMessage.text = "This is the text for Task 4!\nPlease execute the following task!";
                break;
            case "TaskArea5": interactionTitel.text = coll.name;
                handleTaskScreen(4);
                interactionMessage.text = "This is the text for Task 5!\nPlease execute the following task!";
                break;
            case "TaskArea6": interactionTitel.text = coll.name;
                handleTaskScreen(5);
                interactionMessage.text = "This is the text for Task 6!\nPlease execute the following task!";
                break;
        }
    }

    private void handleTaskScreen(int selector)
    {
        if (selector == -1)
        {
            tasks.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            tasks.transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            tasks.transform.GetChild(2).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            tasks.transform.GetChild(3).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            tasks.transform.GetChild(4).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            tasks.transform.GetChild(5).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
        else
        {
            tasks.transform.GetChild(selector).transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        }
    }
}