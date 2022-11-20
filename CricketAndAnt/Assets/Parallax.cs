using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject player;
    public float speed; // set this to 0.001

    float offSetX;

    Material material;
    PlayerCtrl playerCtrl;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        playerCtrl = player.GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerCtrl.isStuck)
        {
            offSetX += Input.GetAxisRaw("Horizontal") * speed;
            if(playerCtrl.leftPressed)
                offSetX += -speed;
            else if(playerCtrl.rightPressed)
                offSetX += speed;

            material.SetTextureOffset("_MainTex", new Vector2(offSetX, 0));
        }
        
    }
}
