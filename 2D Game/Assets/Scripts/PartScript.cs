using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartScript : MonoBehaviour {

    public Transform Target;
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
            transform.position = Target.position;
        }
	}
}
