using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 4f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHaigth=3f;

    public Transform groundCheck;
    public float groundDistance=0.4f;
    public LayerMask groundMask;
    bool isground;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    } 
    // Update is called once per frame
    void Update()
    {
        isground = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isground && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
     
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isground)
        {
            velocity.y = Mathf.Sqrt(jumpHaigth * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
