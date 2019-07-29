using UnityEngine;

namespace SaveLoad
{
    public class PlayerPrefController : SaveLoadController
    {
        public override void SetInt(string dataString, int value)
        {
            PlayerPrefs.SetInt(dataString, value);
        }

        public override int GetInt(string dataString)
        {
            return PlayerPrefs.GetInt(dataString);
        }

        public override void SetString(string dataString, string value)
        {
            PlayerPrefs.SetString(dataString, value);
        }

        public override string GetString(string dataString)
        {
            return PlayerPrefs.GetString(dataString);
        }

        public override void SetBool(string dataString, bool value)
        {
            int intVal = 0;
            if (value == true) intVal = 1;
            else intVal = 0;

            PlayerPrefs.SetInt(dataString, intVal);
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

        public override void SaveAll()
        {
            PlayerPrefs.Save();
        }
    }
}