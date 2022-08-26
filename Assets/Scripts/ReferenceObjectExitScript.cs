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


       
        
    }

    
}
