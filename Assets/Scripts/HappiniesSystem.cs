using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MoreMountains.NiceVibrations;

public class HappiniesSystem : MonoBehaviour
{
    public static HappiniesSystem Current;

    public Image happiniesBar;
    public float happiniesAmount;
    
    void Start()
    {
        Current = this;

        if(SceneManager.GetActiveScene().buildIndex != 2)
        {
            happiniesBar.fillAmount = 0.5f;
            happiniesAmount = 0.5f;
        }
        else
        {
            happiniesBar.fillAmount = 0.85f;
            happiniesAmount = 0.85f;
        }

        
    }

    
    void Update()
    {

        happiniesBar.fillAmount = happiniesAmount;

        /*if (happiniesAmount <= 0)
        {
            Debug.Log("failllll");
            LevelController.Current.GameOver();
            Invoke("FailHaptic", 0.1f);
        }

        if(happiniesAmount >= 1)
        {
            LevelController.Current.Win();
            Invoke("WinHaptic", 0.1f);
        }*/
    }

    public void WinHaptic()
    {
        MMVibrationManager.Haptic(HapticTypes.Success);
    }

    public void FailHaptic()
    {
        MMVibrationManager.Haptic(HapticTypes.Failure);
    }



}
