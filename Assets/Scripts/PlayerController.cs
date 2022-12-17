using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movementInput;
    [SerializeField] InputAction jumpInput;

    public float moveSpeed;
    public GameObject playerMesh;

    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public int jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;
    public int startDownForce;
    public float airDrag;

    Vector3 moveDirection;
    Vector2 movement;

    float verticalInput;
    float horizontalInput;

    Rigidbody rb;
    RaycastHit hit;

    private void OnEnable()
    {
        movementInput.Enable();
        jumpInput.Enable();
    }

    private void OnDisable()
    {
        movementInput.Disable();
        jumpInput.Disable();
    }
    void Start()
    {
        rb = playerMesh.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // ground check
        grounded = Physics.Raycast(playerMesh.transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        //grounded = Physics.SphereCast(playerMesh.transform.position, 4f, Vector3.down, out hit, playerHeight * 0.5f + 0.2f, whatIsGround);

        // handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }

        MyInput();
        SpeedControl();

        if (rb.velocity.y < startDownForce && !grounded)
        {
            rb.AddForce(new Vector3(0, -18f, 0));
        }
    }

    void MyInput()
    {
        horizontalInput = movementInput.ReadValue<Vector2>().x;
        verticalInput = movementInput.ReadValue<Vector2>().y;


        //when to jump
        if (jumpInput.IsPressed() && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // calculate movement direction
        moveDirection = playerMesh.transform.forward * verticalInput + playerMesh.transform.right * horizontalInput;

        if (grounded)
        {
            rb.AddForce(moveDirection * moveSpeed * 10f, ForceMode.Force);
        }

        else if (!grounded)
        {
            rb.AddForce(moveDirection * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }   
    }
}
