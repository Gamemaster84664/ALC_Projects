using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShtuff : MonoBehaviour {

    public Transform PlayerPosition;
    public float XOffset;
    public float YOffset;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
        GetComponent<Rigidbody2D>().position = new Vector2(PlayerPosition.position.x + XOffset, PlayerPosition.position.y + YOffset);
	}
}
