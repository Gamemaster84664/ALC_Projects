using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartScript : MonoBehaviour {

    public GameObject Target;
    public float PartOffset;
    public bool OnStart;

	// Use this for initialization
	void Start () {
        Target = GameObject.Find("PC");
        transform.position = Target.GetComponent<Rigidbody2D>().position;
	}

    // Update is called once per frame
    void Update() {
        transform.position = new Vector2(Target.GetComponent<Rigidbody2D>().position.x, Target.GetComponent<Rigidbody2D>().position.y - PartOffset);
    }
}
