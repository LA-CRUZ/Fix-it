using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Footsteps : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string inputsound;
    bool playerismoving;
    public float walkingspeed;

    void Update()
    {
        Debug.Log(Input.GetAxis("Horizontal2"));
        Debug.Log(Input.GetAxis("Horizontal1"));



        if ((Input.GetAxis("Horizontal2") >= 0.01f ||
            Input.GetAxis("Horizontal1") >= 0.01f ||
            Input.GetAxis("Horizontal2") <= -0.01f ||
            Input.GetAxis("Horizontal1") <= -0.01f))
        {
            //Debug.Log ("Player is moving");
            playerismoving = true;
        }
        else if (Input.GetAxis("Horizontal2") == 0 || Input.GetAxis("Horizontal1") == 0)
        {
            //Debug.Log ("Player is not moving");
            playerismoving = false;
        }
    }


    void CallFootsteps()
    {
        if (!(playerismoving != true))
        {
            //Debug.Log ("Player is moving");
            FMODUnity.RuntimeManager.PlayOneShot(inputsound);
        }
    }


    void Start()
    {
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }


    void OnDisable()
    {
        playerismoving = false;
    }
}