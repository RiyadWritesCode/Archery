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

    public InputAction shootArrow;

    playerCamera playerCamera;
    GameObject launchedArrow;

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
        playerCamera = FindObjectOfType<playerCamera>();
    }

    void Update()
    {
        if (shootArrow.triggered == true)
        {
            launchedArrow = Instantiate(
                arrow,
                new Vector3(bowArrow.transform.position.x, bowArrow.transform.position.y, bowArrow.transform.position.z),
                Quaternion.Euler(bowArrow.transform.eulerAngles),
                arrowContainer.transform);
            launchedArrow.GetComponent<Rigidbody>().AddForce(playerCamera.player.transform.forward * 2000);

        }

    }
}
