using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Stats")]
    [SerializeField] float originalSpeed = 12;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeigh = 3;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [SerializeField] GameObject playerCamera;
    [SerializeField] float mouseSensitivity = 10;

    float currentSpeed;
    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;

    Animator cameraAnimator; //Activate later

    void Start()
    {
        currentSpeed = originalSpeed;
        controller = GetComponent<CharacterController>();
        cameraAnimator = playerCamera.GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }    

    void Update()
    {
        ApplyGravity();
        MoveCharacter();
        MouseLook();
    }

    void OnDamageTaken()
    {
        //
    }

    private void ApplyGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void MoveCharacter()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * movementX + transform.forward * movementZ;
        controller.Move(move * currentSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeigh * -2 * gravity);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = originalSpeed * 2;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = originalSpeed;
        }
    }

    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(new Vector3(0f, mouseX * mouseSensitivity, 0f) * Time.deltaTime, Space.Self);
    }
} 