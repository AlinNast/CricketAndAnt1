using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// focuses camera on player
/// </summary>
public class CameraCtrl : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer playerSR;

    

   
    public float Yoffset;
    public float Xoffset;
    public float smoothOffset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x + Xoffset, player.transform.position.y + Yoffset, -10);
        playerSR = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        float maxFall = -10;
        if (player.transform.position.y < maxFall)
        {
            transform.position = new Vector3(player.transform.position.x + Xoffset, -10, -10);
        }
        else
        {
            if (playerSR.flipX)
            {
                tempPos = new Vector3(player.transform.position.x + Xoffset, player.transform.position.y + Yoffset, -10);
            }
            else
            {
                tempPos = new Vector3(player.transform.position.x - Xoffset, player.transform.position.y + Yoffset, -10);
            }
            transform.position = Vector3.Lerp(transform.position, tempPos, smoothOffset * Time.deltaTime);
        }
    }
}
