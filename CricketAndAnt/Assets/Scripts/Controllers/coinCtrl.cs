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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(coinFx == CoinFx.Vanish)
                Destroy(gameObject);
        }
    }
}
