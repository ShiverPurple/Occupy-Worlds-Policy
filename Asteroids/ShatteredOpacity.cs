using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredOpacity : MonoBehaviour
{

    public GameObject Planet;
    public static List<Material> asteroidMaterials = new List<Material>();

    private float alpha = 1f;

    void Start()
    {

        foreach (Material material in gameObject.GetComponent<Renderer>().materials)
        {
            asteroidMaterials.Add(material);

        }


    }

    // Seleciona um material editável

    void OnDisable()
    {

        alpha = 1f;

        for (int i = 0; i < asteroidMaterials.Count; i++)
        {

            var a = asteroidMaterials[i].color;
            asteroidMaterials[i].color = new Color(a.r, a.g, a.b, 1);


        }

    }

    // Desativa os fragmentos de asteroid quando alpha for 0

    void FixedUpdate() 
    { 

        if(alpha >= 0)
        {

            alpha -= Time.deltaTime;

            for (int i = 0; i < asteroidMaterials.Count; i++)
            {

                asteroidMaterials[i].color = new Color(asteroidMaterials[i].color.r, asteroidMaterials[i].color.g, asteroidMaterials[i].color.b, alpha);
        

            }

        }

        if (asteroidMaterials[0].color.a == 0 || alpha < 0 && alpha > -1f)
        {

            alpha = 1f;
            gameObject.transform.parent.gameObject.SetActive(false);

        }

    }

}
