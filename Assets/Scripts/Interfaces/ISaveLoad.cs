using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveLoad
{
    void SetInt(string dataString, int value);
    int GetInt(string dataString);

    void SetString(string dataString, string value);
    string GetString(string dataString);

    void SetBool(string dataString, bool value);
    bool GetBool(string dataString);

    void SaveAll();

}
