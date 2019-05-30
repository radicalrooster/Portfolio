using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;


public class Playerscript : MonoBehaviour
{
	static Playerscript instance = null;
	[SerializeField]
	public EnemyScripts HealthDrain;
	[SerializeField]
	private Stat health;
	[SerializeField]
	private Stat energy;

	public GameObject enemy;

	public GameObject HealthObject;

	public AudioSource dmgSound;
	
	private void Awake()
	{
		health.Initialize();
		//energy.Initialize();
		
	}
		
	void OnEnable()
	{
		Debug.Log("OnEnable called");
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	// called second
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{	
				
		Debug.Log("OnSceneLoaded: " + scene.name);
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		HealthDrain = enemy.GetComponent<EnemyScripts>();
		HealthObject = GameObject.FindGameObjectWithTag("HealthObject");
		
		Debug.Log(mode);
	}
	void Start()
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

	// Update is called once per frame
	void FixedUpdate()
	{
/*		if (Input.GetKeyDown(KeyCode.Q))
		{
			health.Currentval -= 10;
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			health.Currentval += 10;
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			energy.Currentval -= 10;
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			energy.Currentval += 10;
		}*/

		if (HealthDrain.dmge == true)
		{
			health.Currentval -= 10 * Time.deltaTime;
			dmgSound.Play();
		}
	}

	public void OnTriggerEnter(Collider Other)
	{
		Debug.Log(Other.gameObject.tag);
		if(Other.gameObject.tag == "HealthObject")
		{
			health.Currentval += 20;
		if(Other.gameObject.tag=="HealthObject")
			Destroy(HealthObject);
		}

	}
}
