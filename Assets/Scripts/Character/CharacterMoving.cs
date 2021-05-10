using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character
{
    public class CharacterMoving : MonoBehaviour
    {
        [Header("Character")] public Camera mainCamera;
        public Rigidbody2D rigidBody;
        public GameObject ear;
        public float walkingSpeed = 5f;
        private Vector2 _movement;

        [Header("Animations")] public Animator characterAnimator;
        private bool _facingRight = true;
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private bool _toggleF2;
        private bool _toggleF3;
        private bool _toggleF4;

        private Transform CameraPos => mainCamera.transform;
        private Vector2 CharacterPos => rigidBody.position;

        // Update is called once per frame
        private void Update()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");

            characterAnimator.SetFloat(Horizontal, _movement.x);
            characterAnimator.SetFloat(Vertical, _movement.y);
            characterAnimator.SetFloat(Speed, _movement.sqrMagnitude);

            if (_movement.x > 0 && !_facingRight || _movement.x < 0 && _facingRight)
            {
                _facingRight = !_facingRight;
                transform.rotation = Quaternion.Euler(0, _facingRight ? 0 : 180, 0);
            }
            /*
             * Cheats
             */
            if (Input.GetKeyDown(KeyCode.F2) && _toggleF2)
            {
                _toggleF2 = false;
                walkingSpeed -= 2;
            }
            else if (Input.GetKeyDown(KeyCode.F3) && _toggleF3)
            {
                _toggleF3 = false;
                walkingSpeed += 2;
            }
            else if (Input.GetKeyDown(KeyCode.F4) && _toggleF4)
            {
                _toggleF4 = false;
                walkingSpeed = -5f;
            }
            else if(Input.GetKeyUp(KeyCode.F2))
            {
                _toggleF2 = true;
            }
            else if (Input.GetKeyUp(KeyCode.F3))
            {
                _toggleF3 = true;
            }
            else if (Input.GetKeyUp(KeyCode.F4))
            {
                _toggleF4 = true;
            }
        }

        private void FixedUpdate()
        {
            rigidBody.MovePosition(CharacterPos + _movement * (walkingSpeed * Time.deltaTime));
            ear.transform.position = CharacterPos;
            CameraPos.position = new Vector3(CharacterPos.x, CharacterPos.y, CameraPos.position.z);
        }
    }
}