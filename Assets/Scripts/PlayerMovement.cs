using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Rat;
    public Animator ratMoveAnim;
    //Walking variables
    public Rigidbody2D rB2D;
    public float movementSpeed;
    private Vector2 moveInput;
    public float activeSpeed;

    //Dashing variables
    public float dashSpeed;
    public float dashTime;
    private float dashLength = 0.5f;
    public float dashTimer;
    public int dashCounter;
    private int dashCounterMax = 3;

    //Stun variables
    public float stunTimer;
    public float stunLength;
    private float stunSpeed = 0.0f;
    private bool stunCheck = false;
    public float stunDestroy = 0.5f;

    //SFX variables
    public AudioSource src1, src2;
    public AudioClip sfx1, sfx2, sfx3;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize movement and dashing values
        activeSpeed = movementSpeed;
        dashCounter = dashCounterMax;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Stun();
        Dash();
    }

    //Stun code
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
                ratMoveAnim.SetBool("Dizzy", false);
                ratMoveAnim.SetBool("Dashing", false);
            }
        }
    }

    //Movement code
    public void Movement() 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Rat.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Rat.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        moveInput.Normalize();

        rB2D.velocity = moveInput * activeSpeed;
    }

    //Dashing code
    public void Dash()
    {
        //Add dashes for the player
        if (dashCounter < dashCounterMax) 
        {
            dashTimer += Time.deltaTime;
            if(dashTimer >= 1) 
            {
                dashCounter += 1;
                dashTimer = 0;
            }
        }

        //Code for dashing on button press
        if (Input.GetKeyDown(KeyCode.Space) && stunTimer <= 0)
        {
            src1.PlayOneShot(sfx1);
            ratMoveAnim.SetBool("Dashing", true);
            activeSpeed = dashSpeed;
            dashTime = dashLength;
            dashCounter -= 1;
            //code for stunning player when they dash too much
            if (dashCounter <= 0)
            {
                stunCheck = true;
                ratMoveAnim.SetBool("Dizzy", true);
                dashCounter = dashCounterMax;
                dashTimer = 0;
                src2.PlayOneShot(sfx2);
            }
        }

        //Code for changing speed of the player
        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime;
            

            if (dashTime <= 0 && stunTimer <= 0)
            {
                activeSpeed = movementSpeed;
                ratMoveAnim.SetBool("Dashing", false);
            }
        }
    }
    //collision check for stun
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stun")
        {
            src2.PlayOneShot(sfx2);
            stunCheck = true;
            ratMoveAnim.SetBool("Dizzy", true);
        }
    }
}
