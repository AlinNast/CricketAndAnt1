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
        HandleFirstBoot();
        UpdateHearts();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetData();
        }
    }

    /// <summary>
    /// Respawns the player
    /// </summary>
    public void PlayerDied(GameObject player)
    {
        player.SetActive(false);
        CheckLives();
        //Invoke("RestartLevel", restartDelay);
    }

    

    public void PlayerDrowned(GameObject player)
    {
        player.SetActive(false);

        CheckLives();
        //UpdateHearts();
        //Invoke("RestartLevel", restartDelay);
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


    void RestartLevel()
    {
        UpdateHearts();

        SceneManager.LoadScene("Level_Intro");
    }

    public void SaveData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public void LoadData()
    {
        if (File.Exists(dataFilePath))
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);
            data = (GameData)formatter.Deserialize(fs);
            ui.txtCoinCount.text = " x " + data.CoinCount;
            ui.txtScore.text = "Score: " + data.score;
            fs.Close();
        }

    }

    private void OnEnable()
    {
        Debug.Log("loaded");
        LoadData();
    }


    private void OnDisable()
    {
        Debug.Log("saved");
        SaveData();
    }

    void ResetData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);

        data.CoinCount = 0;
        ui.txtCoinCount.text = " x " + data.CoinCount;

        for (int i = 0; i <= 2; i++)
        {
            data.keyFound[i] = false;
        }
        data.score = 0;
        ui.txtScore.text = "Score: " + data.score;

        data.lives = 3;
        formatter.Serialize(fs, data);
        fs.Close();
        Debug.Log("data reset");
    }

    void HandleFirstBoot()
    {
        if (data.isFirstBoot)
        {
            data.lives = 3;

            data.CoinCount = 0;
            data.score = 0;

            data.keyFound[0] = false;
            data.keyFound[1] = false;
            data.keyFound[2] = false;

            data.isFirstBoot = false;
        }
        
    }

    void UpdateHearts()
    {
        if(data.lives == 3)
        {
            ui.Heart0.sprite = ui.FullHeart;
            ui.Heart1.sprite = ui.FullHeart;
            ui.Heart2.sprite = ui.FullHeart;
        }
        else if (data.lives == 2)
        {
            ui.Heart0.sprite = ui.EmptyHeart;
        }
        else if (data.lives == 1)
        {
            ui.Heart0.sprite = ui.EmptyHeart;
            ui.Heart1.sprite = ui.EmptyHeart;
        }
    }

    void CheckLives()
    {
        int updatedLives = data.lives;
        updatedLives -= 1;
        data.lives = updatedLives;

        UpdateHearts();
        if (data.lives == 0)
        {
            data.lives = 3;
            SaveData();
            Invoke("GameOver", restartDelay);
        }
        else
        {
            SaveData();
            Invoke("RestartLevel", restartDelay);
        }
    }

    void GameOver()
    {
        ui.PannelGameOver.SetActive(true);

    }
}
