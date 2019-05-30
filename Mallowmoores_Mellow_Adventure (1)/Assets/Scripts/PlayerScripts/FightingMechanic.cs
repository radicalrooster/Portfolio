using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class FightingMechanic : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		faceMouse();
		if (Input.GetMouseButtonDown(0))
		{
			transform.Translate(Vector2.down * 1);
		} else if (Input.GetMouseButtonUp(0))
		{
			transform.Translate(Vector2.up * 1);
		}
	}
	
	//Follows the mouse
	void faceMouse()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		
		Vector2 direction = new Vector2(
			mousePos.x - transform.position.x, 
			mousePos.y - transform.position.y
			);
		transform.up = -direction;
	}
}
