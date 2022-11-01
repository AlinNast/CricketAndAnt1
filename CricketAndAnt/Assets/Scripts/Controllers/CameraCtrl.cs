using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// focuses camera on player
/// </summary>
public class CameraCtrl : MonoBehaviour
{
    public GameObject player;

    public Transform backGround;

   
    public float Yoffset;
    public float Xoffset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x + Xoffset, player.transform.position.y + Yoffset, -10);
        backGround.position = new Vector3(player.transform.position.x + Xoffset, player.transform.position.y + Yoffset, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float maxFall = -10;
        if (player.transform.position.y < maxFall)
        {
            transform.position = new Vector3(player.transform.position.x + Xoffset, -10, -10);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x + Xoffset, player.transform.position.y + Yoffset, -10);
        }
    }
}
