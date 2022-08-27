using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BumperCarScript : MonoBehaviour
{
    public static BumperCarScript Current;

    public List<GameObject> bumberCarCharacters;

    public TextMeshProUGUI bumberCarCurrentCountText;
    public TextMeshProUGUI bumberCarMaxCountText;

    public float bumberCarCurrentCount;
    public float bumberCarMaxCount;

    public bool bumperCarFull;
    public bool canEnter;

    public bool bumberCarTouchingExit;

    public GameObject bumberCarChar1, bumberCarChar2, bumberCarChar3;

    public GameObject pathExitObject;

    void Start()
    {
        Current = this;

        bumberCarCharacters = new List<GameObject>(Resources.LoadAll<GameObject>("Characters"));

        bumberCarCurrentCount = 0;
        bumberCarMaxCount = 3;
        bumberCarMaxCountText.text = "/" + bumberCarMaxCount.ToString();

        GetComponent<Animator>().enabled = false;

        StartCoroutine(GetCharactersOut());
    }


    void Update()
    {
        bumberCarCurrentCountText.text = bumberCarCurrentCount.ToString();

        if (LevelController.Current.gameActive)
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }

        if (bumberCarCurrentCount < bumberCarMaxCount)
        {


            bumperCarFull = false;



        }
        else
        {

            bumperCarFull = true;



        }



        if (bumberCarCurrentCount == 1)
        {
            bumberCarChar1.SetActive(true);
            bumberCarChar2.SetActive(false);

        }
        else if (bumberCarCurrentCount == 2)
        {
            bumberCarChar1.SetActive(true);
            bumberCarChar2.SetActive(true);
            bumberCarChar3.SetActive(false);

        }
        else if (bumberCarCurrentCount == 3)
        {
            bumberCarChar1.SetActive(true);
            bumberCarChar2.SetActive(true);
            bumberCarChar3.SetActive(true);

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PathTriggerExit"))
        {
            bumberCarTouchingExit = true;

            pathExitObject = other.gameObject;


        }


    }

    IEnumerator GetCharactersOut()
    {
        while (true)
        {
            float waitTime = Random.Range(1, 4);
            yield return new WaitForSecondsRealtime(waitTime);

            if (bumperCarFull)
            {
                Debug.Log("bumberCarchar");



                int randomCharacter = Random.Range(0, bumberCarCharacters.Count - 1);


                GameObject tmp = Instantiate(bumberCarCharacters[randomCharacter], new Vector3(transform.position.x, transform.position.y, 0.125f), Quaternion.Euler(-45f, 0, 0));
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
