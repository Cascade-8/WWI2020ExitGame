using Scripts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterMoving : MonoBehaviour
{
    [Header("Character")]
    public Camera mainCamera;
    public Rigidbody2D rb;
    public float walkingSpeed = 5f;
    private Vector2 _movement;

    [Header("Animations")]
    public Animator characterAnimator;
    private bool _facingRight = true;
    private Transform CameraPos
    {
        get => mainCamera.transform;
    }
    private Vector2 CharacterPos
    {
        get => rb.position;
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
    }
    private void FixedUpdate()
    {
        rb.MovePosition(CharacterPos + _movement * (walkingSpeed * Time.deltaTime));
        CameraPos.position = new Vector3(CharacterPos.x, CharacterPos.y, CameraPos.position.z);
    }
}