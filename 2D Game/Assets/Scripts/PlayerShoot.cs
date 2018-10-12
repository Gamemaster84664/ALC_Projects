﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public Transform FirePoint;
    public GameObject Projectile;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)) {
            Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
        }
	}
}
