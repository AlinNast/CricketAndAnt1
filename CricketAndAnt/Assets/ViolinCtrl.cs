using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolinCtrl : MonoBehaviour
{
    


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
        
    }
}
