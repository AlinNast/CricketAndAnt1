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
            GameCtrl.instance.UpdateKeyCount(KeyNr);

            Destroy(gameObject);
        }
        
    }
}
