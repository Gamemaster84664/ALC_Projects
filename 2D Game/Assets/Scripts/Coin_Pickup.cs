using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Pickup : MonoBehaviour {

    public int pointsToAdd;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Rigidbody2D>() == null)
            return;

            Score_Manager.AddPoints(pointsToAdd);

            Destroy(gameObject);
    }
}
