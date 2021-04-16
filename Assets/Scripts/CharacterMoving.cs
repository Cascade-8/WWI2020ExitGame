using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    public Camera mainCamera;
    public Rigidbody2D rb;
    public Animator characterAnimator;
    public Canvas interactionCanvas;
    
    public float walkingSpeed = 5f;
    private Vector2 _movement;
    private Collider2D _coll;
    private bool _spacePressed = false;

    // Start is called before the first frame update
    void Start()
    {
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
        mainCamera.transform.position = new Vector3(rb.position.x, rb.position.y, mainCamera.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        _coll = coll;
        interactionCanvas.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        _coll = null;
        interactionCanvas.enabled = false;
    }
}