using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class SerialDict<T,V> : Dictionary<T, V>, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<T> keyData = new List<T>();

    [SerializeField]
    private List<V> valueData = new List<V>();

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        this.Clear();
        for (int i = 0; i < this.keyData.Count && i < this.valueData.Count; i++)
        {
            this[this.keyData[i]] = this.valueData[i];
        }
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        this.keyData.Clear();
        this.valueData.Clear();

        foreach (var item in this)
        {
            this.keyData.Add(item.Key);
            this.valueData.Add(item.Value);
        }
    }
    public void OnGUI()
    {
        foreach (var kvp in this)
            GUILayout.Label("Key: " + kvp.Key + " value: " + kvp.Value);
    }
}

[Serializable] 
public class DictIntString : SerialDict<int, string> { }

[Serializable]
public class DictFloatString : SerialDict<float, string> { }
