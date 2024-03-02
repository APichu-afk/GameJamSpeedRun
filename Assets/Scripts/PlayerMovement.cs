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

    public float stunTimer;
    public float stunLength;
    private float stunSpeed = 0.0f;
    private bool stunCheck = false;
    public float stunDestroy = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        activeSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Stun();
        Dash();
    }

    public void Stun()
    {
        if (stunCheck)
        {
            stunTimer = stunLength;
            activeSpeed = stunSpeed;
            stunCheck = false;
        }

        if(stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0)
            {
                activeSpeed = movementSpeed;
            }
        }
        
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stun")
        {
            stunCheck = true;
        }
    }
}
