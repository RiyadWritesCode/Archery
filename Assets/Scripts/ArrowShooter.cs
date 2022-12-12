using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ArrowShooter : MonoBehaviour
{
    [SerializeField] GameObject bowArrow;
    [SerializeField] GameObject arrows;
    [SerializeField] InputAction shootArrow;

    void OnEnable()
    {
        shootArrow.Enable();
    }

    void OnDisable()
    {
        shootArrow.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(shootArrow.triggered == true)
        {
            GameObject launchedArrow = Instantiate(bowArrow, new Vector3(0,7,0), Quaternion.Euler(new Vector3(-90,0,0)), arrows.transform);
            launchedArrow.GetComponent<Rigidbody>().AddRelativeForce(0, -2000, 0);
            launchedArrow.GetComponent<BoxCollider>().isTrigger = false;
            
        }
    }
}
