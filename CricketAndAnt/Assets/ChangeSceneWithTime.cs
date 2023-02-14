using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithTime : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private int delaySeconds;
    // Start is called before the first frame update
    void Start()
    {
        ChangeSceneCountDown();
    }

    private void ChangeSceneCountDown()
    {

        StartCoroutine(Waiter());
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(sceneName);
    }
}
