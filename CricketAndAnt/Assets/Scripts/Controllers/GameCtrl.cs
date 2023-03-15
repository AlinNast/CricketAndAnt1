using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;  // RSFB is used for serialization
using System.IO;
using TMPro;

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl instance;
    public GameData data;
    public UI ui;

    public float restartDelay;
    
    bool isPaused = false;
    string dataFilePath;
    BinaryFormatter formatter;


    private void Awake()
    {
        if (instance == null)
            instance = this;

        formatter = new BinaryFormatter();

        dataFilePath = Application.persistentDataPath + "/game.dat";
    }

    private void Start()
    {
        DataController.instance.RefreshData();
        data = DataController.instance.gameData;

        ui.PannelMobileUi.gameObject.SetActive(true);
        ui.PannelGameOver.gameObject.SetActive(false);
        ui.PanhelLvlComplete.gameObject.SetActive(false);
        ui.PannelPause.gameObject.SetActive(false);
    }


    /// <summary>
    /// Kills the player and shows Game Over pannel
    /// </summary>
    public void PlayerDied(GameObject player)
    {
        player.SetActive(false);

        StartCoroutine(PauseBeforeReload());
    }

    public void PlayerDiedAnimation(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-100f, 100f));

        player.transform.Rotate(new Vector3(0, 0, 30f));

        player.GetComponent<PlayerCtrl>().enabled = false;

        foreach(Collider2D collider2D in player.GetComponents<Collider2D>())
        {
            collider2D.enabled = false;
        }

        foreach(Transform child in player.transform)
        {
            child.gameObject.SetActive(false);
        }

        Camera.main.GetComponent<CameraCtrl>().enabled = false ;

        rb.velocity = Vector2.zero;

        //StartCoroutine("PauseBeforeReload", player);
        StartCoroutine(PauseBeforeReload());
    }

    IEnumerator PauseBeforeReload()
    {
        yield return new WaitForSeconds(1.5f);

        GameOver();
    }


    public void PlayerDrowned(GameObject player)
    {
        player.SetActive(false);

        StartCoroutine(PauseBeforeReload());
    }


    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void OnDisable()
    {
        DataController.instance.SaveData(data);
    }
    

    void GameOver()
    {
        ui.PannelMobileUi.SetActive(false);
        ui.PannelGameOver.SetActive(true);
    }

    public void LevelComplete()
    {
        ui.PannelMobileUi.SetActive(false);

        ui.PanhelLvlComplete.SetActive(true);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            //AdsCtrl.Instance.ShowBanner();
            ui.PannelPause.gameObject.SetActive(true );
            ui.PannelMobileUi.SetActive(false);

        }
        else
        {
            isPaused = false;
            //AdsCtrl.Instance.HideBanner();
            ui.PannelPause.gameObject.SetActive(false );
            ui.PannelMobileUi.SetActive(true);

        }
    }

    
    public void PlayLevelTheme()
    {
        AudioController.Instance.PlayLevelTheme();
    }

    public void PlayMenuTheme()
    {
        AudioController.Instance.PlayMenuTheme();
    }
   
    public void ToggleSound()
    {
        DataController.instance.gameData.soundOn = !DataController.instance.gameData.soundOn;
    }

    public void ToggleMusic()
    {
        DataController.instance.gameData.musicOn = !DataController.instance.gameData.musicOn;
        if (DataController.instance.gameData.musicOn)
        {
            AudioController.Instance.MuteMusic();
        }
        else
        {
            AudioController.Instance.UnMuteMusic();
        }
    }
}
