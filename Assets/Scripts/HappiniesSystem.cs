using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HappiniesSystem : MonoBehaviour
{
    public static HappiniesSystem Current;

    public Image happiniesBar;
    public float happiniesAmount;
    
    void Start()
    {
        Current = this;

        if(SceneManager.GetActiveScene().buildIndex != 1)
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

        if (happiniesAmount <= 0)
        {
            LevelController.Current.GameOver();
        }

        if(happiniesAmount >= 1)
        {
            LevelController.Current.Win();
        }
    }
}
