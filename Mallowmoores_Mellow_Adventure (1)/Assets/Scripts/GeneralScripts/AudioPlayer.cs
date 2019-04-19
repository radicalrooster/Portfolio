using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	private static AudioPlayer instance = null;
	
	// Use this for initialization
	void Start () {
		if (instance != null)
		{
			Destroy(gameObject);
			Debug.Log("BEGONE THOT!");
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
