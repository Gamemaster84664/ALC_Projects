using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour {

    public static float Fuel;
    Text FuelText;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        FuelText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Fuel = Player.GetComponent<Char_Move>().Fuel;
        transform.localScale = new Vector3(4000f,25000*Fuel/50,1f);

	}
}
