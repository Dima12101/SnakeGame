using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Target : MonoBehaviour {
	public GameObject LoseText;
	public GameObject WinText;
	private GameObject TextForDelete;
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Snake"))
		{
			GameStop();
		}
	}
	void GameStop()
	{
		Control.Crash = true;
		if (this.GetComponent<Collider>().CompareTag("End"))
		{
			TextForDelete = Instantiate(WinText, WinText.transform.position, WinText.transform.rotation);

		}
		if (this.GetComponent<Collider>().CompareTag("Field"))
		{
			TextForDelete = Instantiate(LoseText, LoseText.transform.position, LoseText.transform.rotation);
		}

		Destroy(TextForDelete, Time.deltaTime);
		Time.timeScale = 0;
	}
}
