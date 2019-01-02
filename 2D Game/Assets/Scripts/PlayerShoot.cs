using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public Transform FirePoint;
    public GameObject Projectile;
    public float veer;
    public int rounds;
    public string state;

	void Start()
	{
        Projectile = Resources.Load("Prefabs/Projectile") as GameObject;
        FirePoint = null;
        veer = 0;
	}

	// Update is called once per frame
	void Update () {

        System.Random randy = new System.Random();

        state = GameObject.Find("Gun").GetComponent<GunShtuff>().state;

        if (GameObject.Find("Gun").GetComponent<GunShtuff>().FirePoint != null)
        {
            FirePoint = GameObject.Find("Gun").GetComponent<GunShtuff>().FirePoint.transform;

            if (Input.GetKeyDown(KeyCode.W))
            {
                if (state == "AR")
                {
                    //for (int i = rounds; i > 0; i -= 1)
                    //{
                    randy.Next(-1, 1);
                    Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
                    //}
                }
                if (state == "SG")
                {
                    veer = randy.Next(-40, 40);
                    Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
                    veer = randy.Next(-40, 40);
                    Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
                    veer = randy.Next(-40, 40);
                    Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
                    veer = randy.Next(-40, 40);
                    Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
                }
            }
        }
	}
}
