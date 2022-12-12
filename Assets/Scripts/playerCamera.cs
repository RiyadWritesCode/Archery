using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCamera : MonoBehaviour
{
    //[SerializeField] InputAction playerMovement;

    [SerializeField] float xSensitivity;
    [SerializeField] float ySensitivity;

    public Transform player;
    public Transform playerMesh;

    float xRotation;
    float yRotation;


    //private void OnEnable()
    //{
    //    playerMovement.Enable();
    //}

    //private void OnDisable()
    //{
    //    playerMovement.Disable();
    //}

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Vector2 movement = playerMovement.ReadValue<Vector2>();
        //Debug.Log(movement.x);
        //Debug.Log(movement.y);

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerMesh.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        player.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
