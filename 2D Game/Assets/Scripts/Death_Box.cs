using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Box : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {

        if (other.name == "PC")
        {
            Debug.Log("Player Enters Death Zone");
            Destroy(other);
        }
	}
}
