using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScene : MonoBehaviour
{

    #region Initialization / Declaration

    public static ChangeScene instance;

    [SerializeField] public TextMeshProUGUI loadingText;

    #endregion

    private void Start()
    {
        instance = this;
    }

    public void StartGane()
    {
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        while (CloudSaveManager.loadDone == false)
        {
            loadingText.text = "Carregando salvamento da nuvem";

            yield return new WaitForSeconds(1f);
        }
        
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");

        while (!operation.isDone)
        {
            loadingText.text = "Carregando jogo";

            yield return new WaitForSeconds(1f);
        }
    }

}
