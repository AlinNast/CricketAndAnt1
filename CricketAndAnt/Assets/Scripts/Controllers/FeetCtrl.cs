using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCtrl : MonoBehaviour
{
    public Transform dustParticlePosition;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {

            SFXCtrl.Instance.ShowLandingPoof(dustParticlePosition.position);
        }
    }
}
