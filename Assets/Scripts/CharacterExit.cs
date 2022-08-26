using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using MoreMountains.NiceVibrations;

public class CharacterExit : MonoBehaviour
{
    GameObject rocketToy;
    GameObject ferrisWheel;
    GameObject octopusTrain;

    public GameObject coinPrefab;
    public GameObject happyPrefab;
    public GameObject sadPrefab;
    public GameObject pathTriggerExit;
    public GameObject tutorialManager;

    public GameObject rightDoor;
    public GameObject leftDoor;

    public bool getOut;
    public bool happy;
    public bool giveMoney;
    public bool preExit;

    bool up;

    public TextMeshProUGUI moneyText;
   
    void Start()
    {
        up = false;
        
        rocketToy = GameObject.FindGameObjectWithTag("RocketToy");
        ferrisWheel = GameObject.FindGameObjectWithTag("FerrisWheel");
        octopusTrain = GameObject.FindGameObjectWithTag("OctopusTrain");

        pathTriggerExit = GameObject.FindGameObjectWithTag("PathTriggerExit");

        rightDoor = GameObject.FindGameObjectWithTag("RightDoor");
        leftDoor = GameObject.FindGameObjectWithTag("LeftDoor");

        

        /*if(getOut)
        {
            gameObject.transform.DOMove(new Vector3(0, transform.position.y, -0.05f), 0.75f).SetEase(Ease.InQuint).OnComplete(() => up = true);
        }*/

    }

    
    void Update()
    {
        if (LevelController.Current.gameActive)
        {
            if (getOut)
            {
                gameObject.transform.DOMove(new Vector3(0, transform.position.y + 1f, -0.05f), 0.7f).SetEase(Ease.InQuint).OnComplete(() => up = true);
            }

            if (up)
            {
                //GetComponent<CharacterController>().enabled = false;
                Debug.Log("WHY");
                getOut = false;
                transform.Translate(Vector3.up * 0.75f * Time.deltaTime);
                transform.Translate(Vector3.forward * 0.75f * Time.deltaTime);
                GetComponent<CapsuleCollider>().enabled = true;
            }
        }
        else
        {
            return;
        }


        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RocketToy"))
        {
            rocketToy.GetComponent<RocketScript>().rocketCurrentCount--;
            GetComponent<CharacterController>().enabled = false;

            if (happy)
            {
                Sequence seq = DOTween.Sequence();
                GameObject happy = Instantiate(happyPrefab, transform.position, Quaternion.identity);
                happy.transform.SetParent(gameObject.transform);

                seq.Append(happy.transform.DOScale(0.05f, 0.5f).SetEase(Ease.OutBounce));
                seq.Join(happy.transform.DOLocalMoveY(7f, 0.5f).SetEase(Ease.OutQuad));
                seq.Join(happy.transform.DOLocalMoveZ(0f, 0.5f).SetEase(Ease.OutQuad));
            }

           
        }

        if (other.CompareTag("FerrisWheel"))
        {
            ferrisWheel.GetComponent<FerrisScript>().ferrisCurrentCount--;
            GetComponent<CharacterController>().enabled = false;

            if (happy)
            {
                Sequence seq = DOTween.Sequence();
                GameObject happy = Instantiate(happyPrefab, transform.position, Quaternion.identity);
                happy.transform.SetParent(gameObject.transform);

                seq.Append(happy.transform.DOScale(0.05f, 0.5f).SetEase(Ease.OutBounce));
                seq.Join(happy.transform.DOLocalMoveY(7f, 0.5f).SetEase(Ease.OutQuad));
                seq.Join(happy.transform.DOLocalMoveZ(0f, 0.5f).SetEase(Ease.OutQuad));
            }

        }

        if (other.CompareTag("OctopusTrain"))
        {
            octopusTrain.GetComponent<OctopusTrainScript>().octopusTrainCurrentCount--;
            GetComponent<CharacterController>().enabled = false;

            if (happy)
            {
                Sequence seq = DOTween.Sequence();
                GameObject happy = Instantiate(happyPrefab, transform.position, Quaternion.identity);
                happy.transform.SetParent(gameObject.transform);

                seq.Append(happy.transform.DOScale(0.05f, 0.5f).SetEase(Ease.OutBounce));
                seq.Join(happy.transform.DOLocalMoveY(7f, 0.5f).SetEase(Ease.OutQuad));
                seq.Join(happy.transform.DOLocalMoveZ(0f, 0.5f).SetEase(Ease.OutQuad));
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            StartCoroutine(KillPeople());
            if (happy && giveMoney)
            {
                HappiniesSystem.Current.happiniesAmount += 0.05f;

                OpenDoors();

                Debug.Log("givemoney");
                MMVibrationManager.Haptic(HapticTypes.SoftImpact);

                Sequence seq = DOTween.Sequence();
                GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                coin.transform.SetParent(gameObject.transform);

                seq.Append(coin.transform.DOScale(0.1f, 0.5f).SetEase(Ease.OutBounce));
                seq.Join(coin.transform.DOLocalMoveY(10f, 0.5f).SetEase(Ease.OutQuad));
                seq.Join(coin.transform.DOLocalMoveZ(10f, 0.5f).SetEase(Ease.OutQuad));

                seq.Append(coin.transform.DOLocalMove(new Vector3(-40f, 10f, 9f), 0.5f).SetEase(Ease.OutQuad).OnComplete(() => PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 50)));
                seq.Join(coin.transform.DOScale(0f, 0.55f).SetEase(Ease.OutQuad));

                

                //seq.OnComplete(() => MoneySystem.Current.money += 20f);
            }



            /*if (giveMoney)
            {
                Debug.Log("givemoney");

                Sequence seq = DOTween.Sequence();
                GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                coin.transform.SetParent(gameObject.transform);

                seq.Append(coin.transform.DOScale(0.1f, 0.5f).SetEase(Ease.OutBounce));
                seq.Join(coin.transform.DOLocalMoveY(10f, 0.5f).SetEase(Ease.OutQuad));
                seq.Join(coin.transform.DOLocalMoveZ(25f, 0.5f).SetEase(Ease.OutQuad));

                seq.Append(coin.transform.DOLocalMove(new Vector3(56f, 13f, 25f), 0.5f).SetEase(Ease.OutQuad).OnComplete(() => MoneySystem.Current.money += 20f));
                seq.Join(coin.transform.DOScale(0f, 1f).SetEase(Ease.OutQuad));
                

                //seq.OnComplete(() => MoneySystem.Current.money += 20f);
            }*/
        }

        if (other.CompareTag("PreExit"))
        {

            if (!happy && !giveMoney)
            {
                preExit = true;

                if(SceneManager.GetActiveScene().buildIndex != 1)
                {
                    HappiniesSystem.Current.happiniesAmount -= 0.05f;
                }
                else
                {
                    HappiniesSystem.Current.happiniesAmount -= 0.01f;
                }

               

                Sequence seq = DOTween.Sequence();
                GameObject sad = Instantiate(sadPrefab, transform.position, Quaternion.identity);
                sad.transform.SetParent(gameObject.transform);

                seq.Append(sad.transform.DOScale(0.05f, 0.5f).SetEase(Ease.OutBounce));
                seq.Join(sad.transform.DOLocalMoveY(7f, 0.5f).SetEase(Ease.OutQuad));
                seq.Join(sad.transform.DOLocalMoveZ(0f, 0.5f).SetEase(Ease.OutQuad));


            }

            
        }
    }




    IEnumerator KillPeople()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }

    public void OpenDoors()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(rightDoor.transform.DOLocalRotate(new Vector3(30, 90, 0), 0.5f, RotateMode.Fast).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo));
        seq.Join(leftDoor.transform.DOLocalRotate(new Vector3(-30, -90, 0), 0.5f, RotateMode.Fast).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo));
    }



    

}
