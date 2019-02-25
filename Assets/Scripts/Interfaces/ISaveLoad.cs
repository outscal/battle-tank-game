using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveLoad
{
    void SetInt(string dataID, int value);
    int GetInt(string dataID);

    void SetString(string dataID, string value);
    string GetString(string dataID);

    void SetBool(string dataID, bool value);
    bool GetBool(string dataID);

    void SaveAll();

}
