using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public float Speed;

    public Rigidbody2D Player;

    public GameObject EnemyDeath;

    public GameObject ProjectileParticle;

    public int PointsForKill;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
        if (Player.transform.localScale.x < 0)
            Speed = -Speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enimoo") {
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Score_Manager.AddPoints(PointsForKill);
        }

        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
