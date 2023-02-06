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

    public float restartDelay;

    public GameData data;

    public int coinValue;

    public UI ui;





    string dataFilePath;
    BinaryFormatter formatter;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        formatter = new BinaryFormatter();

        dataFilePath = Application.persistentDataPath + "/game.dat";

        Debug.Log(dataFilePath);
    }

    private void Start()
    {
        DataController.instance.RefreshData();
        data = DataController.instance.gameData;
        RefreshUI();

        ui.PannelGameOver.gameObject.SetActive(false);
        ui.PanhelLvlComplete.gameObject.SetActive(false);

    }

    private void Update()
    {
        
    }

    /// <summary>
    /// Respawns the player
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

        //CheckLives();
        //UpdateHearts();
        StartCoroutine(PauseBeforeReload());
    }

    public void UpdateCoinCount()
    {
        data.CoinCount++;

        ui.txtCoinCount.text = " x " + data.CoinCount;

        UpdateScoreCount(coinValue);
    }

    public void UpdateScoreCount(int value)
    {
        data.score += value;

        ui.txtScore.text = " Score: " + data.score;
    }

    public void BulletHitEnemy(Transform enemy)
    {
        Destroy(enemy.gameObject);
        UpdateScoreCount(49);
    }

    public void UpdateKeyCount(int KeyNum)
    {
        data.keyFound[KeyNum] = true;

        if (KeyNum == 0)
        {
            ui.Key0.sprite = ui.Key0Enabled;
        }
        else if (KeyNum == 1)
        {
            ui.Key1.sprite = ui.Key1Enabled;
        }
        else if (KeyNum == 2)
        {
            ui.Key2.sprite = ui.Key2Enabled;
        }
    }


    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

    public void RefreshUI()
    {
        
        ui.txtCoinCount.text = " x " + data.CoinCount;
        ui.txtScore.text = "Score: " + data.score;
        

    }

    private void OnEnable()
    {
        Debug.Log("loaded");
        RefreshUI();
    }


    private void OnDisable()
    {
        Debug.Log("saved");
        DataController.instance.SaveData(data);
    }
    

    void GameOver()
    {
        ui.PannelGameOver.SetActive(true);
        Debug.Log("Game Over");
    }

    public void LevelComplete()
    {
        ui.PanhelLvlComplete.SetActive(true);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
