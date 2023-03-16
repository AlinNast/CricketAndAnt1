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

    public void MuteMusic()
    {
        levelMusic.SetActive(false);
        menuMusic.SetActive(false);
    }

    public void UnMuteMusic()
    {
        levelMusic.SetActive(true);
    }

    public void PlayRandomCri(Vector3 playerPos)
    {
        if (soundOn)
        {
            int randomCri = Random.Range(0, 2);
            switch (randomCri)
            {
                case 0:
                    AudioSource.PlayClipAtPoint(playerAudio.Cri1, playerPos);
                    break;
                case 1:
                    AudioSource.PlayClipAtPoint(playerAudio.Cri2, playerPos);
                    break;
                case 2:
                    AudioSource.PlayClipAtPoint(playerAudio.Cri3, playerPos);
                    break;
                default:
                    break;
            }
        }
            
    }

    public void PlayRandomViolin(Vector3 playerPos)
    {
        if (soundOn)
        {
            int randomCri = Random.Range(0, 3);
            Debug.Log("gets to swtich");
            switch (randomCri)
            {
                
                case 0:
                    AudioSource.PlayClipAtPoint(playerAudio.Violin1, playerPos, 0.1f);
                    Debug.Log("ends switch");
                    break;
                case 1:
                    AudioSource.PlayClipAtPoint(playerAudio.Violin2, playerPos,1f);
                    break;
                case 2:
                    AudioSource.PlayClipAtPoint(playerAudio.Violin3, playerPos,2.5f);
                    break;
                case 3:
                    AudioSource.PlayClipAtPoint(playerAudio.Violin4, playerPos, 10f);
                    break;
                default:
                    break;
            }
        }
    }
}
