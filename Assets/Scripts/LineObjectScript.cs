using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
using UnityEngine.EventSystems;
using MoreMountains.NiceVibrations;

public class LineObjectScript : MonoBehaviour
{
    
    [SerializeField] LayerMask layerMask;
    TrailRenderer trail;
    public Vector3[] positions;
    
    public GameObject referenceObject;
    public GameObject referenceObjectExit;
    public GameObject player;
    public GameObject tutorialManager;

    public GameObject crossPrefab;
    public GameObject arrowPrefab;
    public TextMeshProUGUI drawCountText;
    public int drawCount;

    public GameObject circleClipper;

    public bool avaliablePath;

    


    



    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
        drawCount = 3;
        drawCountText.text = drawCount.ToString() + " left";
    }

   
    void Update()
    {
        drawCountText.text = drawCount.ToString() + " left";

        if (EventSystem.current.currentSelectedGameObject == null) //&& LevelController.Current.gameActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                //Debug.Log(Ray Girdi”);
                Vector3 point = hit.point;
                point.z = -0.05f;
                transform.position = point;
                Debug.DrawLine(ray.origin, hit.point);
            }
        }

            




        
        
        if (Input.GetMouseButton(0))
        {
            



            if(drawCount > 0)
            {
                trail.enabled = true;
                MMVibrationManager.Haptic(HapticTypes.MediumImpact);

                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    Destroy(tutorialManager);
                    TutorialManager.Current.blackCanvas.gameObject.SetActive(false);
                }
            }

           






        }
        


       

        if (Input.GetMouseButtonUp(0))
        {

            positions = new Vector3[trail.positionCount];
            trail.GetPositions(positions);
            GameObject reference = Instantiate(referenceObject, positions[0], Quaternion.identity);
            GameObject referenceExit = Instantiate(referenceObjectExit, positions[trail.positionCount - 1], Quaternion.identity);
            trail.Clear();
            trail.enabled = false;

            referenceExit.transform.SetParent(reference.transform);

            //drawCount--;

            if(drawCount <= 0)
            {
                circleClipper.GetComponent<RuntimeCircleClipper>().enabled = false;
            }

            

        }


    }


    
}
