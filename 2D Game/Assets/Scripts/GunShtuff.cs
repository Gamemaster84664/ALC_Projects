using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShtuff : MonoBehaviour {

    public Transform PlayerPosition;
    public float XOffset;
    public float YOffset;
    public float Dir;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void LateUpdate()
    {

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Dir = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg;
        if (Mathf.Abs(Dir) > 90)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        GetComponent<Rigidbody2D>().rotation = Dir;

    }
}
