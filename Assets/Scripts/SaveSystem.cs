using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts;

public static class SaveSystem
{
    public static void SaveGame(CoreGameData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.status";

        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {

            formatter.Serialize(fileStream, data);
        }
    }

    public static CoreGameData LoadGame()
    {
        string path = Application.persistentDataPath + "/game.status";
        if (File.Exists(path))
        {
            CoreGameData gameData = null;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            gameData = binaryFormatter.Deserialize(fileStream) as CoreGameData;
            fileStream.Close();
            return gameData;
        }
        else
        {
            Debug.LogError("Can't find towers file");
            CoreGameData gameData = new CoreGameData();
            SaveGame(gameData);

            return gameData;
        }
    }

    public static void SaveTower(Tower tower)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/tower.custom";

        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {

            TowerData td = new TowerData(tower);

            binaryFormatter.Serialize(fileStream, td);
        }
    }

    public static TowerData LoadTower()
    {
        string path = Application.persistentDataPath + "/tower.custom";
        if (File.Exists(path))
        {
            TowerData tower = null;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {

                tower = binaryFormatter.Deserialize(fileStream) as TowerData;
            }

            return tower;
        }
        else
        {
            Debug.LogError("Can't find towers file");
            return null;
        }
    }
}
