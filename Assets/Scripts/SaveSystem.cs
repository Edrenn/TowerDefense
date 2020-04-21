using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts;
using System.Collections.Generic;

public static class SaveSystem
{
    public static void SaveGeneric<T>(T objectToSave, string key)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/"+ key;
        FileStream fileStream = new FileStream(path, FileMode.Create);
        binaryFormatter.Serialize(fileStream, objectToSave);
        fileStream.Close();
        Debug.Log("Saved " + key);
    }

    public static T LoadGeneric<T>(string key)
    {
        string path = Application.persistentDataPath + "/"+ key;
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            T returnValue = default(T);
            returnValue = (T)binaryFormatter.Deserialize(fileStream);


            fileStream.Close();
            return returnValue;
        }
        else
        {
            Debug.LogError("Can't find levels file");
            return default(T);
        }
    }
}
