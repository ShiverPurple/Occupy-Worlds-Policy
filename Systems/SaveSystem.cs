using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SavePlayer(PlayerData data)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "savetest.k");
        FileStream stream = File.Create(path);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData LoadPlayer()
    {

        string path = Path.Combine(Application.persistentDataPath, "savetest.k");
        string cloudPath = Path.Combine(Application.persistentDataPath, "savetestcloud.k");
        if (File.Exists(cloudPath) && !File.Exists(path))
        {

            File.Copy(Path.Combine(Application.persistentDataPath, "savetestcloud.k"), Path.Combine(Application.persistentDataPath, "savetest.k"), true);

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

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;

        }
        else
        {

            Debug.LogError("Data not found");
            return null;

        }

    }


}
