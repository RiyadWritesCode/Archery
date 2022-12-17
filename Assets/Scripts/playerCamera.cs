using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    public InputAction cameraInput;

    [SerializeField] float xSensitivity;
    [SerializeField] float ySensitivity;

    public Transform player;
    public Transform playerMesh;

    float xRotation;
    float yRotation;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;

        //float mouseX = cameraInput.ReadValue<Vector2>().x * Time.deltaTime * xSensitivity;
        //float mouseY = cameraInput.ReadValue<Vector2>().y * Time.deltaTime * ySensitivity;


        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerMesh.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        player.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
