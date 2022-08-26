using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    TrailRenderer line;
    public Vector3[] positions;

    void Start()
    {
        line = GetComponent<TrailRenderer>();
        line.enabled = false;
    }

    
    void Update()
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

        if (Input.GetMouseButton(0))
        {
            line.enabled = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            positions = new Vector3[line.positionCount];
            line.GetPositions(positions);
            
            //line.enabled = false;
        }
    }
}
