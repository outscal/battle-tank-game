using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoad
{
    [System.Serializable]
    public struct PlayerData
    {
        public int GamesPlayed;
        public int EnemiesKilled;
        public int PlayerDeath;
        public int HighScore;
    }

    public class SaveLoadController : ISaveLoad
    {
        public virtual void SetInt(string dataString, int value)
        {
            Debug.Log("Saving Int Type");
        }

        public virtual int GetInt(string dataString)
        {
            Debug.Log("Return Int Type");
            return 0;
        }

        public virtual void SetBool(string dataString, bool value)
        {
            Debug.Log("Saving Bool Type");
        }

        public virtual bool GetBool(string dataString)
        {
            Debug.Log("Return bool Type");
            return false;
        }

        public virtual void SetString(string dataString, string value)
        {
            Debug.Log("Saving String Type");
        }

        public virtual string GetString(string dataString)
        {
            Debug.Log("Return string Type");
            return "Testing";
        }

        public virtual void SaveAll()
        {
            Debug.Log("Save All Data");
        }
    }
}