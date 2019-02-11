using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoad
{
    public class JsonController : SaveLoadController
    {
        string jsonData = "";

        public JsonController()
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