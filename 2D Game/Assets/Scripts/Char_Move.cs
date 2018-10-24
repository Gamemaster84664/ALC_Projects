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
    public float GroundCheckRadius;
    public LayerMask WhatIsGround;
    private bool grounded;

    // Non-Stick Player
    private float moveVelocity;

    // Jet Fire
    public GameObject JetFire;

    // Use this for initialization
    void Start()
    {
        Fuel = MaxFuel;
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

        Jet();

        // Double jump code
        if (grounded)
        {
            Fuel += FuelUsage * 2;
        }

        // Non-Stick Player
        moveVelocity = 0f;

        // This code makes the character move side to side using A+D
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = MoveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -MoveSpeed;
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
                    Instantiate(JetFire);
                    Fuel -= FuelUsage;
                }
            }
        }
    }
}
