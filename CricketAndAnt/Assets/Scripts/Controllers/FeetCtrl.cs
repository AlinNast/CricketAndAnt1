using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCtrl : MonoBehaviour
{
    public GameObject player;
    public PlayerCtrl playerCtrl;

    public Transform dustParticlePosition;

    private void Start()
    {
        playerCtrl = gameObject.transform.parent.GetComponent<PlayerCtrl>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {

            SFXCtrl.Instance.ShowLandingPoof(dustParticlePosition.position);

            playerCtrl.isJumping = false;
        }

        if (collider.gameObject.CompareTag("Platform"))
        {
            SFXCtrl.Instance.ShowLandingPoof(dustParticlePosition.position);

            playerCtrl.isJumping = false;

            player.transform.parent = collider.gameObject.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Platform"))
        {


            player.transform.parent = null;
        }
    }
}
