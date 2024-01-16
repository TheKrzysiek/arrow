using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
   public static void SavePlayer (PlayerData newData)
    {
        List<PlayerData> existingData = LoadPlayers();

        existingData.Add(newData);

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/leaderboards.xxx";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, existingData);
        stream.Close();
        Debug.Log("zapisane");
    }

        public static List<PlayerData> LoadPlayers()
    {
        string path = Application.persistentDataPath + "/leaderboards.xxx";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            List<PlayerData> data = formatter.Deserialize(stream) as List<PlayerData>;
            stream.Close();
            return data;
        }
        else
        {
            return new List<PlayerData>();
        }
    }


}