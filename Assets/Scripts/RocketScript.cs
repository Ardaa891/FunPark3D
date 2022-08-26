using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class RocketScript : MonoBehaviour
{
    public static RocketScript Current;

    public TextMeshProUGUI rocketCurrentCountText;
    public TextMeshProUGUI rocketMaxCountText;

    public float rocketCurrentCount;
    public float rocketMaxCount;

    public bool rocketFull;
    public bool canEnter;
    public bool rocketCharGetOut;
    public bool rocketTouchingExit;

    public GameObject touchingReferenceObject;

    public GameObject rocketChar1, rocketChar2, rocketChar3;

    Animator anim;
    

    
    

    
    public List<GameObject> rocketCharacters;

    void Start()
    {
        Current = this;
        
        rocketCharacters = new List<GameObject>(Resources.LoadAll<GameObject>("Characters"));
        rocketCurrentCount = 0;
        rocketMaxCount = 3;
        rocketMaxCountText.text = "/" + rocketMaxCount.ToString();
        anim = GetComponent<Animator>();
        anim.enabled = false;
        StartCoroutine(GetCharactersOut());

        GetComponent<BoxCollider>().enabled = true;
    }

    
    void Update()
    {
        rocketCurrentCountText.text = rocketCurrentCount.ToString();

        if (LevelController.Current.gameActive)
        {
            anim.enabled = true;
        }
        else
        {
            return;
        }




        if (rocketCurrentCount < rocketMaxCount)
        {
            

            rocketFull = false;
        }
        else
        {
            rocketFull = true;
        }

        if (rocketCurrentCount == 1)
        {
            rocketChar1.SetActive(true);
            rocketChar2.SetActive(false);
            rocketChar3.SetActive(false);
            
        }
        else if (rocketCurrentCount == 2)
        {
            rocketChar1.SetActive(true);
            rocketChar2.SetActive(true);
            rocketChar3.SetActive(false);
           
        }
        else if (rocketCurrentCount == 3)
        {
            rocketChar1.SetActive(true);
            rocketChar2.SetActive(true);
            rocketChar3.SetActive(true);
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PathTriggerExit"))
        {

           


           
        }


        if (other.CompareTag("PathTrigger"))
        {
            touchingReferenceObject = other.gameObject;
        }

        
    }

    IEnumerator GetCharactersOut()
    {
        while (true)
        {
            float waitTime = Random.Range(1, 4);
            yield return new WaitForSecondsRealtime(waitTime);

            if (rocketFull)
            {
                Debug.Log("rocketchar");
                
                

                int randomCharacter = Random.Range(0, rocketCharacters.Count - 1);

                
                GameObject tmp = Instantiate(rocketCharacters[randomCharacter], new Vector3(transform.position.x, transform.position.y, 0.125f), Quaternion.Euler(-45f, 0, 0));
                tmp.GetComponent<CharacterExit>().getOut = true;
                tmp.GetComponent<CharacterController>().inRocket = false;
                tmp.GetComponent<CharacterExit>().happy = true;
                tmp.GetComponent<CharacterExit>().giveMoney = true;
                
            }
           
            
        }
    }

    
}
