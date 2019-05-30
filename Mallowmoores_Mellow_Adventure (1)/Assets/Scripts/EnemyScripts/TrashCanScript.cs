using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrashCanScript : MonoBehaviour
{
	private Playerscript health;
	private NavMeshAgent agent;
	public GameObject Objplayer;
	public Transform Player;
	public bool dmge;
	public GameObject checkpoint;
	public GameObject checkpoint1;
	public GameObject checkpoint2;
	public GameObject checkpoint3;
	private bool attacking;
	private float Hit;
	
	
	// Use this for initialization
	void Awake()
	{
		attacking = true;
		Player = GameObject.FindGameObjectWithTag("Player").transform;
		Objplayer = GameObject.FindGameObjectWithTag("Player");
		if(!Objplayer)	
		{
			Debug.Log("Make sure your player is tagged!!");
		}
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	public void Update()
	{
		HealthDrain();
	}
	// Update is called once per frame
	public void HealthDrain()
	{
		float dist = Vector3.Distance(Player.position, transform.position);
		//Debug.Log("Dis: " + dist);
		
		if (dist <= 2)
		{
			dmge = true;
		}
		
		if (dist >= 2)
		{
			dmge = false;
		}
		
		if (dist <= 7)
		{
			agent.destination = Objplayer.transform.position;
			attacking = true;
		}

		if (dist >= 7.01f && attacking)
		{
			agent.destination = checkpoint.transform.position;
			attacking = false;
		}


		

		transform.rotation = Quaternion.identity;

	}

	public void OnTriggerEnter(Collider Other)
	{
		Debug.Log(Other.gameObject.tag);
		if(Other.gameObject.tag == "Checkpoint")		
		{
			
			agent.destination = checkpoint1.transform.position;
		}

		if (Other.tag == "Checkpoint1")
		{
			agent.destination = checkpoint2.transform.position;
		}

		if (Other.tag == "Checkpoint2")
		{
			agent.destination = checkpoint3.transform.position;
		}

		if (Other.tag == "Checkpoint3")			
		{
			agent.destination = checkpoint.transform.position;	
		}

		if (Other.tag == "Poke")
		{
			Hit = +1;
		}
	}
}
