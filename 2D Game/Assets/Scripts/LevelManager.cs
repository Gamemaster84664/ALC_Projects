using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject CurrentCheckpoint;

    public Rigidbody2D PC;

    public GameObject PC2;

    public GameObject Gun;

    public GameObject Rocket;

    // Particles
    public GameObject DeathParticle;

    public GameObject RespawnParticle;

    // Respawn Delay
    public float RespawnDelay;

    // Point Penalty on Death
    public int PointPenaltyOnDeath;

    // Store Gravity Value
    private float GravityStore;

	// Use this for initialization
	void Start () {
        // PC = FindObjectOfType<Rigidbody2D>();
        PC = GameObject.Find("PC").GetComponent<Rigidbody2D>();
        PC2 = GameObject.Find("PC");
        Gun = GameObject.Find("Gun");
        Rocket = GameObject.Find("FixedRocketman");
        DeathParticle = Resources.Load("Prefabs/DeathP") as GameObject;
        RespawnParticle = Resources.Load("Prefabs/RespawnP") as GameObject;
	}
	
    public void RespawnPlayer() {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo() {
        // Generate Death Particle
        Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation);
        // Hide Player
        // PC.enabled = false;
        PC2.SetActive(false);
        Gun.SetActive(false);
        Rocket.SetActive(false);
        PC.GetComponent<Renderer>().enabled = false;
        // Gravity Reset
        GravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
        PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
        PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // Point Penalty
        PointPenaltyOnDeath = 10;
        Score_Manager.AddPoints(-PointPenaltyOnDeath);
        // Debug Message
        Debug.Log("Player Respawn");
        // Respawn Delay
        yield return new WaitForSeconds(RespawnDelay);
        // Gravity Restore
        PC.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
        // Match Players transform position
        PC.transform.position = CurrentCheckpoint.transform.position;
        // Show Player
        // PC.enabled = true;
        PC2.SetActive(true);
        Gun.SetActive(true);
        Rocket.SetActive(true);
        PC.GetComponent<Renderer>().enabled = true;
        // Spawn Player
        Instantiate (RespawnParticle, CurrentCheckpoint.transform.position, CurrentCheckpoint.transform.rotation);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
