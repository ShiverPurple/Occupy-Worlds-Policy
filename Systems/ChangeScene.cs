using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScene : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private GameObject loading;

    public void Change()
    {

        StartCoroutine(Test());

    }

    IEnumerator Test()
    {
        
        while (CloudSaveManager.done == 0)
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
