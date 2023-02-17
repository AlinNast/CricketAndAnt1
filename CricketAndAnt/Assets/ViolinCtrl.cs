using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolinCtrl : MonoBehaviour
{
    public int KeyNr;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("took violin");

            Destroy(gameObject);
        }
        
    }
}
