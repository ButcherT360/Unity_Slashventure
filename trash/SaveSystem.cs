using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;

[Serializable]
public static class SaveSystem
{

    public static void SavePlayer(PlayerHealth player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.health";
     
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SavePlayerExp(ExperienceLevels experience)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string pathExp = Application.persistentDataPath + "/player.exp";
        FileStream Expstream = new FileStream(pathExp, FileMode.Create);
        PlayerData Expdata = new PlayerData(experience);
        formatter.Serialize(Expstream, Expdata);
        Expstream.Close();
    }

    public static PlayerData LoadPlayerHealth()
    {
        string path = Application.persistentDataPath + "/player.health";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData Healthdata = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return Healthdata;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static PlayerData LoadPlayerExp()
    {
        string path = Application.persistentDataPath + "/player.exp";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData Expdata = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return Expdata;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}