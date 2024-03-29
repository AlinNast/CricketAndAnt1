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

        CheckSoundStatus();
    }

    private void CheckSoundStatus()
    {
        if (DataController.instance.gameData.musicOn)
        {
            bgMusic.SetActive(true);
        }
        else
        {
            bgMusic.SetActive(false);
        }

        if (DataController.instance.gameData.soundOn)
        {
            soundOn = true;
        }
        else
        {
            soundOn = false;
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
