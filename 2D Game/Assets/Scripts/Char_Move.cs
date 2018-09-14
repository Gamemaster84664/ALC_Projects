using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Move : MonoBehaviour
{
    // Player Movement Variables
    public int MoveSpeed;
    public float JumpHeight;
    public int Sprint;

    // Player Grounded Variables
    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask WhatIsGround;
    private bool grounded;

    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        //This code makes the character jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        //This code makes the character move side to side using A+D
        if (Input.GetKey(KeyCode.D)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                MoveSpeed = MoveSpeed * (3/2);
            }
        }
        if(Input.GetKey(KeyCode.A)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
    }
}
