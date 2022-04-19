using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidPoolScore : MonoBehaviour
{

    #region Initialization / Declaration

    public static AsteroidPoolScore instance;

    [SerializeField] private TextMeshPro asteroidScore;
    [SerializeField] private Color[] colorList = new Color[8];

    private List<TextMeshPro> scorePool = new List<TextMeshPro>();

    #endregion

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreateScorePool();
    }

    void CreateScorePool()
    {
        for (int i = 0; i < 12; i++)
        {
            TextMeshPro tempScore = Instantiate(asteroidScore);
            tempScore.gameObject.SetActive(false);

            scorePool.Add(tempScore);
        }
    }

    public TextMeshPro GetScoreParticle()
    {
        if (scorePool[scorePool.Count - 1].gameObject.activeInHierarchy)
        {
            for (int i = 0; i < scorePool.Count; i++)
            {
                scorePool[i].gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < scorePool.Count; i++)
        {
            if (!scorePool[i].gameObject.activeSelf)
            {
                return scorePool[i];
            }
        }

        return null;
    }

    public void ShowAsteroidScore(TextMeshPro instantiatedPopUp)
    {
        StartCoroutine(GradientCoroutine(instantiatedPopUp));
    }

    IEnumerator GradientCoroutine(TextMeshPro instantiatedPopUp)
    {
        int index = 1;
        float timeCount = 0;
        float timeLimit = 0;

        while (timeLimit < 4.2f)
        {
            instantiatedPopUp.color = Color.Lerp(colorList[index - 1], colorList[index], timeCount / 0.6f);

            timeCount += 0.1f;

            if (timeCount > 0.6f)
            {
                index++;
                timeCount = 0;
                timeLimit += 0.6f;
            }

            yield return new WaitForSeconds(0.1f);
        }

        instantiatedPopUp.gameObject.SetActive(false);
    }

}
