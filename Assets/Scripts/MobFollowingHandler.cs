using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobFollowingHandler : MonoBehaviour
{
    public GameObject supportedPlayer;
    public Sprite MobRight;
    public Sprite MobLeft;
    public Sprite MobCenter;

    public float viewDist = 5;

    private float myX;

    // Start is called before the first frame update
    void Start()
    {
        myX = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float myPlayerX = supportedPlayer.transform.position.x;
        if(myPlayerX <= myX - viewDist)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = MobLeft;
        } else if(myPlayerX >= myX + viewDist)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = MobRight;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = MobCenter;
        }

    }
}
