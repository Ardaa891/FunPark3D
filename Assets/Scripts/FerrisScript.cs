using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FerrisScript : MonoBehaviour
{
    public static FerrisScript Current;

    public List<GameObject> ferrisCharacters;

    public TextMeshProUGUI ferrisCurrentCountText;
    public TextMeshProUGUI ferrisMaxCountText;

    public float ferrisCurrentCount;
    public float ferrisMaxCount;

    public bool ferrisFull;
   
    void Start()
    {
        Current = this;
        ferrisCharacters = new List<GameObject>(Resources.LoadAll<GameObject>("Characters"));
        ferrisMaxCount = 5;
        ferrisMaxCountText.text = "/" + ferrisMaxCount.ToString();

        ferrisCurrentCount = 0;
        GetComponent<Animator>().enabled = false;
        StartCoroutine(GetCharactersOut());

        GetComponent<BoxCollider>().enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        ferrisCurrentCountText.text = ferrisCurrentCount.ToString();

        if (LevelController.Current.gameActive)
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            return;
        }



        if (ferrisCurrentCount < ferrisMaxCount)
        {


            ferrisFull = false;
        }
        else
        {
            ferrisFull = true;
        }



    }


    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Character"))
        {

            if (ferrisCurrentCount < ferrisMaxCount)
            {
                ferrisCurrentCount++;

                //rocketFull = false;  
            }
            else
            {
                //rocketFull = true;
            }


        }*/
    }



    IEnumerator GetCharactersOut()
    {
        while (true)
        {
            float waitTime = Random.Range(1, 4);
            yield return new WaitForSecondsRealtime(waitTime);

            if (ferrisFull)
            {
                Debug.Log("rocketchar");



                int randomCharacter = Random.Range(0, ferrisCharacters.Count - 1);


                GameObject tmp = Instantiate(ferrisCharacters[randomCharacter], new Vector3(transform.position.x, transform.position.y, 0.125f), Quaternion.Euler(-45f, 0, 0));
                tmp.GetComponent<CharacterExit>().getOut = true;
                tmp.GetComponent<CharacterController>().inRocket = false;
                tmp.GetComponent<CharacterExit>().happy = true;
                tmp.GetComponent<CharacterExit>().giveMoney = true;

            }


        }
    }
}
