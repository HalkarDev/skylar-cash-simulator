using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Big script regarding everything related to player movement and associated things (footsteps sounds, rotation, etc.)

    [Header("Stats")]
    [SerializeField] private float ogSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float airSpeed;
    [SerializeField] private float sprintAirSpeed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private float airDrag;
    [SerializeField] private float groundDrag;
    public static float Sens;


    [Header("Input")]
    private float mouseX;
    private float mouseY;
    public static float RotationX;
    public static float RotationY;

    private float horizontalInput;
    private float verticalInput;


    [Header("State")]
    public static bool isCrouching;
    public static bool isSprinting;
    private bool flashlightOn;
    private bool isJumping;


    [Header("Audio")]
    [SerializeField] private AudioSource flashlightSound;
    [SerializeField] private AudioSource resonance;
    [SerializeField] private GameObject footsteps;
    [SerializeField] private GameObject sprintFootsteps;
    [SerializeField] private GameObject crouchFootsteps;

    [SerializeField] private GameObject grassFootsteps;
    [SerializeField] private GameObject grassSprintFootsteps;
    [SerializeField] private GameObject grassCrouchFootsteps;



    [Header("UI")]
    [SerializeField] private GameObject sprint;
    [SerializeField] private GameObject crouch;


    [Header("Other")]
    [SerializeField] private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 slopeMoveDirection;
    public Transform Orientation;
    public static bool IsGrounded;
    public static bool IsGrassed;
    private bool onSlope;
    public LayerMask WhatIsGround;
    public LayerMask WhatIsGrass;
    private RaycastHit hit;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private GameObject cameraPosition;
    private RaycastHit raySelectionHit;
    public static string RayTag;
    public static float DistanceFromTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }



    private void Update()
    {
        //forward, backward, side, and rotation input input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        RotationX -= mouseY * Time.deltaTime * Sens;
        RotationY += mouseX * Time.deltaTime * Sens;

        RotationX = Mathf.Clamp(RotationX, -90, 90);

        transform.rotation = Quaternion.Euler(0, RotationY, 0);

        moveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;

        //checks if player is on ground
        IsGrounded = Physics.CheckSphere(transform.position, 1.1f, WhatIsGround);
        IsGrassed = Physics.CheckSphere(transform.position, 1.1f, WhatIsGrass);


        //speed and drag
        if (IsGrounded || IsGrassed)
        {
            rb.drag = groundDrag;
            if (isSprinting)
            {
                speed = sprintSpeed;

            }
            else
            {
                speed = ogSpeed;
            }
        }
        else if (!IsGrounded && !IsGrassed)
        {
            if (isSprinting)
            {
                speed = sprintAirSpeed;
            }
            else
            {
                speed = airSpeed;
            }
            rb.drag = airDrag;
        }
        //slope movement
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.normal != Vector3.up)
            {
                onSlope = true;
            }
            else
            {
                onSlope = false;
            }
        }

        if (onSlope)
        {
            slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, hit.normal);
        }

        //crouching, sprinting
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching && (IsGrounded || IsGrassed))
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetButton("Horizontal") == false && Input.GetButton("Vertical") == false))
        {
            isSprinting = false;
        }
        if (Input.GetKey(KeyCode.C))
        {
            isSprinting = false;
            isCrouching = true;
            transform.localScale = new Vector3(1.5f, .5f, 1.5f);
            speed = crouchSpeed;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            isCrouching = false;
            transform.localScale = new Vector3(1.5f, 1, 1.5f);
            speed = ogSpeed;
        }

        //controls small crouching and sprinting panels above health bar
        if (isCrouching)
        {
            crouch.SetActive(true);
        }
        else
        {
            crouch.SetActive(false);
        }
        if (isSprinting)
        {
            sprint.SetActive(true);
        }
        else
        {
            sprint.SetActive(false);
        }


        //flashlight
        if (Input.GetKeyDown(KeyCode.F) && !flashlightOn)
        {
            flashlightSound.Play();
            flashlightOn = true;
            flashlight.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.F) && flashlightOn)
        {
            flashlightSound.Play();
            flashlightOn = false;
            flashlight.SetActive(false);
        }
        flashlight.transform.rotation = Quaternion.Euler(PlayerMovement.RotationX, PlayerMovement.RotationY, 0);
        if (Input.GetKeyDown(KeyCode.G))
        {
            Health.Health1--;
        }

        //jump
        if (Input.GetButtonDown("Jump") && !isJumping && !isCrouching & (IsGrounded || IsGrassed))
        {
            StartCoroutine(Jump());
        }



        Ray raySelection = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(raySelection, out raySelectionHit))
        {
            DistanceFromTarget = raySelectionHit.distance;
            RayTag = raySelectionHit.transform.tag;
        }



        //normal footsteps sounds
        if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && PlayerMovement.IsGrounded)
        {
            if (!PlayerMovement.isSprinting && !PlayerMovement.isCrouching)
            {
                footsteps.SetActive(true);
                sprintFootsteps.SetActive(false);
                crouchFootsteps.SetActive(false);
            }
            if (PlayerMovement.isSprinting)
            {
                footsteps.SetActive(false);
                sprintFootsteps.SetActive(true);
                crouchFootsteps.SetActive(false);
            }
            if (PlayerMovement.isCrouching)
            {
                footsteps.SetActive(false);
                sprintFootsteps.SetActive(false);
                crouchFootsteps.SetActive(true);
            }
        }
        else if ((!Input.GetButton("Horizontal") && !Input.GetButton("Vertical")) || (!IsGrounded && !IsGrassed))
        {
            footsteps.SetActive(false);
            sprintFootsteps.SetActive(false);
            crouchFootsteps.SetActive(false);
            grassFootsteps.SetActive(false);
            grassSprintFootsteps.SetActive(false);
            grassCrouchFootsteps.SetActive(false);
        }

        //grass footsteps sounds
        if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && PlayerMovement.IsGrassed)
        {
            if (!PlayerMovement.isSprinting && !PlayerMovement.isCrouching)
            {
                grassFootsteps.SetActive(true);
                grassSprintFootsteps.SetActive(false);
                grassCrouchFootsteps.SetActive(false);
            }
            if (PlayerMovement.isSprinting)
            {
                grassFootsteps.SetActive(false);
                grassSprintFootsteps.SetActive(true);
                grassCrouchFootsteps.SetActive(false);
            }
            if (PlayerMovement.isCrouching)
            {
                grassFootsteps.SetActive(false);
                grassSprintFootsteps.SetActive(false);
                grassCrouchFootsteps.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("Day", DayWeek.Day);
            PlayerPrefs.SetInt("Week", DayWeek.week);
            SceneManager.LoadScene(0);
        }
    }
    //coroutine for whenever the player presses spacebar
    IEnumerator Jump()
    {
        isJumping = true;
        rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        yield return new WaitForSeconds(1);
        isJumping = false;
    }

    //adds force according to movement keys
    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * speed, ForceMode.Impulse);
        if (onSlope)
        {
            rb.AddForce(slopeMoveDirection * speed, ForceMode.Impulse);
        }
    }
}
