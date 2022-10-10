using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes the camera follow the player
/// </summary>
public class CameraCtrl : MonoBehaviour
{
    public Transform player;

    public Transform background;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 3, transform.position.z);
        background.position = new Vector3(transform.position.x, transform.position.y, background.position.z);
    }
}
