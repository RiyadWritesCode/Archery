using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToCursor : MonoBehaviour
{
    public GameObject bow;
    public GameObject cam;

    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit);
        Debug.DrawRay(cam.transform.position, cam.transform.forward);


        if(hit.point != new Vector3(0,0,0) && hit.distance > 15)
        {
            bow.transform.LookAt(hit.point);
        }
    }
}
