using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag == "Box")
        {
            other.GetComponent<Rigidbody2D>().velocity += GetComponent<Rigidbody2D>().velocity;
        }
	}
}
