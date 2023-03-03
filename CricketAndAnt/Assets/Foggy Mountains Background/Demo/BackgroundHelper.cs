using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundHelper : MonoBehaviour
{
    public GameObject player;
    public float speed = 0;
    float pos = 0;
    private RawImage image;
    private float playerPos;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
        playerPos = player.gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float currentPlayerPos = player.gameObject.transform.position.x;
        if (playerPos < currentPlayerPos)
        {
            pos += speed;
        }
        else if (playerPos > currentPlayerPos)
        {
            pos -= speed;
        }
        playerPos = currentPlayerPos;
        

        if (pos > 1.0F)

            pos -= 1.0F;

        image.uvRect = new Rect(pos, 0, 1, 1);
    }
}
