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
}
