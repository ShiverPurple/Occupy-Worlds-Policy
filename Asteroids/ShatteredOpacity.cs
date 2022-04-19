using System.Collections.Generic;
using UnityEngine;

public class ShatteredOpacity : MonoBehaviour
{

    #region Initialization / Declaration

    private List<Material> asteroidMaterials;

    private float alphaValue = 1f;

    #endregion

    void Start()
    {
        asteroidMaterials = new List<Material>();

        foreach (Material material in gameObject.GetComponent<Renderer>().materials)
        {
            asteroidMaterials.Add(material);
        }
    }

    void OnDisable()
    {
        alphaValue = 1f;

        for (int i = 0; i < asteroidMaterials.Count; i++)
        {
            var a = asteroidMaterials[i].color;
            asteroidMaterials[i].color = new Color(a.r, a.g, a.b, 1);
        }
    }

    void FixedUpdate() 
    { 
        if(alphaValue >= 0)
        {
            alphaValue -= Time.deltaTime;

            for (int i = 0; i < asteroidMaterials.Count; i++)
            {
                asteroidMaterials[i].color = new Color(asteroidMaterials[i].color.r, asteroidMaterials[i].color.g, asteroidMaterials[i].color.b, alphaValue);
            }
        }

        if (asteroidMaterials[0].color.a == 0 || alphaValue < 0 && alphaValue > -1f)
        {
            alphaValue = 1f;
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

}