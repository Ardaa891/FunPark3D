using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceObjectScript : MonoBehaviour
{
    
    public GameObject lineObject;
    public Vector3[] ownWaypoint;

    public List<GameObject> queue;

    public float queueCount;

    public bool active;
    


   
    void Start()
    {
        lineObject = GameObject.FindGameObjectWithTag("LineObject");
        ownWaypoint = lineObject.GetComponent<LineObjectScript>().positions;

        queue = new List<GameObject>();

        
    }

    // Update is called once per frame
    void Update()
    {
        queueCount = queue.Count;

        /*if (queue.Count <= 7)
        {
            Debug.Log("dkfhjbgjhdvgbkf");
            //gameObject.SetActive(true);
            // active = true;
            GetComponent<BoxCollider>().enabled = true;
        }
        if(queue.Count > 7)
        {
            //gameObject.SetActive(false);
            //active = false;

            GetComponent<BoxCollider>().enabled = false;
        }*/

        


    }
}
