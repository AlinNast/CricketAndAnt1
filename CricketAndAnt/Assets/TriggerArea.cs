using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerArea : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);

        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}


