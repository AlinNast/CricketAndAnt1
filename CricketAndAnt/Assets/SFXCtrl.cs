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

    public void ShowBoxBreak(Vector3 position)
    {
        Vector3 pos1 = position;
        pos1.x -= 0.3f;

        Vector3 pos2 = position;
        pos2.x += 0.3f;

        Vector3 pos3 = position;
        pos3.x -= 0.3f;
        pos3.y -= 0.3f;

        Vector3 pos4 = position;
        pos4.x += 0.3f;
        pos4.y += 0.3f;

        Instantiate(sfx.sfx_fragment1, pos1, Quaternion.identity);
        Instantiate(sfx.sfx_fragment2, pos2, Quaternion.identity);
        Instantiate(sfx.sfx_fragment3, pos3, Quaternion.identity);
        Instantiate(sfx.sfx_fragment4, pos4, Quaternion.identity);

        AudioCtrl.Instance.BreakCrate(pos1);
    }

    public void ShowWaterSplash(Vector3 position)
    {
        Instantiate(sfx.sfx_splash, position, Quaternion.identity);
    }
}
