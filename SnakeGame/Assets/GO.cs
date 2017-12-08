using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO : MonoBehaviour {
	public Color hoverColor;
	private Renderer rend;
	private Color startColor;

	private void Start()
	{
		// запоминаем стартовый цвет, чтобы возвращаться к нему
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	private void OnMouseDown()
	{
		Control.StartBool = true;
	}

	// смена цвета при наведении
	private void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	// возврат цвета при выходе курсора из Node
	private void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
