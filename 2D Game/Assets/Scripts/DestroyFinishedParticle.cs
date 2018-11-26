using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour {

    private ParticleSystem thisParticleSystem;
    public float TimeOut;

	// Use this for initialization
	void Start () {
        thisParticleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, TimeOut);
	}
	
	// Update is called once per frame
	void Update () {
        if (thisParticleSystem.isPlaying)
        {
            return;
        }
        Destroy(gameObject);
	}

	void OnBecameInvisible()
	{
        Destroy(gameObject);
	}
}
