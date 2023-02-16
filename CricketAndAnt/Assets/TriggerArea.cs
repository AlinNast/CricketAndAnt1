using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerArea : MonoBehaviour
{
    public int currentLvlIndex;

    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (sceneName != null)
        {
            SaveLevel();
            SceneManager.LoadScene(sceneName);

        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    void SaveLevel()
    {
        DataController.instance.gameData.levelData[currentLvlIndex].hasStar = true;
        DataController.instance.gameData.levelData[currentLvlIndex + 1].isUnlocked = true;
        DataController.instance.SaveData();
    }
}


