using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
	private Vector3 startPosition;
	public Transform Start;
	public Transform End;
	public GameObject Snake;
	public static bool Crash = false;
	public static bool StartBool = false;
	private bool ArrowControl = false;
	private GameObject currentSnake = null;
	void ForStart()
	{
		startPosition = new Vector3(Start.position.x, Start.position.y - 1.5f, Start.position.z);
		currentSnake = currentSnake = Instantiate(Snake, startPosition, Snake.transform.rotation);
		currentSnake.GetComponent<Movement>().allow = true;
		currentSnake.GetComponent<Movement>().GetDirection("forward");
	}
	void Update () {
		if (StartBool && !ArrowControl)
		{
			ForStart();
			StartBool = false;
			 ArrowControl = true;
		}
		if (Crash)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				GameObject[] SnakeParts= GameObject.FindGameObjectsWithTag("Snake");
				foreach (GameObject snakePart in SnakeParts)
				{
					Destroy(snakePart);
				}
				Crash = false;
				ForStart();
				Time.timeScale = 1;
			}
		}
		if (ArrowControl)
		{
			if (Input.GetKeyDown(KeyCode.W) && currentSnake.GetComponent<Movement>().direction != "back")
			{
				changePosition();
				currentSnake.GetComponent<Movement>().GetDirection("forward");
			}
			if (Input.GetKeyDown(KeyCode.S) && currentSnake.GetComponent<Movement>().direction != "forward")
			{
				changePosition();
				currentSnake.GetComponent<Movement>().GetDirection("back");
			}
			if (Input.GetKeyDown(KeyCode.A) && currentSnake.GetComponent<Movement>().direction != "left")
			{
				changePosition();
				currentSnake.GetComponent<Movement>().GetDirection("right");
			}
			if (Input.GetKeyDown(KeyCode.D) && currentSnake.GetComponent<Movement>().direction != "right")
			{
				changePosition();
				currentSnake.GetComponent<Movement>().GetDirection("left");
			}
		}
	}
	void changePosition()
	{
		currentSnake.GetComponent<Movement>().allow = false;
		newStartPosition(currentSnake.GetComponent<Movement>().direction);
		currentSnake = Instantiate(Snake, startPosition, Snake.transform.rotation);
		currentSnake.GetComponent<Movement>().allow = true;
	}
	void newStartPosition(string direction)
	{
		if (direction == "forward")
		{
			startPosition = new Vector3(currentSnake.transform.position.x, currentSnake.transform.position.y, (currentSnake.transform.position.z - (currentSnake.transform.localScale.z - Snake.transform.localScale.z) / 2));
		}
		if (direction == "back")
		{
			startPosition = new Vector3(currentSnake.transform.position.x, currentSnake.transform.position.y, (currentSnake.transform.position.z + (currentSnake.transform.localScale.z - Snake.transform.localScale.z) / 2));
		}
		if (direction == "right")
		{
			startPosition = new Vector3((currentSnake.transform.position.x + (currentSnake.transform.localScale.x - Snake.transform.localScale.x) / 2), currentSnake.transform.position.y, currentSnake.transform.position.z);
		}
		if (direction == "left")
		{
			startPosition = new Vector3((currentSnake.transform.position.x - (currentSnake.transform.localScale.x - Snake.transform.localScale.x) / 2), currentSnake.transform.position.y, currentSnake.transform.position.z);
		}
	}
}
