using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCtrl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Breakable"))
        {
            SFXCtrl.Instance.ShowBoxBreak(collider.gameObject.transform.parent.transform.position);

            Destroy(collider.gameObject.transform.parent.gameObject);

            gameObject.transform.parent.transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
