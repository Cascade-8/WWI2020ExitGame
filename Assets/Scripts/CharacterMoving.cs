using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    public Camera mainCamera;
    public float walkingSpeed = 5f;
    private Vector2 movement;
    public Rigidbody2D rb;
    public Animator characterAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        characterAnimator.SetFloat("Horizontal", movement.x);
        characterAnimator.SetFloat("Vertical", movement.y);
        characterAnimator.SetFloat("Speed", movement.sqrMagnitude);
    
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * walkingSpeed * Time.deltaTime);
        mainCamera.transform.position = new Vector3(rb.position.x, rb.position.y, mainCamera.transform.position.z);
    }
}