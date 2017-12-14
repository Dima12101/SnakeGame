using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing2 : MonoBehaviour {
	private float speed = 1f;
	private Vector3 deltaPos;
	private Vector3 deltaScale;
	private Vector3 ScaleStart;
	// Use this for initialization
	void Start () {
		ScaleStart = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		deltaPos = new Vector3(0f, 0f, -speed * Time.deltaTime);
		deltaScale = new Vector3(0f, speed * Time.deltaTime, 0f);
		transform.position += deltaPos;
		transform.localScale += deltaScale;
		transform.GetChild(0).transform.localScale = new Vector3(transform.GetChild(0).transform.localScale.x, (ScaleStart.y / transform.localScale.y), transform.GetChild(0).transform.localScale.z);
		transform.GetChild(1).transform.localScale = new Vector3(transform.GetChild(1).transform.localScale.x, (ScaleStart.y / transform.localScale.y), transform.GetChild(1).transform.localScale.z);

	}
}
