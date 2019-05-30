using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace SaveLoad
{
    public class JsonController : SaveLoadController
    {
        private PlayerData playerData = new PlayerData();

        private string path = Application.streamingAssetsPath + "/Data.json";
        private string jsonString;

        public JsonController()
        {
            LoadData();
        }

        public void LoadData()
        {
            if (File.Exists(path) == false)
                File.CreateText(path);

            jsonString = File.ReadAllText(path);

            if (jsonString.Length == 0)
            {
                PlayerData _playerData = new PlayerData();
                _playerData.EnemiesKilled = 0;
                _playerData.GamesPlayed = 0;
                _playerData.HighScore = 0;
                _playerData.PlayerDeath = 0;

                File.WriteAllText(path, JsonUtility.ToJson(_playerData));
            }

            playerData = JsonUtility.FromJson<PlayerData>(jsonString);

            Debug.Log(playerData.ToString());
        }

        public void SaveData()
        {

        }


        public override void SetInt(string dataString, int value)
        {

        }

        public override int GetInt(string dataString)
        {

            return PlayerPrefs.GetInt(dataString);
        }

        public override void SetString(string dataString, string value)
        {

        }

        public override string GetString(string dataString)
        {
            return PlayerPrefs.GetString(dataString);
        }

        public override void SetBool(string dataString, bool value)
        {

        }

        public override bool GetBool(string dataString)
        {
            bool value = false;

            if (PlayerPrefs.GetInt(dataString) == 0)
                value = false;
            else if (PlayerPrefs.GetInt(dataString) == 1)
                value = true;

            return value;
        }
    }
}