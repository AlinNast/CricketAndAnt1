using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles coin behavior when player interacts with it
/// </summary>
public class coinCtrl : MonoBehaviour
{
    public enum CoinFx
    {
        Vanish,
        Fly
    }

    public CoinFx coinFx;
    public float speed;
    public bool isFlying;

    GameObject coinMeter;

    private void Start()
    {
        isFlying = false;

        if(coinFx == CoinFx.Fly)
        {
            coinMeter = GameObject.Find("ImgCoinCount");
        }
    }

    private void Update()
    {
        if (isFlying)
        {
            transform.position = Vector3.Lerp(transform.position, coinMeter.transform.position, speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(coinFx == CoinFx.Vanish)
                Destroy(gameObject);
            else if(coinFx == CoinFx.Fly)
            {
                isFlying = true;

                gameObject.layer = 0;
            }
        }
    }
}
