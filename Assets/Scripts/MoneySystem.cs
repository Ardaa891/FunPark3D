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
    public int octopusTrainPrice;
    public int gondolPrice;
    public int batSpinPrice;
    public int bumperCarPrice;
    public int crazyDancePrice;
    public int swingPrice;

    public Button rocketToyUnlockButton;
    public Button ferrisWheelUnlockButton;
    public Button octopusTrainUnlockButton;
    public Button gondolUnlockButton;
   
    public Button batSpinUnlockButton;
    public Button bumperCarUnlockButton;
    public Button crazyDanceUnlockButton;
    public Button swingUnlockButton;

    public GameObject cricleClipper;
    


    void Start()
    {
        Current = this;
        //PlayerPrefs.GetInt("Money");
        moneyText.text = PlayerPrefs.GetInt("Money").ToString();

        rocketToyPrice = 200;
        ferrisWheelPrice = 250;
        octopusTrainPrice = 350;
        gondolPrice = 400;
        batSpinPrice = 450;
        crazyDancePrice = 500;
        bumperCarPrice = 550;
        swingPrice = 300;
    }

    


    void Update()
    {
        moneyText.text = PlayerPrefs.GetInt("Money").ToString();

        if(PlayerPrefs.GetInt("Money") < rocketToyPrice)
        {
            rocketToyUnlockButton.interactable = false;
            //rocketToyUnlockButton.GetComponent<ButtonClickScript>().enabled = false;
        }
        else
        {
            rocketToyUnlockButton.interactable = true;
        }

        if(PlayerPrefs.GetInt("Money") < ferrisWheelPrice)
        {
            ferrisWheelUnlockButton.interactable = false;
            ferrisWheelUnlockButton.GetComponent<ButtonClickScript>().enabled = false;
        }
        else
        {
            ferrisWheelUnlockButton.interactable = true;
            ferrisWheelUnlockButton.GetComponent<ButtonClickScript>().enabled = true;
        }

        if (PlayerPrefs.GetInt("Money") < octopusTrainPrice)
        {
            octopusTrainUnlockButton.interactable = false;
            octopusTrainUnlockButton.GetComponent<ButtonClickScript>().enabled = false;
        }
        else
        {
            octopusTrainUnlockButton.interactable = true;
            octopusTrainUnlockButton.GetComponent<ButtonClickScript>().enabled = true;
        }

        if (PlayerPrefs.GetInt("Money") < gondolPrice)
        {
            gondolUnlockButton.interactable = false;
           
            gondolUnlockButton.GetComponent<ButtonClickScript>().enabled = false;
            
        }
        else
        {
            gondolUnlockButton.interactable = true;
           

            gondolUnlockButton.GetComponent<ButtonClickScript>().enabled = true;
            
        }

        if (PlayerPrefs.GetInt("Money") < batSpinPrice)
        {
            batSpinUnlockButton.interactable = false;
            batSpinUnlockButton.GetComponent<ButtonClickScript>().enabled = false;
        }
        else
        {
            batSpinUnlockButton.interactable = true;
            batSpinUnlockButton.GetComponent<ButtonClickScript>().enabled = true;
        }

        /*if (PlayerPrefs.GetInt("Money") < bumperCarPrice)
        {
            bumperCarUnlockButton.interactable = false;
        }
        else
        {
            bumperCarUnlockButton.interactable = true;
        }*/

        if (PlayerPrefs.GetInt("Money") < crazyDancePrice)
        {
            crazyDanceUnlockButton.interactable = false;
            crazyDanceUnlockButton.GetComponent<ButtonClickScript>().enabled = false;
        }
        else
        {
            crazyDanceUnlockButton.interactable = true;
            crazyDanceUnlockButton.GetComponent<ButtonClickScript>().enabled = true;
        }

        if (PlayerPrefs.GetInt("Money") < swingPrice)
        {
            swingUnlockButton.interactable = false;
            swingUnlockButton.GetComponent<ButtonClickScript>().enabled = false;
        }
        else
        {
            swingUnlockButton.interactable = true;
            swingUnlockButton.GetComponent<ButtonClickScript>().enabled = true;
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

    public void UnlockOctopusTrain()
    {
        GameObject octopusTrain = GameObject.FindGameObjectWithTag("OctopusTrain");
        octopusTrain.transform.DOScale(0.2f, 0.7f).SetEase(Ease.OutBounce);
        octopusTrainUnlockButton.gameObject.SetActive(false);
        LevelController.Current.availableToys++;

        octopusTrain.GetComponent<SphereCollider>().enabled = true;

        //money -= ferrisWheelPrice;
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - octopusTrainPrice);
    }

    public void UnlockGondol()
    {
        GameObject gondol = GameObject.FindGameObjectWithTag("Gondol");
        gondol.transform.DOScale(0.2f, 0.7f).SetEase(Ease.OutBounce);
        gondolUnlockButton.gameObject.SetActive(false);
        LevelController.Current.availableToys++;

        gondol.GetComponent<BoxCollider>().enabled = true;

        //money -= ferrisWheelPrice;
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - gondolPrice);
    }

    public void UnlockBatSpin()
    {
        GameObject batSpin = GameObject.FindGameObjectWithTag("BatSpin");
        batSpin.transform.DOScale(0.2f, 0.7f).SetEase(Ease.OutBounce);
        batSpinUnlockButton.gameObject.SetActive(false);
        LevelController.Current.availableToys++;

        batSpin.GetComponent<SphereCollider>().enabled = true;

        //money -= ferrisWheelPrice;
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - batSpinPrice);
    }

    public void UnlockBumperCar()
    {
        GameObject bumperCar = GameObject.FindGameObjectWithTag("BumperCar");
        bumperCar.transform.DOScale(0.2f, 0.7f).SetEase(Ease.OutBounce);
        ferrisWheelUnlockButton.gameObject.SetActive(false);
        LevelController.Current.availableToys++;

        bumperCar.GetComponent<BoxCollider>().enabled = true;

        //money -= ferrisWheelPrice;
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - bumperCarPrice);
    }

    public void UnlockCrazyDance()
    {
        GameObject crazyDance = GameObject.FindGameObjectWithTag("CrazyDance");
        crazyDance.transform.DOScale(0.2f, 0.7f).SetEase(Ease.OutBounce);
        crazyDanceUnlockButton.gameObject.SetActive(false);
        LevelController.Current.availableToys++;

        crazyDance.GetComponent<BoxCollider>().enabled = true;

        //money -= ferrisWheelPrice;
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - crazyDancePrice);
    }

    public void UnlockSwing()
    {
        GameObject swing = GameObject.FindGameObjectWithTag("Swing");
        swing.transform.DOScale(0.2f, 0.7f).SetEase(Ease.OutBounce);
        crazyDanceUnlockButton.gameObject.SetActive(false);
        LevelController.Current.availableToys++;

        swing.GetComponent<BoxCollider>().enabled = true;

        //money -= ferrisWheelPrice;
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - swingPrice);
    }



}
