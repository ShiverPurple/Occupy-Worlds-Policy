using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayService : MonoBehaviour
{

     public static PlayService instance;

     void Start()
     {
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        PlayGamesPlatform.DebugLogEnabled = true;

        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
     }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            CloudSaveManager.isSaving = false;
            CloudSaveManager.instance.OpenCloudSave();
        }
        else
        {
            ChangeScene.instance.loadingText.text = "Autenticação falhou\nClique aqui para continuar offline";

            Debug.Log(status);
            CloudSaveManager.loadDone = true;
        }
    }

}
