using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncFlip : NetworkBehaviour
{
    private bool m_FacingRight = false;
    private float move;

    private void Update()
    {
        if(!isLocalPlayer)
        {
            m_FacingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>().m_FacingRight;
            move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().horizontalMove * Time.deltaTime;
            if (move < 0 && m_FacingRight)
                Flip();
        }        
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}


