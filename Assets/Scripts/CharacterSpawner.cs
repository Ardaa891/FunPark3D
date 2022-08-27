using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CharacterSpawner : MonoBehaviour
{
    public List<GameObject> characters;

    public GameObject tutorialManager;
    
    void Start()
    {
        characters = new List<GameObject>(Resources.LoadAll<GameObject>("Characters"));
        StartCoroutine(SpawnCharacter());
        

    }

    
    void Update()
    {
        if (LevelController.Current.gameActive && SceneManager.GetActiveScene().buildIndex == 1)
        {
            //StartCoroutine(StartTutorial());

            Invoke("StartTutorial", 2f);
        }
    }

    IEnumerator SpawnCharacter()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 1);
            yield return new WaitForSecondsRealtime(waitTime);


            if (LevelController.Current.gameActive)
            {
                //float waitTime = Random.Range(1, 6);
                float xPos = Random.Range(-1.5f, 2f);
                int randomCharacter = Random.Range(0, characters.Count);

               

                //yield return new WaitForSecondsRealtime(waitTime);
                Instantiate(characters[randomCharacter], new Vector3(0, 0f, -0.05f), Quaternion.Euler(-45f, 0, 0));

               

                

                
            }
            
        }
    }

    /*IEnumerator StartTutorial()
    {
        yield return new WaitForSecondsRealtime(2f);

        tutorialManager.SetActive(true);

        
    }*/

    public void StartTutorial()
    {
        tutorialManager.SetActive(true);
    }


   
}
