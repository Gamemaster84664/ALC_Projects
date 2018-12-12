using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Move : MonoBehaviour
{
    // Player Movement Variables
    public int MoveSpeed;
    public float JumpHeight;
    public float Fuel;
    public float MaxFuel;
    public float FuelUsage;
    public float packStrength;

    // Player Grounded Variables
    public Transform GroundCheck;
    public Transform JetPosition;
    public Transform GunPos;
    public float GroundCheckRadius;
    public float JetOffset;
    public LayerMask WhatIsGround;
    private bool grounded;

    // Non-Stick Player
    private float moveVelocity;

    // Jet Fire
    public GameObject JetFire;

    public Animator animator;

    // Use this for initialization
    void Start()
    {
        // Animation reset
        animator.SetBool("isMoving", false);

        Fuel = MaxFuel;

        JetFire = Resources.Load("Prefabs/JetP") as GameObject;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        // This code makes the character jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if (grounded)
        {
            Fuel += FuelUsage * 2;
        }

        //Gun moves it's butt over here
        GunPos.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);

        JetPosition.position = new Vector3(transform.position.x - 15, transform.position.y - 10, transform.position.z);

        Jet();

        // Double jump code


        // Non-Stick Player
        moveVelocity = 0f;

        // This code makes the character move side to side using A+D
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = MoveSpeed;
            animator.SetBool("isMoving", true);
        }
        else if (Input.GetKeyUp(KeyCode.D)){
            animator.SetBool("isMoving", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -MoveSpeed;
            animator.SetBool("isMoving", true);
        }
        else if(Input.GetKeyUp(KeyCode.A)){
            animator.SetBool("isMoving", false);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
    }

    public void Jet()
    {
        if (Fuel > MaxFuel)
        {
            Fuel = MaxFuel;
        }
        if (!grounded)
        {
            if (Fuel > 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y + packStrength);
                    JetPosition.position = new Vector3(transform.position.x, transform.position.y - JetOffset, transform.position.z);
                    Instantiate(JetFire);
                    Fuel -= FuelUsage;
                    animator.SetBool("isMoving", true);
                }
                else if (Input.GetKeyUp(KeyCode.Space)){
                    animator.SetBool("isMoving", false);
                }
            }
        }
    }
}
