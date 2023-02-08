using System.Collections;
using System.Collections.Generic;
using System; // used to import "Serializable"
using UnityEngine;

[Serializable]
public class GameData
{
    public int CoinCount; // track the nr of coins collected
    public int score;
    public bool[] keyFound;
    public int lives;
    public bool isFirstBoot;

    [Header("LevelData")]
    public List<LevelData> levelData;

    [Header("User Settings")]
    public bool musicOn, soundOn;
}
