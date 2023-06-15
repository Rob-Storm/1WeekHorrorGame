using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public new CapsuleCollider collider;

    [Header("Move Speeds")]
    public float moveSpeed;
    public float walkingMoveSpeed = 3.5f, runningMoveSpeed = 6f;
    public float gravity = -9.81f;
    public bool canSprint = false;

    [Header("Ground Collision Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded = false;

    public PauseMenu pauseMenu;

    private void Start()
    {
        moveSpeed = walkingMoveSpeed;
    }


    // Update is called once per frame
    void Update()
    {       
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded && canSprint)
        {
            moveSpeed = runningMoveSpeed;
        }
        else
        {
            moveSpeed = walkingMoveSpeed;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
