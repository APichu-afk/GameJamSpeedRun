using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rB2D;
    public float movementSpeed;
    private Vector2 moveInput;
    private float activeSpeed;

    public float dashSpeed;
    private float dashLength = 0.5f;
    public float dashCounter;
    // Start is called before the first frame update
    void Start()
    {
        activeSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Dash();
    }

    public void Movement() 
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        moveInput.Normalize();

        rB2D.velocity = moveInput * activeSpeed;
    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activeSpeed = dashSpeed;
            dashCounter = dashLength;
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeSpeed = movementSpeed;
            }
        }
    }
}
