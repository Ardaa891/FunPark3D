using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool pointerDown;



    public GameObject circleClipper;
    public GameObject lineObject;


    private void Start()
    {
        lineObject = GameObject.FindGameObjectWithTag("LineObject");
    }






    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        circleClipper.GetComponent<RuntimeCircleClipper>().enabled = false;
        lineObject.GetComponent<LineObjectScript>().enabled = false;
    }

   

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
        circleClipper.GetComponent<RuntimeCircleClipper>().enabled = true;
        lineObject.GetComponent<LineObjectScript>().enabled = true;
    }

    /*private void Update()
    {
        if (pointerDown)
        {
            circleClipper.GetComponent<RuntimeCircleClipper>().enabled = false;
            lineObject.GetComponent<LineObjectScript>().enabled = false;
        }
        else if(!pointerDown)
        {
            circleClipper.GetComponent<RuntimeCircleClipper>().enabled = true;
            lineObject.GetComponent<LineObjectScript>().enabled = true;
        }
    }*/
}
