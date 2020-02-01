using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public string horizontalKey = "Horizontal1";
    public string jumpKey = "Jump1";


    public float runSpeed = 30f;
    public float horizontalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw(horizontalKey) * runSpeed; // Value between -1 and 1 for a,d,arrows, controller

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown(jumpKey))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate()
    {    
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
