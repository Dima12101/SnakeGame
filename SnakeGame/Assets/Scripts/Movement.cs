using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public string direction;
	public bool allow = false;
	private float speed = 5f;
	private Vector3 deltaPos;
	private Vector3 deltaScale;
	public void GetDirection (string _direction)
	{
		direction = _direction;
	}
	void Update () {
		if (!allow)
		{
			return;
		}
		if (direction == "forward")
		{
			deltaPos = new Vector3(0f, 0f, - speed * Time.deltaTime);
			deltaScale = new Vector3(0f, 0f, 2 * speed * Time.deltaTime);
		}
		if (direction == "back")
		{
			deltaPos = new Vector3(0f, 0f, speed * Time.deltaTime);
			deltaScale = new Vector3(0f, 0f, 2 * speed * Time.deltaTime);
		}
		if (direction == "right")
		{
			deltaPos = new Vector3(speed * Time.deltaTime, 0f, 0f);
			deltaScale = new Vector3(2 * speed * Time.deltaTime, 0f, 0f);
		}
		if (direction == "left")
		{
			deltaPos = new Vector3(- speed * Time.deltaTime, 0f, 0f);
			deltaScale = new Vector3(2 * speed * Time.deltaTime, 0f, 0f);
		}
		transform.position += deltaPos;
		transform.localScale += deltaScale;
	}
}
