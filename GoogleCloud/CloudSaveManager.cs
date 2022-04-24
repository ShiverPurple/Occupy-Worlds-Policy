using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;

public class CloudSaveManager : MonoBehaviour
{

    #region Initialization / Declaration

    public static CloudSaveManager instance;

    [SerializeField] private DataSource dataSource;

    public static bool isSaving = false;
    public static bool loadDone = false;

    public Action<SavedGameRequestStatus> OnSave;
    public Action<SavedGameRequestStatus> OnLoad;

    private PlayerData state;

    private BinaryFormatter formatter;
    private FileStream file;

    private const string cloudSaveName = "savecloud";

    #endregion

    void Start()
    {
        instance = this;
        formatter = new BinaryFormatter();
    }

    #region Serialize and Deserialize

    private byte[] SerializeState()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "owsave.k")))
        {
            if (File.Exists(Path.Combine(Application.persistentDataPath, "owsavecloud.k")))
            {
                File.Delete(Path.Combine(Application.persistentDataPath, "owsavecloud.k"));
            }

            File.Copy(Path.Combine(Application.persistentDataPath, "owsave.k"), Path.Combine(Application.persistentDataPath, "owsavecloud.k"), true);
            file = File.Open(Path.Combine(Application.persistentDataPath, "owsavecloud.k"), FileMode.Open);
            state = formatter.Deserialize(file) as PlayerData;

            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, state);

                return ms.GetBuffer();
            }
        }
        else 
        {
            return null;
        }

    }
    private PlayerData DeserializeState(byte[] data)
    {
        using (MemoryStream ms = new MemoryStream(data))
        {
            return (PlayerData)formatter.Deserialize(ms);
        }
    }

    #endregion

    #region Main Methods

    public void OpenCloudSave()
    {
        try
        {
            ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
            savedGameClient.OpenWithAutomaticConflictResolution(cloudSaveName, dataSource, ConflictResolutionStrategy.UseMostRecentlySaved, SavedGameOpened);
        }
        catch
        {
            Debug.LogError("Play Games desconectado");
        }
    }

    private void SavedGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (isSaving)
            {
                byte[] data = SerializeState();
                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder()
                    .WithUpdatedDescription("Last save : " + DateTime.Now.ToString())
                    .Build();

                ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
                savedGameClient.CommitUpdate(meta, update, data, SaveCallback);
            }
            else
            {
                ISavedGameClient savedGameClient = PlayGamesPlatform.Instance.SavedGame;
                savedGameClient.ReadBinaryData(meta, LoadCallback);
            }
        }
        else
        {
            OnLoad?.Invoke(status);
            loadDone = true;
        }
    }

    private void LoadCallback(SavedGameRequestStatus status, byte[] data)
    {
        if (!File.Exists(Path.Combine(Application.persistentDataPath, "owsave.k")) && data != null && data.Length > 0)
        {
            state = DeserializeState(data);

            if (state.saveMoneyCount > 0)
            {
                FileStream stream = File.Create(Path.Combine(Application.persistentDataPath, "owsavecloud.k"));
                formatter.Serialize(stream, state);

                stream.Close();
                loadDone = true;
            }
        }
        else
        {
            loadDone = true;
        }
    }

    private void SaveCallback(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        loadDone = false;
        OnSave?.Invoke(status);
    }

    #endregion

}
