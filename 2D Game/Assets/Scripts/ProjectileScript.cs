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
    public GameObject Coin;

    public int PointsForKill;

    // Use this for initialization
    void Start()
    {
        PC = GameObject.Find("PC");

        FirePoint = GameObject.Find("FirePoint");

        Gun = GameObject.Find("Gun");

        EnemyDeath = Resources.Load("Prefabs/DeathP") as GameObject;
        ProjectileParticle = Resources.Load("Prefabs/ShootP") as GameObject;
                                      
        System.Random randy = new System.Random();
        Dir = (Gun.GetComponent<GunShtuff>().Dir + randy.Next(-3, 3)) * Mathf.Deg2Rad;

        Speed = 25;

        HSpeed = Speed * Mathf.Cos(Dir);
        VSpeed = Speed * Mathf.Sin(Dir);

        TimeOut = 5;

        // Destroys projectile after X seconds
        Destroy(gameObject, TimeOut);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(HSpeed,VSpeed);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Instantiate(Coin, other.transform.position, other.transform.rotation);
            Score_Manager.AddPoints(PointsForKill);
        }
        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
	void OnCollisionEnter2D(Collision2D other)
	{
        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        Destroy(gameObject);
	}
}
