using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour
{
    public static AudioCtrl Instance;

    public bool soundOn;
    public bool bgMusicOn;
    public GameObject bgMusic;
    public PlayerAudio playerAudio;
    public AudioFx audioFx;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        if (bgMusicOn)
        {
            bgMusic.SetActive(true);
        }
    }

    public void PlayerJump(Vector3 playerPos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.playerJump, playerPos);
        }
    }

    public void BreakCrate(Vector3 playerPos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.breakCrate, playerPos);
        }
    }

    public void Splash(Vector3 playerPos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(playerAudio.splash, playerPos);
        }
    }
}
