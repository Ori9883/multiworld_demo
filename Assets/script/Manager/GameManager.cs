using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject collectedFlame;

    public int worldFire;
    public int sceneNum = 0;
    
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (PlayerPrefs.HasKey("WorldFireNum"))
            {
                Debug.Log("AWAKE used");
                PlayerPrefs.SetInt("WorldFireNum", 0);
            }
        }
        else if(instance  != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        loadWorldFire();
    }

    private void Update()
    {
        collectedFlame = GameObject.FindGameObjectsWithTag("CollectedFire")[0];
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        if (sceneNum == 0)
        {
            updateFire(worldFire);
        }
    }

    public void updateFire(int num)
    {
        switch (num)
        {
            case 4:
                collectedFlame.transform.GetChild(0).gameObject.SetActive(true);
                collectedFlame.transform.GetChild(1).gameObject.SetActive(true);
                collectedFlame.transform.GetChild(2).gameObject.SetActive(true);
                collectedFlame.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 3:
                collectedFlame.transform.GetChild(0).gameObject.SetActive(true);
                collectedFlame.transform.GetChild(1).gameObject.SetActive(true);
                collectedFlame.transform.GetChild(2).gameObject.SetActive(true);
                collectedFlame.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case 2:
                collectedFlame.transform.GetChild(0).gameObject.SetActive(true);
                collectedFlame.transform.GetChild(1).gameObject.SetActive(true);
                collectedFlame.transform.GetChild(2).gameObject.SetActive(false);
                collectedFlame.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case 1:
                collectedFlame.transform.GetChild(0).gameObject.SetActive(true);
                collectedFlame.transform.GetChild(1).gameObject.SetActive(false);
                collectedFlame.transform.GetChild(2).gameObject.SetActive(false);
                collectedFlame.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case 0:
                collectedFlame.transform.GetChild(0).gameObject.SetActive(false);
                collectedFlame.transform.GetChild(1).gameObject.SetActive(false);
                collectedFlame.transform.GetChild(2).gameObject.SetActive(false);
                collectedFlame.transform.GetChild(3).gameObject.SetActive(false);
                break;
        }
    }

    public int loadWorldFire()
    {
        if (!PlayerPrefs.HasKey("WorldFireNum"))
        {
            PlayerPrefs.SetInt("WorldFireNum", 0);
        }

        worldFire = PlayerPrefs.GetInt("WorldFireNum");

        return worldFire;
    }

    public void setWorldFire()
    {
        worldFire++;
        Debug.Log(worldFire);
        PlayerPrefs.SetInt("WorldFireNum",worldFire);
    }
}
