using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;



public class MoneySystem : MonoBehaviour
{
    public static MoneySystem Current;

    public TextMeshProUGUI moneyText;

    public int money;
    public int rocketToyPrice;
    public int ferrisWheelPrice;

    public Button rocketToyUnlockButton;
    public Button ferrisWheelUnlockButton;

    public GameObject cricleClipper;
    


    void Start()
    {
        Current = this;
        //PlayerPrefs.GetInt("Money");
        moneyText.text = money.ToString();

        rocketToyPrice = 200;
        ferrisWheelPrice = 300;
    }

    


    void Update()
    {
        moneyText.text = PlayerPrefs.GetInt("Money").ToString();

        if(PlayerPrefs.GetInt("Money") < rocketToyPrice)
        {
            rocketToyUnlockButton.interactable = false;
        }
        else
        {
            rocketToyUnlockButton.interactable = true;
        }

        if(PlayerPrefs.GetInt("Money") < ferrisWheelPrice)
        {
            ferrisWheelUnlockButton.interactable = false;
        }
        else
        {
            ferrisWheelUnlockButton.interactable = true;
        }
        
    }


    public void UnlockRocketToy()
    {
        Debug.Log("click");

        GameObject rocket = GameObject.FindGameObjectWithTag("RocketToy");
        
        rocket.transform.DOScale(0.2f, 0.7f).SetEase(Ease.OutBounce);
        rocketToyUnlockButton.gameObject.SetActive(false);
        
        LevelController.Current.availableToys++;
        rocket.GetComponent<BoxCollider>().enabled = true;

        //money -= rocketToyPrice;
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - rocketToyPrice);
    }

    public void UnlockFerrisWheel()
    {
        GameObject ferris = GameObject.FindGameObjectWithTag("FerrisWheel");
        ferris.transform.DOScale(0.175f, 0.7f).SetEase(Ease.OutBounce);
        ferrisWheelUnlockButton.gameObject.SetActive(false);
        LevelController.Current.availableToys++;

        ferris.GetComponent<BoxCollider>().enabled = true;

        //money -= ferrisWheelPrice;
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - ferrisWheelPrice);
    }



}
