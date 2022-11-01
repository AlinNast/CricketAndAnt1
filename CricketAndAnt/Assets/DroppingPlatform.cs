using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    public float droppingDelay;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PlayerFeet"))
        {
            Invoke("StartDropping", droppingDelay);
        }
    }

    void StartDropping()
    {
        rb.isKinematic = false;
    }
}
