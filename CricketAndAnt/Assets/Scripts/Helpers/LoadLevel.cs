using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    /// <summary>
    /// The name of the scene to load
    /// </summary>
    public string SceneName;
    /// <summary>
    /// Loads Scene based on scene name (string)
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        //SceneManagement.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Next Level loading initialized");
        LoadScene(SceneName);

    }
}
