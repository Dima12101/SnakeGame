using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {
	//public Transform startPosition;
	public GameObject part;
	private GameObject newPart;
	private Vector3 UpdatePoint;
	private Vector3 dir;
	private float speed = 2f;
	// Use this for initialization
	void Start () {
		UpdatePoint = new Vector3(transform.position.x, transform.position.y, transform.position.z - transform.localScale.y);
		dir = new Vector3(0f, 0f, -transform.localScale.y);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Mathf.Abs(Vector3.Distance(transform.position, UpdatePoint)) > speed * Time.deltaTime)
		{
			transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
		}else
		{
			newPart = Instantiate(part, transform.position, transform.rotation);
			speed = 0f;
		}
	}
}
