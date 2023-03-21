using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public bool soundOn = true;
    public bool bgMusicOn = true;
    //public GameObject bgMusic;
    public PlayerAudio playerAudio;
    public AudioFx audioFx;
    //public Transform player;

    public GameObject menuMusic;
    public GameObject levelMusic;

    public GameObject Cri1;
    public GameObject Cri2;
    public GameObject Cri3;

    public GameObject Violin1;
    public GameObject Violin2;
    public GameObject Violin3;
    public GameObject Violin4;


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
        Cri1.SetActive(false);
        Cri2.SetActive(false);
        Cri3.SetActive(false);
        if (soundOn)
        {
            int randomCri = Random.Range(0, 2);
            switch (randomCri)
            {
                case 0:
                    Cri1.SetActive(true);
                    break;
                case 1:
                    Cri2.SetActive(true);
                    break;
                case 2:
                    Cri3.SetActive(true);
                    break;
                default:
                    break;
            }
        }
            
    }

    public void PlayRandomViolin(Vector3 playerPos)
    {
        //if (soundOn)
        //{
            Violin1.SetActive(false);
            Violin2.SetActive(false);
            Violin3.SetActive(false);
            Violin4.SetActive(false);

            int randomCri = Random.Range(0, 3);
            switch (randomCri)
            {
                
                case 0:
                    Violin1.SetActive(true);
                    break;
                case 1:
                    Violin2.SetActive(true);
                    break;
                case 2:
                    Violin3.SetActive(true);
                    break;
                case 3:
                    Violin4.SetActive(true);
                    break;
                default:
                    break;
            }
        //}
    }
}
