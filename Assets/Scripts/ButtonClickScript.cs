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

        if (LevelController.Current.gameActive)
        {
            pointerDown = true;
            circleClipper.GetComponent<RuntimeCircleClipper>().enabled = false;
            lineObject.GetComponent<LineObjectScript>().enabled = false;
        }
        
       
    }

   

    public void OnPointerUp(PointerEventData eventData)
    {
        if (LevelController.Current.gameActive)
        {
            pointerDown = false;
            circleClipper.GetComponent<RuntimeCircleClipper>().enabled = true;
            lineObject.GetComponent<LineObjectScript>().enabled = true;
            //gameObject.SetActive(false);



            StartCoroutine(ButtonDeactivator());
        }

       
    }

    



    IEnumerator ButtonDeactivator()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        while (true)
        {
            gameObject.SetActive(false);
        }

       
    }
}
