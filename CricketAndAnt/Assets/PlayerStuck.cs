using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuck : MonoBehaviour
{
    public GameObject player;
    PlayerCtrl playerCtrl;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = player.GetComponent<PlayerCtrl>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        playerCtrl.isStuck = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        playerCtrl.isStuck = false;
    }
}
