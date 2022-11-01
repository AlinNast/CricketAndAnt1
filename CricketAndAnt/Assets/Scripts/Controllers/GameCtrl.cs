using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameCtrl : MonoBehaviour
{
    public static GameCtrl instance;

    public float restartDelay;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    /// <summary>
    /// Respawns the player
    /// </summary>
    public void PlayerDied(GameObject player)
    {
        player.SetActive(false);
        Invoke("RestartLevel", restartDelay);
    }

    public void PlayerDrowned(GameObject player)
    {
        Invoke("RestartLevel", restartDelay);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Level_Intro");
    }
}
