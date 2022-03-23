using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SelectAsteroids : MonoBehaviour
{

    public PlayerData selectedAsteroidData = new PlayerData();

    public static SelectAsteroids functions;

    public Dictionary<string, GameObject> asteroidID = new Dictionary<string, GameObject>();

    public static string currentIDT1 = "asteroidT1";
    public static string currentIDBrokenT1 = "asteroidBrokenT1";
    public static string currentIDT2 = "asteroidT2";
    public static string currentIDBrokenT2 = "asteroidBrokenT2";
    public static string currentIDT3 = "asteroidT3";
    public static string currentIDBrokenT3 = "asteroidBrokenT3";

    public GameObject currentT1;
    public GameObject currentBrokenT1;
    public GameObject currentT2;
    public GameObject currentBrokenT2;
    public GameObject currentT3;
    public GameObject currentBrokenT3;

    public GameObject asteroidT1;
    public GameObject asteroidBrokenT1;
    public GameObject asteroidT2;
    public GameObject asteroidBrokenT2;
    public GameObject asteroidT3;
    public GameObject asteroidBrokenT3;

    public GameObject dogeT1;
    public GameObject dogeBrokenT1;
    public GameObject dogeT2;
    public GameObject dogeBrokenT2;
    public GameObject dogeT3;
    public GameObject dogeBrokenT3;

    void Start()
    {

       
        if (File.Exists(Path.Combine(Application.persistentDataPath, "savetest.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "savetestcloud.k")))
        {

            selectedAsteroidData = SaveSystem.LoadPlayer();
            InputValues(selectedAsteroidData);

        }
        
        asteroidID.Add("asteroidT1", asteroidT1);
        asteroidID.Add("asteroidBrokenT1", asteroidBrokenT1);
        asteroidID.Add("asteroidT2", asteroidT2);
        asteroidID.Add("asteroidBrokenT2", asteroidBrokenT2);
        asteroidID.Add("asteroidT3", asteroidT3);
        asteroidID.Add("asteroidBrokenT3", asteroidBrokenT3);
        
        asteroidID.Add("dogeT1", dogeT1);
        asteroidID.Add("dogeBrokenT1", dogeBrokenT1);
        asteroidID.Add("dogeT2", dogeT2);
        asteroidID.Add("dogeBrokenT2", dogeBrokenT2);
        asteroidID.Add("dogeT3", dogeT3);
        asteroidID.Add("dogeBrokenT3", dogeBrokenT3);

        functions = this;

    }

    void InputValues(PlayerData data)
    {

        currentIDT1 = data.saveCurrentIDT1;
        currentIDT2 = data.saveCurrentIDT2;
        currentIDT3 = data.saveCurrentIDT3;

        currentIDBrokenT1 = data.saveCurrentIDBrokenT1;
        currentIDBrokenT2 = data.saveCurrentIDBrokenT2;
        currentIDBrokenT3 = data.saveCurrentIDBrokenT3;

    }

    public void currentDogeT1()
    {

        currentIDT1 = "dogeT1";
        currentIDBrokenT1 = "dogeBrokenT1";


    }

    public void currentDogeT2()
    {

        currentIDT2 = "dogeT2";
        currentIDBrokenT2 = "dogeBrokenT2";

    }

    public void currentDogeT3()
    {

        currentIDT3 = "dogeT3";
        currentIDBrokenT3 = "dogeBrokenT3";

    }

}
