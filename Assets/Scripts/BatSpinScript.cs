using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatSpinScript : MonoBehaviour
{
    public static BatSpinScript Current;

    public List<GameObject> batSpinCharacters;

    public TextMeshProUGUI batSpinCurrentCountText;
    public TextMeshProUGUI batSpinMaxCountText;

    public float batSpinCurrentCount;
    public float batSpinMaxCount;

    public bool batSpinFull;
    public bool canEnter;

    public bool batSpinTouchingExit;

    public GameObject batSpinChar1, batSpinChar2, batSpinChar3, batSpinChar4, batSpinChar5, batSpinChar6;

    public GameObject pathExitObject;

    void Start()
    {
        Current = this;

        batSpinCharacters = new List<GameObject>(Resources.LoadAll<GameObject>("Characters"));

        batSpinCurrentCount = 0;
        batSpinMaxCount = 6;
        batSpinMaxCountText.text = "/" + batSpinMaxCount.ToString();

        GetComponent<Animator>().enabled = false;

        StartCoroutine(GetCharactersOut());
    }


    void Update()
    {
        batSpinCurrentCountText.text = batSpinCurrentCount.ToString();

        if (LevelController.Current.gameActive)
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }

        if (batSpinCurrentCount < batSpinMaxCount)
        {


            batSpinFull = false;



        }
        else
        {

            batSpinFull = true;



        }



        if (batSpinCurrentCount == 1)
        {
            batSpinChar1.SetActive(true);
            batSpinChar2.SetActive(false);
            batSpinChar3.SetActive(false);
            batSpinChar4.SetActive(false);
            batSpinChar5.SetActive(false);
            batSpinChar6.SetActive(false);

        }
        else if (batSpinCurrentCount == 2)
        {
            batSpinChar1.SetActive(true);
            batSpinChar2.SetActive(true);
            batSpinChar3.SetActive(false);
            batSpinChar4.SetActive(false);
            batSpinChar5.SetActive(false);
            batSpinChar6.SetActive(false);

        }
        else if (batSpinCurrentCount == 3)
        {
            batSpinChar1.SetActive(true);
            batSpinChar2.SetActive(true);
            batSpinChar3.SetActive(true);
            batSpinChar4.SetActive(false);
            batSpinChar5.SetActive(false);
            batSpinChar6.SetActive(false);

        }
        else if (batSpinCurrentCount == 4)
        {
            batSpinChar1.SetActive(true);
            batSpinChar2.SetActive(true);
            batSpinChar3.SetActive(true);
            batSpinChar4.SetActive(true);
            batSpinChar5.SetActive(false);
            batSpinChar6.SetActive(false);

        }
        else if (batSpinCurrentCount == 5)
        {
            batSpinChar1.SetActive(true);
            batSpinChar2.SetActive(true);
            batSpinChar3.SetActive(true);
            batSpinChar4.SetActive(true);
            batSpinChar5.SetActive(true);
            batSpinChar6.SetActive(false);

        }
        else if (batSpinCurrentCount == 6)
        {
            batSpinChar1.SetActive(true);
            batSpinChar2.SetActive(true);
            batSpinChar3.SetActive(true);
            batSpinChar4.SetActive(true);
            batSpinChar5.SetActive(true);
            batSpinChar6.SetActive(true);

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PathTriggerExit"))
        {
            batSpinTouchingExit = true;

            pathExitObject = other.gameObject;


        }


    }

    IEnumerator GetCharactersOut()
    {
        while (true)
        {
            float waitTime = Random.Range(1, 3);
            yield return new WaitForSecondsRealtime(waitTime);

            if (batSpinFull)
            {
                Debug.Log("batSpinchar");



                int randomCharacter = Random.Range(0, batSpinCharacters.Count - 1);


                GameObject tmp = Instantiate(batSpinCharacters[randomCharacter], new Vector3(transform.position.x, transform.position.y, 0.125f), Quaternion.Euler(-45f, 0, 0));
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
