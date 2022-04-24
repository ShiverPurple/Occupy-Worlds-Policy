using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SelectAsteroids : MonoBehaviour
{

    #region Initialization / Declaration

    public static SelectAsteroids instance;
    public PlayerData selectedAsteroidData = new PlayerData();

    [SerializeField] private GameObject spawnScript;

    public static string currentIDT1 = "asteroidT1";
    public static string currentIDBrokenT1 = "asteroidBrokenT1";
    public static string currentIDT2 = "asteroidT2";
    public static string currentIDBrokenT2 = "asteroidBrokenT2";
    public static string currentIDT3 = "asteroidT3";
    public static string currentIDBrokenT3 = "asteroidBrokenT3";

    public Dictionary<string, GameObject> asteroidID = new Dictionary<string, GameObject>();

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

    public Button toggleT1;
    public Button toggleT2;
    public Button toggleT3;

    public Sprite toggleOn;
    public Sprite toggleOff;

    #endregion

    void Start()
    {
        instance = this;

        if (File.Exists(Path.Combine(Application.persistentDataPath, "owsave.k")) || File.Exists(Path.Combine(Application.persistentDataPath, "owsavecloud.k")))
        {
            selectedAsteroidData = SaveSystem.LoadPlayer();
            InputValues(selectedAsteroidData);
        }

        #region Initializing Asteroid Dictionary

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

        #endregion

        #region Initializing Asteroids

        currentBrokenT1 = asteroidID[currentIDBrokenT1];
        currentBrokenT2 = asteroidID[currentIDBrokenT2];
        currentBrokenT3 = asteroidID[currentIDBrokenT3];

        currentT1 = asteroidID[currentIDT1];
        currentT2 = asteroidID[currentIDT2];
        currentT3 = asteroidID[currentIDT3];

        #endregion


        CheckToggle();
    }

    void InputValues(PlayerData data)
    {
        HitPoint.destroyedAsteroidT1 = data.saveDestroyedAsteroidT1;
        HitPoint.destroyedAsteroidT2 = data.saveDestroyedAsteroidT2;
        HitPoint.destroyedAsteroidT3 = data.saveDestroyedAsteroidT3;

        currentIDT1 = data.saveCurrentIDT1;
        currentIDT2 = data.saveCurrentIDT2;
        currentIDT3 = data.saveCurrentIDT3;

        currentIDBrokenT1 = data.saveCurrentIDBrokenT1;
        currentIDBrokenT2 = data.saveCurrentIDBrokenT2;
        currentIDBrokenT3 = data.saveCurrentIDBrokenT3;
    }

    #region Main Methods

    public void CheckToggle()
    {
        if (Doge.soldDogeT1 != true)
        {
            toggleT1.interactable = false;

        }
        else if (Doge.soldDogeT1 == true && currentIDT1 == "dogeT1")
        {
            toggleT1.image.sprite = toggleOn;
        }
        else if (Doge.soldDogeT1 == true && currentIDT1 != "dogeT1")
        {
            toggleT1.image.sprite = toggleOff;
        }

        if (Doge.soldDogeT2 != true)
        {
            toggleT2.interactable = false;
        }
        else if (Doge.soldDogeT2 == true && currentIDT2 == "dogeT2")
        {
            toggleT2.image.sprite = toggleOn;
        }
        else if (Doge.soldDogeT2 == true && currentIDT2 != "dogeT2")
        {
            toggleT2.image.sprite = toggleOff;
        }

        if (Doge.soldDogeT3 != true)
        {
            toggleT3.interactable = false;
        }
        else if (Doge.soldDogeT3 == true && currentIDT3 == "dogeT3")
        {
            toggleT3.image.sprite = toggleOn;
        }
        else if (Doge.soldDogeT3 == true && currentIDT3 != "dogeT3")
        {
            toggleT3.image.sprite = toggleOff;
        }
    }

    //--------------------- Customização ---------------------//

    public void AsteroidChange(string asteroidTier)
    {
        if (asteroidTier == "asteroidT1" || asteroidTier == "dogeT1")
        {
            if(asteroidTier == "asteroidT1")
            {
                currentIDT1 = "asteroidT1";
                currentIDBrokenT1 = "asteroidBrokenT1";
            }
            else
            {
                currentIDT1 = "dogeT1";
                currentIDBrokenT1 = "dogeBrokenT1";
            }

            spawnScript.GetComponent<SpawnField>().enabled = false;

            AsteroidPool.instance.ReloadSmallShattered();

            AsteroidPool.instance.RefillSmallAsteroidPool();
            AsteroidPool.instance.RefillSmallShatteredPool();

            spawnScript.GetComponent<SpawnField>().enabled = true;
        }
        else if(asteroidTier == "asteroidT2" || asteroidTier == "dogeT2")
        {
            if (asteroidTier == "asteroidT2")
            {
                currentIDT2 = "asteroidT2";
                currentIDBrokenT2 = "asteroidBrokenT2";
            }
            else
            {
                currentIDT2 = "dogeT2";
                currentIDBrokenT2 = "dogeBrokenT2";
            }

            spawnScript.GetComponent<SpawnField>().enabled = false;

            AsteroidPool.instance.ReloadMediumShattered();

            AsteroidPool.instance.RefillMediumAsteroidPool();
            AsteroidPool.instance.RefillMediumShatteredPool();

            spawnScript.GetComponent<SpawnField>().enabled = true;
        }
        else if(asteroidTier == "asteroidT3" || asteroidTier == "dogeT3")
        {
            if (asteroidTier == "asteroidT3")
            {
                currentIDT3 = "asteroidT3";
                currentIDBrokenT3 = "asteroidBrokenT3";
            }
            else
            {
                currentIDT3 = "dogeT3";
                currentIDBrokenT3 = "dogeBrokenT3";
            }

            spawnScript.GetComponent<SpawnField>().enabled = false;

            AsteroidPool.instance.ReloadGreatShattered();

            AsteroidPool.instance.RefillGreatAsteroidPool();
            AsteroidPool.instance.RefillGreatShatteredPool();

            spawnScript.GetComponent<SpawnField>().enabled = true;
        }
    }

    public void ChangeCurrentT1()
    {
        if(Doge.soldDogeT1 == true && currentIDT1 == "dogeT1")
        {
            AsteroidChange("asteroidT1");

            toggleT1.image.sprite = toggleOff;

            PlayerData.SaveToFile(selectedAsteroidData);

            CloudSaveManager.isSaving = true;
            CloudSaveManager.instance.OpenCloudSave();
        }
        else if(Doge.soldDogeT1 == true && currentIDT1 != "dogeT1")
        {
            AsteroidChange("dogeT1");

            toggleT1.image.sprite = toggleOn;

            PlayerData.SaveToFile(selectedAsteroidData);

            CloudSaveManager.isSaving = true;
            CloudSaveManager.instance.OpenCloudSave();
        }
    }

    public void ChangeCurrentT2()
    {
        if (Doge.soldDogeT2 == true && currentIDT2 == "dogeT2")
        {
            AsteroidChange("asteroidT2");

            toggleT2.image.sprite = toggleOff;

            PlayerData.SaveToFile(selectedAsteroidData);

            CloudSaveManager.isSaving = true;
            CloudSaveManager.instance.OpenCloudSave();
        }
        else if (Doge.soldDogeT2 == true && currentIDT2 != "dogeT2")
        {
            AsteroidChange("dogeT2");

            toggleT2.image.sprite = toggleOn;

            PlayerData.SaveToFile(selectedAsteroidData);

            CloudSaveManager.isSaving = true;
            CloudSaveManager.instance.OpenCloudSave();
        }
    }

    public void ChangeCurrentT3()
    {
        if (Doge.soldDogeT3 == true && currentIDT3 == "dogeT3")
        {
            AsteroidChange("asteroidT3");

            toggleT3.image.sprite = toggleOff;

            PlayerData.SaveToFile(selectedAsteroidData);

            CloudSaveManager.isSaving = true;
            CloudSaveManager.instance.OpenCloudSave();
        }
        else if (Doge.soldDogeT3 == true && currentIDT3 != "dogeT3")
        {
            AsteroidChange("dogeT3");

            toggleT3.image.sprite = toggleOn;

            PlayerData.SaveToFile(selectedAsteroidData);

            CloudSaveManager.isSaving = true;
            CloudSaveManager.instance.OpenCloudSave();
        }
    }
    
    #endregion

}
