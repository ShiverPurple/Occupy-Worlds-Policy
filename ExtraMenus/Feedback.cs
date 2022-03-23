using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class Feedback : MonoBehaviour
{

    [SerializeField] GameObject feedbackWindow;
    [SerializeField] private TextMeshProUGUI txtData;

    // Forms URL and Entry Key

    private const string googleFormsUrl = "https://docs.google.com/forms/d/e/1FAIpQLSeMYYASF9LE9AU1QHnVcmvO1cJ5__KJRqTIp4bt6JPRcuXmXg/";
    private const string googleFormsEntryKey = "entry.1388008597";

    public void SendReport() {

        StartCoroutine(SendReportWait(txtData.text));
        feedbackWindow.SetActive(false);

    }

    // Wait for response

    private static IEnumerator SendReportWait<T>(T data)
    {

        string jsonData = data is string ? data.ToString() : JsonUtility.ToJson(data);

        WWWForm form = new WWWForm();
        form.AddField(googleFormsEntryKey, jsonData);

        string completeUrl = googleFormsUrl + "formResponse";

        using (UnityWebRequest www = UnityWebRequest.Post(completeUrl, form))
        {

            yield return www.SendWebRequest();

        }

    }

    public void OpenFeedback()
    {

        if (!feedbackWindow.activeSelf)
        {

            feedbackWindow.SetActive(true);

        }
        else
        {

            feedbackWindow.SetActive(false);

        }

    }

    public void CloseFeedback()
    {

        if (feedbackWindow.activeSelf)
        {

            feedbackWindow.SetActive(false);

        }

    }

}
