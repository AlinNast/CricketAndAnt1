using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public bool soundOn;
    public bool bgMusicOn;
    //public GameObject bgMusic;
    public PlayerAudio playerAudio;
    public AudioFx audioFx;
    //public Transform player;

    public GameObject menuMusic;
    public GameObject levelMusic;


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        CheckSoundStatus();
    }

    private void CheckSoundStatus()
    {
        if (bgMusicOn)
        {
            menuMusic.SetActive(true);
            levelMusic.SetActive(false);
            //Debug.Log("this ckeck works");

        }
        else
        {
            menuMusic.SetActive(false);
            levelMusic.SetActive(false);
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

    public void PlayLevelTheme()
    {
        menuMusic.SetActive(false);
        levelMusic.SetActive(true);
    }

    public void PlayMenuTheme()
    {
        levelMusic.SetActive(false);
        menuMusic.SetActive(true);
    }

}
