using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceObjectExitScript : MonoBehaviour
{
    

    public bool truePath;
    public bool wrongPath;

    public bool checkRocket;
    public bool checkFerris;
    public bool checkTrain;
    public bool checkGondol;
    public bool checkBatSpin;
    public bool checkBumperCar;
    public bool checkCrazyDance;
    public bool checkSwing;

    public List<GameObject> queue;


    void Start()
    {
        queue = new List<GameObject>();
    }

    
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("RocketToy"))
        {
            Debug.Log("Exit");
            truePath = true;
            checkRocket = true;
            
        }

        if (other.CompareTag("FerrisWheel"))
        {
            Debug.Log("Exit");
            truePath = true;
            checkFerris = true;
        }

        if (other.CompareTag("OctopusTrain"))
        {
            Debug.Log("ocExit");
            truePath = true;
            checkTrain = true;
        }

        if (other.CompareTag("Gondol"))
        {
            Debug.Log("ocExit");
            truePath = true;
            checkGondol = true;
        }

        if (other.CompareTag("BatSpin"))
        {
            Debug.Log("ocExit");
            truePath = true;
            checkBatSpin = true;
        }

        if (other.CompareTag("BumperCar"))
        {
            Debug.Log("ocExit");
            truePath = true;
            checkBumperCar = true;
        }

        if (other.CompareTag("CrazyDance"))
        {
            Debug.Log("ocExit");
            truePath = true;
            checkCrazyDance = true;
        }

        if (other.CompareTag("Swing"))
        {
            Debug.Log("Exit");
            truePath = true;
            checkSwing = true;
        }




    }

    
}
