using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 100f;
    float horizontalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // Value between -1 and 1 for a,d,arrows, controller
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log(Input.GetButtonDown("Jump"));
            jump = true;
        }
    }

    void FixedUpdate()
    {    
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }
}
