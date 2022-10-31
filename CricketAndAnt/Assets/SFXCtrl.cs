using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Special effects
/// </summary>
public class SFXCtrl : MonoBehaviour
{
    public SFX sfx;

    public static SFXCtrl Instance { get; private set; } // singleton

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
    }

    /// <summary>
    /// Shows the coin sparkle effect
    /// </summary>
    public void ShowCoinSparkle(Vector3 position)
    {
        Instantiate(sfx.sfx_coin_pickup, position, Quaternion.identity);
    }

    public void ShowViolinSparckle(Vector3 position)
    {
        Instantiate(sfx.sfx_violin_pickup, position, Quaternion.identity);
    }

    public void ShowLandingPoof(Vector3 position)
    {
        Instantiate(sfx.sfx_player_lands, position, Quaternion.identity);
    }
}
