using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public string horizontalKey = "Horizontal1";
    public string jumpKey = "Jump1";
    public string interactKey = "Interact1";


    public float runSpeed = 30f;
    public float horizontalMove = 0f;

    bool handsTaken = false;
    bool jump = false;
    bool interact = false;

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

        if (Input.GetButtonDown(interactKey))
        {
            Debug.Log("interact on");
            interact = true;
        }

        if (Input.GetButtonUp(interactKey))
        {
            Debug.Log("interact off");
            interact = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (interact)
        {
            GameObject go = collision.gameObject;
            Debug.Log("yeee 1");
            Debug.Log(collision.tag);
            switch (collision.tag)
            {
                case "item1": //On ramasse l'item 1
                case "item2": //On ramasse l'item 2
                case "item3": //On ramasse l'item 3
                    if (!handsTaken)
                    {
                        Debug.Log(go);
                        Debug.Log(gameObject);
                        Debug.Log(gameObject.transform);
                        go.transform.SetParent(gameObject.transform);
                        Debug.Log(go);
                        handsTaken = true;
                        go.SetActive(false);
                    }
                    break;
                case "pattern": //On range dans un pattern
                    if (handsTaken)
                    {
                        foreach(Transform child in gameObject.transform)
                        {
                            if (child.tag.Contains("item"))
                            {
                                go.GetComponent<Pattern>().addItem(child.tag);
                                Destroy(child.gameObject);
                            }
                        }
                    }
                    break;
                default: break;
            }
        }
    }
}
