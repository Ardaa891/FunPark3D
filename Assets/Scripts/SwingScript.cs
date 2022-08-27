using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwingScript : MonoBehaviour
{
    public static SwingScript Current;

    public List<GameObject> swingCharacters;

    public TextMeshProUGUI swingCurrentCountText;
    public TextMeshProUGUI swingMaxCountText;

    public float swingCurrentCount;
    public float swingMaxCount;

    public bool swingFull;
    public bool canEnter;

    public bool swingTouchingExit;

    public GameObject swingChar1, swingChar2, swingChar3, swingChar4;

    public GameObject pathExitObject;

    void Start()
    {
        Current = this;

        swingCharacters = new List<GameObject>(Resources.LoadAll<GameObject>("Characters"));

        swingCurrentCount = 0;
        swingMaxCount = 4;
        swingMaxCountText.text = "/" + swingMaxCount.ToString();

        GetComponent<Animator>().enabled = false;

        StartCoroutine(GetCharactersOut());
    }


    void Update()
    {
        swingCurrentCountText.text = swingCurrentCount.ToString();

        if (LevelController.Current.gameActive)
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }

        if (swingCurrentCount < swingMaxCount)
        {


            swingFull = false;



        }
        else
        {

            swingFull = true;



        }



        if (swingCurrentCount == 1)
        {
            swingChar1.SetActive(true);
            swingChar2.SetActive(false);
            swingChar3.SetActive(false);
            swingChar4.SetActive(false);
        }
        else if (swingCurrentCount == 2)
        {
            swingChar1.SetActive(true);
            swingChar2.SetActive(true);
            swingChar3.SetActive(false);
            swingChar4.SetActive(false);
        }
        else if (swingCurrentCount == 3)
        {
            swingChar1.SetActive(true);
            swingChar2.SetActive(true);
            swingChar3.SetActive(true);
            swingChar4.SetActive(false);
        }
        else if (swingCurrentCount == 4)
        {
            swingChar1.SetActive(true);
            swingChar2.SetActive(true);
            swingChar3.SetActive(true);
            swingChar4.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            swingCurrentCount--;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PathTriggerExit"))
        {
            swingTouchingExit = true;

            pathExitObject = other.gameObject;




        }


    }



    IEnumerator GetCharactersOut()
    {
        while (true)
        {
            float waitTime = Random.Range(1, 4);
            yield return new WaitForSecondsRealtime(waitTime);

            if (swingFull)
            {
                Debug.Log("rocketchar");



                int randomCharacter = Random.Range(0, swingCharacters.Count - 1);


                GameObject tmp = Instantiate(swingCharacters[randomCharacter], new Vector3(transform.position.x, transform.position.y, 0.125f), Quaternion.Euler(-45f, 0, 0));
                tmp.GetComponent<CharacterExit>().getOut = true;
                tmp.GetComponent<CharacterController>().inSwing = false;
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
