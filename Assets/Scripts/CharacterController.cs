using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Current;

    public bool startPointReached;
    public bool inPath;
    public bool rocketQueue;
    public bool ferrisQueue;
    public bool octopusTrainQueue;
    public bool gondolQueue;
    public bool batSpinQueue;
    public bool bumperCarQueue;
    public bool crazyDanceQueue;
    public bool swingQueue;
    public bool charHit;
    public bool inRocket;
    public bool inFerris;
    public bool inOctopusTrain;
    public bool inGondol;
    public bool inBatSpin;
    public bool inBumperCar;
    public bool inCrazyDance;
    public bool inSwing;

    public bool pathExit;
    public bool goMainRoad;
    public bool exitQueue;

    //public bool firstQueue;

    int randomDecider;

    public GameObject referenceObject;
    public GameObject referenceExitObject;
    public GameObject lineObject;
    public GameObject firstQueueObject;

    public Transform behind;

    //public List<GameObject> firstQueue;


    //RaycastHit Character;




    void Start()
    {
        Current = this;

        lineObject = GameObject.FindGameObjectWithTag("LineObject");

        transform.DOLocalMove(new Vector3(0, 1.065f, -0.05f), 0.5f).SetEase(Ease.Linear).OnComplete(()=>ReachStart());

        firstQueueObject = GameObject.FindGameObjectWithTag("FirstQueue");

      
    }

    
    void Update()
    {
        

        if (LevelController.Current.gameActive)
        {
            if (startPointReached)
            {
               
                if(SceneManager.GetActiveScene().buildIndex == 1)
                {
                    if (inPath)
                    {
                        transform.Translate(0, 0, 0 * 0 * Time.deltaTime);
                    }
                    else
                    {
                        transform.Translate(Vector3.up * 1f * Time.deltaTime);
                        transform.Translate(Vector3.forward * 1f * Time.deltaTime);
                    }
                }else if(SceneManager.GetActiveScene().buildIndex != 1)
                {
                    if(inPath)
                    {
                        transform.Translate(0, 0, 0 * 0 * Time.deltaTime);

                    }
                else if (!inPath)
                    {
                        if (!GetComponent<CharacterExit>().preExit)
                        {
                            transform.Translate(Vector3.up * 1f * Time.deltaTime);
                            transform.Translate(Vector3.forward * 1f * Time.deltaTime);
                        }
                        else
                        {

                            transform.Translate(0, 0, 0 * 0 * Time.deltaTime);
                            transform.Translate(0, 0, 0 * 0 * Time.deltaTime);

                            Invoke("SadLeave", 1f);
                        }

                    }
                }
                /*if (inPath)
                {
                    transform.Translate(0, 0, 0 * 0 * Time.deltaTime);
                    
                }
                else if(!inPath)
                {
                    if (!GetComponent<CharacterExit>().preExit)
                    {
                        transform.Translate(Vector3.up * 1f * Time.deltaTime);
                        transform.Translate(Vector3.forward * 1f * Time.deltaTime);
                    }
                    else
                    {
                        
                        transform.Translate(0, 0, 0 * 0 * Time.deltaTime);
                        transform.Translate(0, 0, 0 * 0 * Time.deltaTime);

                        Invoke("SadLeave", 1f);
                    }
                   
                }*/

            }

            




            if (inRocket && inPath)
            {
                if (RocketScript.Current.rocketCurrentCount < RocketScript.Current.rocketMaxCount)
                {
                    //RocketScript.Current.rocketCurrentCount++;
                    gameObject.SetActive(false);
                }
            }

            if (inFerris && inPath)
            {
                if (FerrisScript.Current.ferrisCurrentCount < FerrisScript.Current.ferrisMaxCount)
                {
                    //FerrisScript.Current.ferrisCurrentCount++;
                    gameObject.SetActive(false);
                }
            }

            if (inOctopusTrain && inPath)
            {
                if (OctopusTrainScript.Current.octopusTrainCurrentCount < OctopusTrainScript.Current.octopusTrainMaxCount)
                {
                    //OctopusTrainScript.Current.octopusTrainCurrentCount++;
                    gameObject.SetActive(false);
                }
            }

            if (inGondol && inPath)
            {
                if (GondolScript.Current.gondolCurrentCount < GondolScript.Current.gondolMaxCount)
                {
                    //OctopusTrainScript.Current.octopusTrainCurrentCount++;
                    gameObject.SetActive(false);
                }
            }

            if (inBatSpin && inPath)
            {
                if (BatSpinScript.Current.batSpinCurrentCount < BatSpinScript.Current.batSpinMaxCount)
                {
                    //OctopusTrainScript.Current.octopusTrainCurrentCount++;
                    gameObject.SetActive(false);
                }
            }

            if (inBumperCar && inPath)
            {
                if (BumperCarScript.Current.bumberCarCurrentCount < BumperCarScript.Current.bumberCarMaxCount)
                {
                    //OctopusTrainScript.Current.octopusTrainCurrentCount++;
                    gameObject.SetActive(false);
                }
            }

            if (inCrazyDance && inPath)
            {
                if (CrazyDanceScript.Current.crazyDanceCurrentCount < CrazyDanceScript.Current.crazyDanceMaxCount)
                {
                    //OctopusTrainScript.Current.octopusTrainCurrentCount++;
                    gameObject.SetActive(false);
                }
            }

            if (inSwing && inPath)
            {
                if (SwingScript.Current.swingCurrentCount < SwingScript.Current.swingMaxCount)
                {
                    //OctopusTrainScript.Current.octopusTrainCurrentCount++;
                    gameObject.SetActive(false);
                }
            }


            if (inPath && referenceObject.GetComponent<ReferenceObjectScript>().queue.IndexOf(gameObject) == 0 && !exitQueue)
            {

                if (!OctopusTrainScript.Current.octopusTrainFull && !RocketScript.Current.rocketFull && !FerrisScript.Current.ferrisFull && !GondolScript.Current.gondolFull && !BatSpinScript.Current.batSpinFull && !BumperCarScript.Current.bumperCarFull && !CrazyDanceScript.Current.crazyDanceFull && !SwingScript.Current.swingFull)
                {
                    transform.DOPlay();
                }

                if (!octopusTrainQueue && !rocketQueue && !ferrisQueue && !gondolQueue && !batSpinQueue && !bumperCarQueue && !crazyDanceQueue && !swingQueue)
                {
                    transform.DOPlay();
                }

            }

           
        }
        else
        {
            return;
        }

        

    }

    public void ReachStart()
    {
        startPointReached = true;
        firstQueueObject.GetComponent<FirstQueueScript>().firstQueue.Add(gameObject);
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PathTrigger"))
        {
            


            if (other.transform.GetChild(0).GetComponent<ReferenceObjectExitScript>().truePath)
            {
                Debug.Log("child");
                
                if (!GetComponent<CharacterExit>().happy && !GetComponent<CharacterExit>().giveMoney)
                {
                    if (other.transform.GetChild(0).GetComponent<ReferenceObjectExitScript>().checkTrain)
                    {
                        if(LevelController.Current.availableToys == 1)
                        {
                            EightyPercent(other.gameObject);
                        }else if(OctopusTrainScript.Current.octopusTrainCurrentCount != OctopusTrainScript.Current.octopusTrainMaxCount)
                        {
                            
                            SixtyPercent(other.gameObject);
                        }
                        else
                        {
                            FiftyPercent(other.gameObject);
                        } 
                    }

                    if (other.transform.GetChild(0).GetComponent<ReferenceObjectExitScript>().checkRocket)
                    {
                        Debug.Log("FAK");
                        if (RocketScript.Current.rocketCurrentCount != RocketScript.Current.rocketMaxCount)
                        {

                            SixtyPercent(other.gameObject);
                        }
                        else
                        {
                            FiftyPercent(other.gameObject);
                        }
                    }

                    if (other.transform.GetChild(0).GetComponent<ReferenceObjectExitScript>().checkFerris)
                    {

                        if (FerrisScript.Current.ferrisCurrentCount != FerrisScript.Current.ferrisMaxCount)
                        {

                            EightyPercent(other.gameObject);
                        }
                        else
                        {
                            SixtyPercent(other.gameObject);
                        }
                    }

                    if (other.transform.GetChild(0).GetComponent<ReferenceObjectExitScript>().checkGondol)
                    {

                        if (GondolScript.Current.gondolCurrentCount != GondolScript.Current.gondolMaxCount)
                        {

                            EightyPercent(other.gameObject);
                        }
                        else
                        {
                            SixtyPercent(other.gameObject);
                        }
                    }

                    if (other.transform.GetChild(0).GetComponent<ReferenceObjectExitScript>().checkBatSpin)
                    {

                        if (BatSpinScript.Current.batSpinCurrentCount != BatSpinScript.Current.batSpinMaxCount)
                        {

                            EightyPercent(other.gameObject);
                        }
                        else
                        {
                            SixtyPercent(other.gameObject);
                        }
                    }

                    if (other.transform.GetChild(0).GetComponent<ReferenceObjectExitScript>().checkBumperCar)
                    {

                        if (BumperCarScript.Current.bumberCarCurrentCount != BumperCarScript.Current.bumberCarMaxCount)
                        {

                            EightyPercent(other.gameObject);
                        }
                        else
                        {
                            SixtyPercent(other.gameObject);
                        }
                    }

                    if (other.transform.GetChild(0).GetComponent<ReferenceObjectExitScript>().checkCrazyDance)
                    {

                        if (CrazyDanceScript.Current.crazyDanceCurrentCount != CrazyDanceScript.Current.crazyDanceMaxCount)
                        {

                            EightyPercent(other.gameObject);
                        }
                        else
                        {
                            SixtyPercent(other.gameObject);
                        }
                    }

                    if (other.transform.GetChild(0).GetComponent<ReferenceObjectExitScript>().checkSwing)
                    {
                        Debug.Log("FAK");
                        if (SwingScript.Current.swingCurrentCount != SwingScript.Current.swingMaxCount)
                        {

                            SixtyPercent(other.gameObject);
                        }
                        else
                        {
                            FiftyPercent(other.gameObject);
                        }
                    }





                }
            }

            
            

            
        }

        

       
        

        if (other.CompareTag("FerrisWheel"))
        {
            inFerris = true;
            //transform.DOPause();
            if (!FerrisScript.Current.ferrisFull)
            {
                referenceObject.GetComponent<ReferenceObjectScript>().queue.Remove(gameObject);
                FerrisScript.Current.ferrisCurrentCount++;
                MMVibrationManager.Haptic(HapticTypes.SoftImpact);
                //MoneySystem.Current.money += 20f;
                gameObject.SetActive(false);
                //transform.DOPause();
                transform.DOPlay();
                //StartCoroutine(KillCharacter());


            }
            else
            {
                Debug.Log("FerrisQueue");
                ferrisQueue = true;
                //transform.DOPause();
                transform.DOPause();
            }

        }

        if (other.CompareTag("RocketToy"))
        {
            inRocket = true;
            //transform.DOPause();
            if (!RocketScript.Current.rocketFull)
            {
                referenceObject.GetComponent<ReferenceObjectScript>().queue.Remove(gameObject);
                RocketScript.Current.rocketCurrentCount++;
                MMVibrationManager.Haptic(HapticTypes.SoftImpact);
                //MoneySystem.Current.money += 20f;
                gameObject.SetActive(false);
                //transform.DOPause();
                transform.DOPlay();
                //StartCoroutine(KillCharacter());
                


            }
            else
            {
                Debug.Log("RocketQueue");
                rocketQueue = true;
                //transform.DOPause();
                transform.DOPause();
            }


        }

        if (other.CompareTag("OctopusTrain"))
        {
            inOctopusTrain = true;
            //transform.DOPause();
            if (!OctopusTrainScript.Current.octopusTrainFull)
            {
                referenceObject.GetComponent<ReferenceObjectScript>().queue.Remove(gameObject);
                OctopusTrainScript.Current.octopusTrainCurrentCount++;
                MMVibrationManager.Haptic(HapticTypes.SoftImpact);
                //MoneySystem.Current.money += 20f;
                //HappiniesSystem.Current.happiniesAmount += 0.05f;
                gameObject.SetActive(false);
                //transform.DOPause();
                transform.DOPlay();

                


            }
            else
            {
                Debug.Log("OctopusQueue");
                octopusTrainQueue = true;
                //transform.DOPause();
                transform.DOPause();
            }


        }

        if (other.CompareTag("Gondol"))
        {
            inGondol = true;
            //transform.DOPause();
            if (!GondolScript.Current.gondolFull)
            {
                referenceObject.GetComponent<ReferenceObjectScript>().queue.Remove(gameObject);
                GondolScript.Current.gondolCurrentCount++;
                MMVibrationManager.Haptic(HapticTypes.SoftImpact);
                //MoneySystem.Current.money += 20f;
                //HappiniesSystem.Current.happiniesAmount += 0.05f;
                gameObject.SetActive(false);
                //transform.DOPause();
                transform.DOPlay();




            }
            else
            {
                Debug.Log("GondolQueue");
                gondolQueue = true;
                //transform.DOPause();
                transform.DOPause();
            }


        }

        if (other.CompareTag("BatSpin"))
        {
            inBatSpin = true;
            //transform.DOPause();
            if (!BatSpinScript.Current.batSpinFull)
            {
                referenceObject.GetComponent<ReferenceObjectScript>().queue.Remove(gameObject);
                BatSpinScript.Current.batSpinCurrentCount++;
                MMVibrationManager.Haptic(HapticTypes.SoftImpact);
                //MoneySystem.Current.money += 20f;
                //HappiniesSystem.Current.happiniesAmount += 0.05f;
                gameObject.SetActive(false);
                //transform.DOPause();
                transform.DOPlay();




            }
            else
            {
                Debug.Log("OctopusQueue");
                batSpinQueue = true;
                //transform.DOPause();
                transform.DOPause();
            }


        }

        if (other.CompareTag("BumperCar"))
        {
            inBumperCar = true;
            //transform.DOPause();
            if (!BumperCarScript.Current.bumperCarFull)
            {
                referenceObject.GetComponent<ReferenceObjectScript>().queue.Remove(gameObject);
                BumperCarScript.Current.bumberCarCurrentCount++;
                MMVibrationManager.Haptic(HapticTypes.SoftImpact);
                //MoneySystem.Current.money += 20f;
                //HappiniesSystem.Current.happiniesAmount += 0.05f;
                gameObject.SetActive(false);
                //transform.DOPause();
                transform.DOPlay();




            }
            else
            {
                Debug.Log("OctopusQueue");
                bumperCarQueue = true;
                //transform.DOPause();
                transform.DOPause();
            }


        }

        if (other.CompareTag("CrazyDance"))
        {
            inCrazyDance = true;
            //transform.DOPause();
            if (!CrazyDanceScript.Current.crazyDanceFull)
            {
                referenceObject.GetComponent<ReferenceObjectScript>().queue.Remove(gameObject);
                CrazyDanceScript.Current.crazyDanceCurrentCount++;
                MMVibrationManager.Haptic(HapticTypes.SoftImpact);
                //MoneySystem.Current.money += 20f;
                //HappiniesSystem.Current.happiniesAmount += 0.05f;
                gameObject.SetActive(false);
                //transform.DOPause();
                transform.DOPlay();




            }
            else
            {
                Debug.Log("OctopusQueue");
                crazyDanceQueue = true;
                //transform.DOPause();
                transform.DOPause();
            }


        }

        if (other.CompareTag("Swing"))
        {
            inSwing = true;
            //transform.DOPause();
            if (!SwingScript.Current.swingFull)
            {
                referenceObject.GetComponent<ReferenceObjectScript>().queue.Remove(gameObject);
                SwingScript.Current.swingCurrentCount++;
                MMVibrationManager.Haptic(HapticTypes.SoftImpact);
                //MoneySystem.Current.money += 20f;
                //HappiniesSystem.Current.happiniesAmount += 0.05f;
                gameObject.SetActive(false);
                //transform.DOPause();
                transform.DOPlay();




            }
            else
            {
                Debug.Log("SwingQueue");
                swingQueue = true;
                //transform.DOPause();
                transform.DOPause();
            }


        }


        if (other.CompareTag("Character") && referenceObject != null)
        {
            //Debug.Log("PAUSE");
            //transform.DOPause();

            if(referenceObject.GetComponent<ReferenceObjectScript>().queue.IndexOf(gameObject) < referenceObject.GetComponent<ReferenceObjectScript>().queue.IndexOf(other.gameObject))
            {
                behind = other.transform;
            }

            

            
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Character") && referenceObject != null)
        {
            if (other.GetComponent<CharacterController>().inPath)
            {
                Debug.Log("PAUSE");
                if (referenceObject.GetComponent<ReferenceObjectScript>().queue.IndexOf(gameObject) > referenceObject.GetComponent<ReferenceObjectScript>().queue.IndexOf(other.gameObject))
                {
                    transform.DOPause();
                }
            }
           

        }
       
        
       
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Character") && referenceObject != null)
        {
            Debug.Log("EXIT");
            if(referenceObject.GetComponent<ReferenceObjectScript>().queue.IndexOf(gameObject) < referenceObject.GetComponent<ReferenceObjectScript>().queue.IndexOf(other.gameObject))
            {
                
                behind.transform.DOPlay();
            }

           

        }

       
        
    }

    private void OnDisable()
    {


        if (behind != null)
        {
            behind.DOPlay();
            
        }

        //Destroy(gameObject);
    }

    public void EightyPercent(GameObject other)
    {
        randomDecider = Random.Range(1, 6);

        if (randomDecider == 1 || randomDecider == 2 || randomDecider == 3 || randomDecider == 4)
        {
            /*inPath = true;
            transform.DOPath(other.GetComponent<ReferenceObjectScript>().ownWaypoint, 3.5f, PathType.CatmullRom, PathMode.Full3D, 10).SetId("1");

            referenceObject = other.gameObject;
            referenceObject.GetComponent<ReferenceObjectScript>().queue.Add(gameObject);*/

            referenceObject = other.gameObject;

            if(referenceObject.GetComponent<ReferenceObjectScript>().queue.Count <= 7)
            {
                inPath = true;
                transform.DOPath(other.GetComponent<ReferenceObjectScript>().ownWaypoint, 3.5f, PathType.CatmullRom, PathMode.Full3D, 10).SetId("1");

                //referenceObject = other.gameObject;
                referenceObject.GetComponent<ReferenceObjectScript>().queue.Add(gameObject);
            }
            else
            {
                return;
            }





        }
    }

    public void SixtyPercent(GameObject other)
    {
        randomDecider = Random.Range(1, 4);

        if (randomDecider == 1 || randomDecider == 2)
        {
           /* inPath = true;
           transform.DOPath(other.GetComponent<ReferenceObjectScript>().ownWaypoint, 3.5f, PathType.CatmullRom, PathMode.Full3D, 10).SetId("1");

           referenceObject = other.gameObject;
           referenceObject.GetComponent<ReferenceObjectScript>().queue.Add(gameObject);*/

            referenceObject = other.gameObject;

            if (referenceObject.GetComponent<ReferenceObjectScript>().queue.Count <= 7)
            {
                inPath = true;
                transform.DOPath(other.GetComponent<ReferenceObjectScript>().ownWaypoint, 3.5f, PathType.CatmullRom, PathMode.Full3D, 10).SetId("1");

                //referenceObject = other.gameObject;
                referenceObject.GetComponent<ReferenceObjectScript>().queue.Add(gameObject);
            }
            else
            {
                return;
            }




        }
    }

    public void FiftyPercent(GameObject other)
    {
        randomDecider = Random.Range(1, 3);

        if (randomDecider == 1)
        {
            /*inPath = true;
           transform.DOPath(other.GetComponent<ReferenceObjectScript>().ownWaypoint, 3.5f, PathType.CatmullRom, PathMode.Full3D, 10).SetId("1");

           referenceObject = other.gameObject;
           referenceObject.GetComponent<ReferenceObjectScript>().queue.Add(gameObject);*/

            referenceObject = other.gameObject;

            if (referenceObject.GetComponent<ReferenceObjectScript>().queue.Count <= 7)
            {
                inPath = true;
                transform.DOPath(other.GetComponent<ReferenceObjectScript>().ownWaypoint, 3.5f, PathType.CatmullRom, PathMode.Full3D, 10).SetId("1");

                //referenceObject = other.gameObject;
                referenceObject.GetComponent<ReferenceObjectScript>().queue.Add(gameObject);
            }
            else
            {
                return;
            }



        }
    }

    public void SadLeave()
    {
        //transform.Translate(Vector3.zero* 0 * Time.deltaTime);
        //transform.Translate(Vector3.up * 0 * Time.deltaTime);

        transform.DOMove(new Vector3(-10f, transform.position.y, transform.position.z), 30f).SetEase(Ease.Linear).OnComplete(()=>gameObject.SetActive(false));


    }









}
