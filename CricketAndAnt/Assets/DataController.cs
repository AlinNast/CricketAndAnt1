using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController instance = null;

    public GameData gameData;
    private string dataFilePath;
    BinaryFormatter formatter;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        formatter = new BinaryFormatter();
        dataFilePath = Application.persistentDataPath + "/game.dat";
    }

    public void RefreshData()
    {
        if (File.Exists(dataFilePath))
        {
            
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);
            gameData = (GameData)formatter.Deserialize(fs);
            fs.Close();
        }
    }

    public void SaveData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        formatter.Serialize(fs, gameData);
        fs.Close();
    }

    public void SaveData(GameData gameData)
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        formatter.Serialize(fs, gameData);
        fs.Close();
    }


    public bool IsUnlocked(int lvlNumber)
    {
        return gameData.levelData[lvlNumber].isUnlocked;
    }

    public bool HasStar(int lvlNumber)
    {
        return gameData.levelData[lvlNumber].hasStar;
    }
    private void OnEnable()
    {
        CheckDb();
    }

    void CheckDb()
    {
        if (!File.Exists(dataFilePath))
        {
#if UNITY_ANDROID
            CopyDB();
#endif
        }
        else
        {
            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                string destinationFile = System.IO.Path.Combine(Application.streamingAssetsPath, "game.dat");
                File.Delete(destinationFile);
                File.Copy(dataFilePath, destinationFile);
            }
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                File.Delete(dataFilePath);
                CopyDB();
            }
            RefreshData();
        }

    }

    void CopyDB()
    {
        string srcFile = System.IO.Path.Combine(Application.streamingAssetsPath, "game.dat");
        WWW downloader = new WWW(srcFile);

        while (!downloader.isDone)
        {

        }

        File.WriteAllBytes(dataFilePath, downloader.bytes);
        RefreshData();
    }
}
