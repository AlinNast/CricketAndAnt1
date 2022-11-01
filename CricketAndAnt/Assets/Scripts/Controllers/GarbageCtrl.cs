using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCtrl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GameCtrl.instance.PlayerDied(collider.gameObject);
        }
        else
        {
            Destroy(collider.gameObject);
        }
        
    }
}
