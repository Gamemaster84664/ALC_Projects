using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartScript : MonoBehaviour {

    public Transform Target;
    public float PartOffset;
    public bool OnStart;

	// Use this for initialization
	void Start () {
        if (OnStart)
        {
            transform.position = Target.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!OnStart)
        {
            transform.position = new Vector3(Target.position.x, Target.position.y - PartOffset, Target.position.z);
        }
	}
}
