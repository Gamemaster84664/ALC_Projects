using System;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float Speed;
    public float HSpeed;
    public float VSpeed;
    public float Dir;
    public float TimeOut;

    public GameObject PC;
    public GameObject FirePoint;
    public GameObject EnemyDeath;
    public GameObject Gun;
    public GameObject ProjectileParticle;

    public int PointsForKill;

    // Use this for initialization
    void Start()
    {
        PC = GameObject.Find("PC");

        FirePoint = GameObject.Find("FirePoint");

        Gun = GameObject.Find("Gun");

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        System.Random randy = new System.Random();
        Dir = (Gun.GetComponent<GunShtuff>().Dir + randy.Next(-5, 5)) * Mathf.Deg2Rad;

        HSpeed = Speed * Mathf.Cos(Dir);
        VSpeed = Speed * Mathf.Sin(Dir);

        // Destroys projectile after X seconds

    }

    // Update is called once per frame
    void Update()
    {


        GetComponent<Rigidbody2D>().velocity = new Vector2(HSpeed,VSpeed);

        //Destroy(gameObject, TimeOut);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Score_Manager.AddPoints(PointsForKill);
        }

        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        //Destroy(gameObject);
    }

	void OnCollisionEnter2D(Collision2D other)
	{
        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        //Destroy(gameObject);
	}
}
