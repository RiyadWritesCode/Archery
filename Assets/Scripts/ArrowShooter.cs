using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Newtonsoft.Json.Linq;

public class ArrowShooter : MonoBehaviour
{
    public GameObject bowArrow;
    public GameObject arrowContainer;
    public GameObject arrow;

    public int arrowSpeed;
    public float drawCooldown;
    public bool readyToDraw = true;
    public float percentageDraw;

    public InputAction shootInput;

    PlayerCamera playerCamera;

    int arrowNumber = 0;
    List<GameObject> launchedArrows = new List<GameObject>();

    void OnEnable()
    {
        shootInput.Enable();
    }

    void OnDisable()
    {
        shootInput.Disable();
    }

    void Start()
    {
        playerCamera = FindObjectOfType<PlayerCamera>();
    }

    void Update()
    {

    }

    public void ResetShoot()
    {
        readyToDraw = true;
    }

    public void ShootArrow()
    {
        // Instantiating arrow and storing into array
            launchedArrows.Add(Instantiate(arrow, bowArrow.transform.position, Quaternion.Euler(bowArrow.transform.eulerAngles), arrowContainer.transform));

        if (percentageDraw > 1)
        {
            percentageDraw = 1;
        }

        Debug.Log(percentageDraw);

        // Shooting in camera direction
        launchedArrows[arrowNumber].GetComponent<Rigidbody>().AddForce(playerCamera.player.transform.forward * arrowSpeed * percentageDraw);

        arrowNumber++;
        readyToDraw = false;
        Invoke("ResetShoot", drawCooldown);
    }
}
