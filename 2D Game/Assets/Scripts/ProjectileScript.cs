using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float Speed;
    public float HSpeed;
    public float VSpeed;

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
        HSpeed = Mathf.Atan(Input.mousePosition.x - transform.localPosition.x);
        VSpeed = Mathf.Atan(Input.mousePosition.y - transform.localPosition.y);
        GetComponent<Rigidbody2D>().velocity = new Vector2(HSpeed, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, VSpeed);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enimoo") {
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Score_Manager.AddPoints(PointsForKill);
        }

        Instantiate(ProjectileParticle, transform.position, transform.rotation);

    }
}
