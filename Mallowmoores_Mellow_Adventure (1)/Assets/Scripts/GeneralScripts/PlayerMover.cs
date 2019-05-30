using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	private Vector3 spawnPos;
	static PlayerMover instance = null;

	void start()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			print("BEGONE THOT!");
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	void Awake()
	{
		spawnPos = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
	}

	// Use this for initialization
	void Start () {	
		if (GameObject.FindGameObjectWithTag("SpawnPoint"))
		{
			Debug.Log("SpawnPoint Found! Moving player");
			GameObject.FindGameObjectWithTag("Player").transform.position = spawnPos;
		}
		else
		{
			Debug.Log("Make sure there is a spawn point!");
		}
	}
}
