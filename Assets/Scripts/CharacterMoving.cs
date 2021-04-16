using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    public Camera mainCamera;
    public Rigidbody2D rb;
    public Animator characterAnimator;
    
    public float walkingSpeed = 5f;
    private Vector2 _movement;
    
    
    // Start is called before the first frame update
    void Start(){}
    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        characterAnimator.SetFloat("Horizontal", _movement.x);
        characterAnimator.SetFloat("Vertical", _movement.y);
        characterAnimator.SetFloat("Speed", _movement.sqrMagnitude);
    
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * walkingSpeed * Time.deltaTime);
        mainCamera.transform.position = new Vector3(rb.position.x, rb.position.y, mainCamera.transform.position.z);
    }
}