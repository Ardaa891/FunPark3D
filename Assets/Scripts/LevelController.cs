using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
//using Dreamteck.Splines;
using MoreMountains.NiceVibrations;
//using ElephantSDK;
using UnityEngine.EventSystems;

public class LevelController : MonoBehaviour
{
    public static LevelController Current;
    public List<GameObject> levels = new List<GameObject>();
    public GameObject winGameOverMenu, failGameOverMenu, levelStartMenu, inGameMenu;
    public bool gameActive = false;
    public bool levelEnd = false;
    public bool startPressed;
    public bool drawRay;

    public int availableToys;
    
    public GameObject circleClipper;

    public  GameObject lineObject;
    


    [Space]
    [Space]
    public GameObject CurrentLevel;
    public bool isTesting = false;
    // Start is called before the first frame update
    void Awake()
    {
        Current = this;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;
        
        if (isTesting == false)
        {

            if (levels.Count == 0)
            {

                foreach (Transform level in transform)
                {
                    levels.Add(level.gameObject);
                }
            }


            CurrentLevel = levels[PlayerPrefs.GetInt("level") % levels.Count];
            levels[PlayerPrefs.GetInt("level") % levels.Count].SetActive(true);
        }
        else
        {
            CurrentLevel.SetActive(true);
        }

        availableToys = 1;

        lineObject = GameObject.FindGameObjectWithTag("LineObject");
    }

    private void Update()
    {
       
    }





    public void NextLevel()
    {
        //StartCoroutine(LevelUp());
        if ((levels.IndexOf(CurrentLevel) + 1) == levels.Count)
        {




            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);



            //  GameHandler.Instance.Appear_TransitionPanel();


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        }


        else
        {
            CurrentLevel = levels[(PlayerPrefs.GetInt("level") + 1) % levels.Count];



            levels[(PlayerPrefs.GetInt("level")) % levels.Count].SetActive(false);


            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);

            levels[PlayerPrefs.GetInt("level") % levels.Count].SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        
        

    }

    

    public void StartLevel()
    {
        //Elephant.LevelStarted(PlayerPrefs.GetInt("level") + 1);
        //lineObject.GetComponent<LineObjectScript>().trail.enabled = false;
        
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            gameActive = true;
            levelStartMenu.SetActive(false);
            inGameMenu.SetActive(true);
            lineObject.GetComponent<LineObjectScript>().enabled = true;
            circleClipper.GetComponent<RuntimeCircleClipper>().enabled = true;
        }
        else
        {
            gameActive = true;
            levelStartMenu.SetActive(false);
            inGameMenu.SetActive(true);
            lineObject.GetComponent<LineObjectScript>().enabled = false;
            circleClipper.GetComponent<RuntimeCircleClipper>().enabled = false;
        }
        
    }

    public void Win()
    {
        //Elephant.LevelCompleted(PlayerPrefs.GetInt("level") + 1);
        gameActive = false;
        inGameMenu.SetActive(false);
        winGameOverMenu.SetActive(true);
        MMVibrationManager.Haptic(HapticTypes.Success);

        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
           
                PlayerPrefs.SetInt("Tutorial", 1);
            
        }

    }

    public void GameOver()
    {
        //Elephant.LevelFailed(PlayerPrefs.GetInt("level") + 1);
        gameActive = false;
        inGameMenu.SetActive(false);
        failGameOverMenu.SetActive(true);
        MMVibrationManager.Haptic(HapticTypes.Failure);
    }



  

    

  

  
}
