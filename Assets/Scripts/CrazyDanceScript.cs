using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrazyDanceScript : MonoBehaviour
{
    public static CrazyDanceScript Current;

    public List<GameObject> crazyDanceCharacters;

    public TextMeshProUGUI crazyDanceCurrentCountText;
    public TextMeshProUGUI crazyDanceMaxCountText;

    public float crazyDanceCurrentCount;
    public float crazyDanceMaxCount;

    public bool crazyDanceFull;
    public bool canEnter;

    public bool crazyDanceTouchingExit;

    public GameObject crazyDanceChar1, crazyDanceChar2;
    public GameObject pathExitObject;

    void Start()
    {
        Current = this;

        crazyDanceCharacters = new List<GameObject>(Resources.LoadAll<GameObject>("Characters"));

        crazyDanceCurrentCount = 0;
        crazyDanceMaxCount = 2;
        crazyDanceMaxCountText.text = "/" + crazyDanceMaxCount.ToString();

        GetComponent<Animator>().enabled = false;

        StartCoroutine(GetCharactersOut());
    }


    void Update()
    {
        crazyDanceCurrentCountText.text = crazyDanceCurrentCount.ToString();

        if (LevelController.Current.gameActive)
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }

        if (crazyDanceCurrentCount < crazyDanceMaxCount)
        {


            crazyDanceFull = false;



        }
        else
        {

            crazyDanceFull = true;



        }



        if (crazyDanceCurrentCount == 1)
        {
            crazyDanceChar1.SetActive(true);
            crazyDanceChar2.SetActive(false);

        }
        else if (crazyDanceCurrentCount == 2)
        {
            crazyDanceChar1.SetActive(true);
            crazyDanceChar2.SetActive(true);

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PathTriggerExit"))
        {
            crazyDanceTouchingExit = true;

            pathExitObject = other.gameObject;


        }


    }

    IEnumerator GetCharactersOut()
    {
        while (true)
        {
            float waitTime = Random.Range(1, 4);
            yield return new WaitForSecondsRealtime(waitTime);

            if (crazyDanceFull)
            {
                Debug.Log("crazyDancechar");



                int randomCharacter = Random.Range(0, crazyDanceCharacters.Count - 1);


                GameObject tmp = Instantiate(crazyDanceCharacters[randomCharacter], new Vector3(transform.position.x, transform.position.y, 0.125f), Quaternion.Euler(-45f, 0, 0));
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
