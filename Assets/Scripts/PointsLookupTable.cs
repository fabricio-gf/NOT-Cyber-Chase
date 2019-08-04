using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsLookupTable : MonoBehaviour
{
    public static PointsLookupTable instance = null;

    public string[] keys;
    public int[] values;

    Dictionary<string, int> dictionary = new Dictionary<string, int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        LoadDictionary();
    }

    void LoadDictionary()
    {
        for (int i = 0; i < keys.Length; i++) {
            dictionary.Add(keys[i], values[i]);
        }
    }

    public int FetchPointValue(string key)
    {
        return dictionary[key];
    }
}
