using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
	static PlayerSpawner instance = null;
	
	// Use this for initialization
	void Start () {
		if (instance != null)
		{
			Destroy(gameObject);
			print("BEGONE THOT");
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
}
