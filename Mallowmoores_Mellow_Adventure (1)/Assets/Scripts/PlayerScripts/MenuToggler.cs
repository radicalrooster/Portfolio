using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggler : MonoBehaviour {
	
	public GameObject inventory;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.B))
		{
			ToggleMenu();
		}
	}
	
	void ToggleMenu()
	{
		if (!inventory.activeSelf)
		{
			inventory.SetActive(true);
			Time.timeScale = 0f;
		}
		else
		{
			inventory.SetActive(false);
			Time.timeScale = 1f;
		}
	}
}
