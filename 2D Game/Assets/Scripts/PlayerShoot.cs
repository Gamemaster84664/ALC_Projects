using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    public Transform FirePoint;
    public GameObject Projectile;
    public float veer;
    public string state;

    Text GunText;

	void Start()
	{
        Projectile = Resources.Load("Prefabs/Projectile") as GameObject;
        FirePoint = null;
        veer = 0;
        GunText = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
        
        System.Random randy = new System.Random();

        state = GameObject.Find("Gun").GetComponent<GunShtuff>().state;

        if (state == "AR") {
            GunText.text = "Assault Rifle";
        }
        if (state == "SG") {
            GunText.text = "Shotgun";
        }

        if (GameObject.Find("Gun").GetComponent<GunShtuff>().FirePoint != null)
        {
            FirePoint = GameObject.Find("Gun").GetComponent<GunShtuff>().FirePoint.transform;

            if (Input.GetKeyDown(KeyCode.W))
            {
                if (state == "AR")
                {
                        veer = randy.Next(-1, 1);
                        Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
                }
                if (state == "SG")
                {
                    Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
                    veer = randy.Next(-10, 10);
                    Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
                    veer = randy.Next(-10, 10);
                    Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
                    veer = randy.Next(-10, 10);
                    Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
                    veer = randy.Next(-10, 10);
                }
            }
        }
	}
}
