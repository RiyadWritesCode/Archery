using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movementInput;
    [SerializeField] InputAction jumpInput;

    public Animator playerAnimator;

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

    PlaySounds PlaySounds;

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

        PlaySounds = FindObjectOfType<PlaySounds>();
    }

    void Update()
    {
        // ground check
        //grounded = Physics.Raycast(playerMesh.transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        grounded = Physics.SphereCast(playerMesh.transform.position, 2.31f, Vector3.down, out hit, playerHeight * 0.5f + 0.2f, whatIsGround);

        // handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }

        if (rb.velocity.y < startDownForce && !grounded)
        {
            rb.AddForce(new Vector3(0, -18f, 0));
        }
        
        //Play run sounds
        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (grounded)
            {
                if (!PlaySounds.run.isPlaying)
                {
                    PlaySounds.playRun();

                }
            }
            else if (!grounded)
            {
                if (PlaySounds.run.isPlaying)
                {
                    PlaySounds.stopRun();
                    
                }
            }
        }

        else if (horizontalInput == 0 && verticalInput == 0)
        {
            if (PlaySounds.run.isPlaying)
            {
                PlaySounds.stopRun();
            }
            
        }

        //Play animations

        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (grounded && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerMove"))
            {
                playerAnimator.SetBool("walking", true);
            }
        }

        else if (horizontalInput == 0 && verticalInput == 0)
        {
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerMove"))
            {
                playerAnimator.SetBool("walking", false);
            }
        }

        if (!grounded)
        {
            playerAnimator.SetBool("walking", false);
            if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerJump"))
            {
                playerAnimator.SetBool("jumping", true);
            }
        }
        else if (grounded)
        {
            playerAnimator.SetBool("jumping", false);
        }
    }

    void MyInput()
    {
        horizontalInput = movementInput.ReadValue<Vector2>().x;
        verticalInput = movementInput.ReadValue<Vector2>().y;

        //when to jump
        if (jumpInput.IsPressed() && grounded)
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

        PlaySounds.playJump();
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        MyInput();
        SpeedControl();
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
