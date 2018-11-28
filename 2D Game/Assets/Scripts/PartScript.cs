using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartScript : MonoBehaviour {

    private Transform Target;
    public float PartOffset;
    public bool OnStart;

	// Use this for initialization
	void Start () {
        Target = Resources.Load("Prefabs/PC") as Transform;
        transform.position = Target.position;
	}

    // Update is called once per frame
    void Update() {
        transform.position = new Vector2(Target.position.x, Target.position.y - PartOffset);
    }
}
