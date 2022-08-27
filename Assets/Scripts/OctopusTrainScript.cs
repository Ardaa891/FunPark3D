using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OctopusTrainScript : MonoBehaviour
{
    public static OctopusTrainScript Current;

    public List<GameObject> octopusTrainCharacters;

    public TextMeshProUGUI octopusTrainCurrentCountText;
    public TextMeshProUGUI octopusTrainMaxCountText;

    public float octopusTrainCurrentCount;
    public float octopusTrainMaxCount;

    public bool octopusTrainFull;
    public bool canEnter;

    public bool octopusTouchingExit;

    public GameObject octopusChar1, octopusChar2, octopusChar3, octopusChar4;

    public GameObject pathExitObject;

    void Start()
    {
        Current = this;

        octopusTrainCharacters = new List<GameObject>(Resources.LoadAll<GameObject>("Characters"));

        octopusTrainCurrentCount = 0;
        octopusTrainMaxCount = 4;
        octopusTrainMaxCountText.text = "/" + octopusTrainMaxCount.ToString();

        GetComponent<Animator>().enabled = false;

        StartCoroutine(GetCharactersOut());
    }

    
    void Update()
    {
        octopusTrainCurrentCountText.text = octopusTrainCurrentCount.ToString();

        if (LevelController.Current.gameActive)
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }

        if (octopusTrainCurrentCount < octopusTrainMaxCount)
        {
            

            octopusTrainFull = false;



        }
        else
        {

            octopusTrainFull = true;



        }



        if (octopusTrainCurrentCount == 1)
        {
            octopusChar1.SetActive(true);
            octopusChar2.SetActive(false);
            octopusChar3.SetActive(false);
            octopusChar4.SetActive(false);
        }
        else if (octopusTrainCurrentCount == 2)
        {
            octopusChar1.SetActive(true);
            octopusChar2.SetActive(true);
            octopusChar3.SetActive(false);
            octopusChar4.SetActive(false);
        }
        else if (octopusTrainCurrentCount == 3)
        {
            octopusChar1.SetActive(true);
            octopusChar2.SetActive(true);
            octopusChar3.SetActive(true);
            octopusChar4.SetActive(false);
        }
        else if (octopusTrainCurrentCount == 4)
        {
            octopusChar1.SetActive(true);
            octopusChar2.SetActive(true);
            octopusChar3.SetActive(true);
            octopusChar4.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            octopusTrainCurrentCount--;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PathTriggerExit"))
        {
            octopusTouchingExit = true;

            pathExitObject = other.gameObject;
           



        }


    }

    

    IEnumerator GetCharactersOut()
    {
        while (true)
        {
            float waitTime = Random.Range(1, 4);
            yield return new WaitForSecondsRealtime(waitTime);

            if (octopusTrainFull)
            {
                Debug.Log("rocketchar");



                int randomCharacter = Random.Range(0, octopusTrainCharacters.Count - 1);


                GameObject tmp = Instantiate(octopusTrainCharacters[randomCharacter], new Vector3(transform.position.x, transform.position.y , 0.125f), Quaternion.Euler(-45f, 0, 0));
                tmp.GetComponent<CharacterExit>().getOut = true;
                tmp.GetComponent<CharacterController>().inRocket = false;
                tmp.GetComponent<CharacterExit>().happy = true;
                tmp.GetComponent<CharacterExit>().giveMoney = true;

                //pathExitObject.transform.parent.GetComponent<ReferenceObjectScript>().queue.Remove(pathExitObject.transform.parent.GetComponent<ReferenceObjectScript>().queue[0]);
                Invoke("RemoveChars", 0.1f);
            }


        }
    }

    public void RemoveChars()
    {
        pathExitObject.transform.parent.GetComponent<ReferenceObjectScript>().queue.Remove(pathExitObject.transform.parent.GetComponent<ReferenceObjectScript>().queue[0]);
    }
}
