using System.Collections.Generic;
using UnityEngine;

public class ShatteredPosition : MonoBehaviour
{

    #region Initialization / Declaration

    [SerializeField] private GameObject explosionAudio;

    public List<Renderer> childArray = new List<Renderer>();

    Vector3 defaultPosition = new Vector3(0, 0, 0);

    #endregion

    void Start()
    {
       GetComponentsInChildren(childArray);
    }

    void OnEnable()
    {
        for (int i = 0; i < childArray.Count; i++)
        {
            childArray[i].transform.localPosition = defaultPosition;
        }

        explosionAudio.GetComponents<AudioSource>()[3].Play();
    }

}
