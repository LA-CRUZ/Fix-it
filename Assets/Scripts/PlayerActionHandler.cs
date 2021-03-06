﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionHandler : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public string horizontalKey = "Horizontal1";
    public string jumpKey = "Jump1";
    public string interactKey = "Interact1";


    public float runSpeed = 30f;
    public float horizontalMove = 0f;

    [FMODUnity.EventRef]
    public string soundDrag;
    [FMODUnity.EventRef]
    public string soundDrop;

    bool handsTaken = false;
    bool jump = false;
    bool interact = false;

    public Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = gameObject.transform.position;
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

    public void reset()
    {
        //gameObject.transform = new Vector3(spawn.position.x, spawn.position.y, spawn.position.z);
        gameObject.transform.position = spawn;
        foreach (Transform child in gameObject.transform)
        {
            if (child.tag.Contains("item"))
            {
                Destroy(child.gameObject);
                handsTaken = false;
            }
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (interact)
        {
            GameObject go = collision.gameObject;
            switch (collision.tag)
            {
                case "item1": //On ramasse l'item 1
                case "item2": //On ramasse l'item 2
                case "item3": //On ramasse l'item 3
                    if (!handsTaken)
                    {
                        go.transform.SetParent(gameObject.transform);
                        handsTaken = true;
                        FMODUnity.RuntimeManager.PlayOneShot(soundDrag, gameObject.transform.position);

                        go.transform.position = gameObject.transform.position + new Vector3(0, 0.5f, 0);
                        go.GetComponent<Rigidbody2D>().isKinematic = true;
                        go.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                        foreach ( BoxCollider2D collider in go.GetComponents<BoxCollider2D>())
                        {
                            collider.enabled = false;
                        }
                    }
                    break;
                case "pattern": //On range dans un pattern
                    if(go.GetComponent<Pattern>().player1 && gameObject.name == "Player1" ||
                        go.GetComponent<Pattern>().player2 && gameObject.name == "Player2")
                    {
                        if (handsTaken)
                        {
                            foreach (Transform child in gameObject.transform)
                            {
                                if (child.tag.Contains("item"))
                                {
                                    print(child.tag);
                                    go.GetComponent<Pattern>().addItem(child.tag);
                                    Destroy(child.gameObject);
                                    FMODUnity.RuntimeManager.PlayOneShot(soundDrop, gameObject.transform.position);
                                    handsTaken = false;
                                }
                            }
                        }
                    }
                    break;
                default: break;
            }
        }
    }
}
