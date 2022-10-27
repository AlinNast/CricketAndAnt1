using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Special effects
/// </summary>
public class SFXCtrl : MonoBehaviour
{
    public GameObject sfxCoinPickup;

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
        Instantiate(sfxCoinPickup, position, Quaternion.identity);
    }
}
