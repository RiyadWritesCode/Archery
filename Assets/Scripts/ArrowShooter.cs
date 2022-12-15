using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ArrowShooter : MonoBehaviour
{
    public GameObject bowArrow;
    public GameObject arrowContainer;
    public GameObject arrow;

    public int arrowSpeed;

    public InputAction shootArrow;

    PlayerCamera playerCamera;

    int arrowNumber = 0;
    List<GameObject> launchedArrows = new List<GameObject>();

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
        playerCamera = FindObjectOfType<PlayerCamera>();
    }

    void Update()
    {
        if (shootArrow.triggered == true)
        {
            //Instantiating arrow and storing into array
            launchedArrows.Add(Instantiate(arrow, bowArrow.transform.position, Quaternion.Euler(bowArrow.transform.eulerAngles), arrowContainer.transform));


            //Shooting in camera direction
            launchedArrows[arrowNumber].GetComponent<Rigidbody>().AddForce(playerCamera.player.transform.forward * arrowSpeed);

            arrowNumber++;
        }

    }
}
