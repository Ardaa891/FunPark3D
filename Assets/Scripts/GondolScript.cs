using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GondolScript : MonoBehaviour
{
    public static GondolScript Current;

    public List<GameObject> gondolCharacters;

    public TextMeshProUGUI gondolCurrentCountText;
    public TextMeshProUGUI gondolMaxCountText;

    public float gondolCurrentCount;
    public float gondolMaxCount;

    public bool gondolFull;
    public bool canEnter;

    public bool gondolTouchingExit;

    public GameObject gondolChar1, gondolChar2;
    public GameObject pathExitObject;

    void Start()
    {
        Current = this;

        gondolCharacters = new List<GameObject>(Resources.LoadAll<GameObject>("Characters"));

        gondolCurrentCount = 0;
        gondolMaxCount = 2;
        gondolMaxCountText.text = "/" + gondolMaxCount.ToString();

        GetComponent<Animator>().enabled = false;

        StartCoroutine(GetCharactersOut());
    }


    void Update()
    {
        gondolCurrentCountText.text = gondolCurrentCount.ToString();

        if (LevelController.Current.gameActive)
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }

        if (gondolCurrentCount < gondolMaxCount)
        {


            gondolFull = false;



        }
        else
        {

            gondolFull = true;



        }



        if (gondolCurrentCount == 1)
        {
            gondolChar1.SetActive(true);
            gondolChar2.SetActive(false);
            
        }
        else if (gondolCurrentCount == 2)
        {
            gondolChar1.SetActive(true);
            gondolChar2.SetActive(true);
            
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PathTriggerExit"))
        {
            gondolTouchingExit = true;
            pathExitObject = other.gameObject;



        }


    }

    IEnumerator GetCharactersOut()
    {
        while (true)
        {
            float waitTime = Random.Range(1, 3);
            yield return new WaitForSecondsRealtime(waitTime);

            if (gondolFull)
            {
                Debug.Log("gondolchar");



                int randomCharacter = Random.Range(0, gondolCharacters.Count - 1);


                GameObject tmp = Instantiate(gondolCharacters[randomCharacter], new Vector3(transform.position.x, transform.position.y, 0.125f), Quaternion.Euler(-45f, 0, 0));
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
