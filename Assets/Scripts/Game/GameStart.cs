using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
    public class PlayerData
    {
        public int XP;
        public int highScore;
        public List<Weapon>weapons; 
    }
[Serializable]
    public struct PlayerDataStruct{
        public int XP;
        public int highScore;
        public List<Weapon>weapons; 
    }

public class GameStart : MonoBehaviour
{
    public Dictionary<string, PlayerData> testDictionary;
    public string[] testArray;
    public List<PlayerData> PlayerDataClass;
    public List<PlayerDataStruct> PlayerDataStruct;
}
