using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonCtrl : MonoBehaviour
{
    int levelNumber;
    Button btn;
    Image btnImage;
    Text btnText;
    Transform star;

    public Sprite lockedBtn;
    public Sprite unlockedBtn;
    // Start is called before the first frame update
    void Start()
    {
        levelNumber = int.Parse(transform.gameObject.name);

        btn = GetComponent<Button>();
        btnImage = btn.GetComponent<Image>();
        btnText = btn.gameObject.transform.GetChild(0).GetComponent<Text>();

        star = btn.gameObject.transform.GetChild(1);

        ButtonStatus();
    }

    public void StartLevel(int lvlIndex)
    {
        if(DataController.instance.IsUnlocked(levelNumber - 1))
        {
            SceneManager.LoadScene(lvlIndex);

        }
    }

    void ButtonStatus()
    {
        bool unlocked = DataController.instance.IsUnlocked(levelNumber-1);
        bool hasStar = DataController.instance.HasStar(levelNumber-1);

        if (unlocked)
        {
            if (hasStar)
            {
                star.gameObject.SetActive(true);
            }
            else
            {
                star.gameObject.SetActive(false);
            }
        }
        else
        {
            btnImage.overrideSprite = lockedBtn;
            star.gameObject.SetActive(false);
        }
    }
}
