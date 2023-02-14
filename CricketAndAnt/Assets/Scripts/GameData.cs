using System.Collections;
using System.Collections.Generic;
using System; // used to import "Serializable"
using UnityEngine;

[Serializable]
public class GameData
{
    
    public bool isFirstBoot;

    [Header("LevelData")]
    public List<LevelData> levelData;

    [Header("User Settings")]
    public bool musicOn, soundOn;
}
