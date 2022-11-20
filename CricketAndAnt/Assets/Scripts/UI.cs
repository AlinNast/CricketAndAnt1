using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class UI
{
    [Header("Text")]
    public Text txtCoinCount;
    public Text txtScore;

    [Header("Keys")]
    public Image Key0;
    public Image Key1;
    public Image Key2;

    public Sprite Key0Enabled;
    public Sprite Key1Enabled;
    public Sprite Key2Enabled;

    [Header("Hearts")]
    public Image Heart0;
    public Image Heart1;
    public Image Heart2;

    public Sprite EmptyHeart;
    public Sprite FullHeart;

    public GameObject PannelGameOver;

}
