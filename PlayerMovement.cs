using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody rb;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public int jumpCount = 3;

    public float dashSpeed = 10f;

    public GunController theGun;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;

    Vector3 velocity = new Vector3();
    bool isGrounded;
    bool canJump;
    int remainingJumps = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        theGun.isFiring = false;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            remainingJumps = jumpCount;
            velocity.y = -2f;

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && (isGrounded || canJump))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            remainingJumps--;
            canJump = remainingJumps > 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && (isGrounded = false))
        {
            rb.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) 
            theGun.isFiring = true;

        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;

    }
}

// remember to set all undefined variables such as groundDistance