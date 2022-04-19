using System.Collections;
using UnityEngine;

public class AutoSaveScript : MonoBehaviour
{
    public PlayerData data = new PlayerData();

    void Start()
    {
        StartAutoSave();
    }

    void StartAutoSave()
    {
        StartCoroutine(AutoSave());
    }

    IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);

            PlayerData.SaveToFile(data);

            CloudSaveManager.isSaving = true;
            CloudSaveManager.instance.OpenCloudSave();
        }
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PlayerData.SaveToFile(data);

            CloudSaveManager.isSaving = true;
            CloudSaveManager.instance.OpenCloudSave();
        }
    }

}
