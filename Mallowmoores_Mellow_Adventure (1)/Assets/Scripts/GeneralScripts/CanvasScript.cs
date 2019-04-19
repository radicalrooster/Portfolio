using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {

	static CanvasScript instance = null;
	
	// Use this for initialization
	void Start () {
		if (instance != null)
		{
			Destroy(gameObject);
			print("Bye");
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
}
