using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float originalSpeed = 12;
    float currentSpeed;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeigh = 3;

    public float mouseSensitivity = 10;
    float xRot = 0;

    bool isGrounded;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] GameObject playerCamera;
    Animator cameraAnimator;

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

    private void LateUpdate()
    {
       
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

        /*if(move.x > .1f || move.z > .1f)
        {
            print("moving");
            cameraAnimator.SetBool("isMoving", true);
        }
        else
        {
            cameraAnimator.SetBool("isMoving", false);
            print(" not moving");
        }*/
    }

    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(new Vector3(0f, mouseX * mouseSensitivity, 0f) * Time.deltaTime, Space.Self);
        //playerBody.Rotate(Vector3.up * mouseX);
    }
} 