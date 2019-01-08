using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShtuff : MonoBehaviour {

    public Transform PlayerPosition;
    public Sprite assaultRifle;
    public Sprite shotgun;
    public SpriteRenderer spriteRenderer;
    public GameObject FirePoint;
    public GameObject ARFirePoint;
    public GameObject SGFirePoint;
    public float XOffset;
    public float YOffset;
    public float Dir;
    public float Scale;
    public float ARScale;
    public float SGScale;
    public string state;

	// Use this for initialization
	void Start () {
        Scale = transform.localScale.x;
        state = "AR";
        spriteRenderer = GetComponent<SpriteRenderer>();
        FirePoint = ARFirePoint;
	}

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            state = "AR";
            spriteRenderer.sprite = assaultRifle;
            Scale = ARScale;
            FirePoint = ARFirePoint;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            state = "SG";
            spriteRenderer.sprite = shotgun;
            Scale = SGScale;
            FirePoint = SGFirePoint;
        }


        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Dir = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg;
        if (Mathf.Abs(Dir) > 90)
        {
            transform.localScale = new Vector3(Scale, -Scale, 1);
        }
        else
        {
            transform.localScale = new Vector3(Scale, Scale, 1);
        }
        GetComponent<Rigidbody2D>().rotation = Dir;

    }
}
