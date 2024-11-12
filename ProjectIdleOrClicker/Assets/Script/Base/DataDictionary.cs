using System.Collections.Generic;
using UnityEngine;

public interface IDictionaryContentBase
{
    public int Id { get;}
}

public class DataDictionary<T> : MonoBehaviour where T : IDictionaryContentBase
{
    private string dictionaryName;
    private Dictionary<int, T> dict;

    public DataDictionary(string dictId, List<T> contents)
    {
        dict = new Dictionary<int, T>();

        foreach(T content in contents)
        {
            if (!AddDict(content))
                Debug.Log(content.Id);
        }

        dictionaryName = dictId;

    }

    public bool AddDict(T content)
    {
        if (dict.ContainsKey(content.Id)) return false;

        else
        {
            dict.Add(content.Id, content);
            return true;
        }
    }

    public bool GetDict(int key, out T content)
    {
        if (!dict.ContainsKey(key))
        {
            content = default(T);
            return false;
        }

        else
        {
            content = dict[key];
            return true;
        }
    }

    public void ClearDict()
    {
        dict.Clear();
    }
}
