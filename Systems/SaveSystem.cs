using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SavePlayer(PlayerData data)
    {
        File.Create(Path.Combine(Application.persistentDataPath, "tempSave"));

        string path = Path.Combine(Application.persistentDataPath, "owsave.k");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Create(path);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "owsave.k");
        string cloudPath = Path.Combine(Application.persistentDataPath, "owsavecloud.k");

        if (File.Exists(cloudPath) && !File.Exists(path))
        {
            File.Copy(cloudPath, path, true);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.Open(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else if(!File.Exists(cloudPath) && File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.Open(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else if(File.Exists(cloudPath) && File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = File.Open(path, FileMode.Open);
            PlayerData localData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            File.Copy(cloudPath, Path.Combine(Application.persistentDataPath, "tempSave.k"), true);

            FileStream streamCloud = File.Open(Path.Combine(Application.persistentDataPath, "tempSave.k"), FileMode.Open);
            PlayerData cloudData = formatter.Deserialize(streamCloud) as PlayerData;
            streamCloud.Close();

            if (cloudData.saveTotalMoneyCount >= localData.saveTotalMoneyCount)
                return cloudData;

            else
                return localData;

        }
        else
        {
            Debug.LogError("Data not found");

            return null;
        }
    }

}
