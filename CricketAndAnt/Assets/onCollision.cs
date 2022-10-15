using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{
    public Collider2D coll;
    public GameObject itemToShow;

    // Use this for initialization
    void Start()
    {
        //Check if the isTrigger option on th Collider2D is set to true or false
        if (coll.isTrigger)
        {
            Debug.Log("This Collider2D can be triggered");
        }
        else if (!coll.isTrigger)
        {
            Debug.Log("This Collider2D cannot be triggered");
        }
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("its a match");
        itemToShow.transform.position = new Vector3(itemToShow.transform.position.x, itemToShow.transform.position.y, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
