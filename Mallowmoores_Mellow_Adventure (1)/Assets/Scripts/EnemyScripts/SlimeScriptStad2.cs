using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlimeScriptStad2 : MonoBehaviour
{
	private NavMeshAgent agent;
	public GameObject player;
	public Transform Player;
	public GameObject checkpoint;
	public GameObject checkpoint1;
	//public GameObject checkpoint2;
	//public GameObject checkpoint3;
	private bool attacking;
	
	
	// Use this for initialization
	void Awake()
	{
		attacking = true;
		player = GameObject.FindGameObjectWithTag("Player");
			if(!player)	
			{
				Debug.Log("Make sure your player is tagged!!");
			}
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update()
	{
		float dist = Vector3.Distance(Player.position, transform.position);
		//debug.log("Dis: " + dist);

		if (dist <= 7)
		{
			agent.destination = player.transform.position;
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

//		if (Other.tag == "Checkpoint1")
//		{
//			agent.destination = checkpoint2.transform.position;
//		}
//
//		if (Other.tag == "Checkpoint2")
//		{
//			agent.destination = checkpoint3.transform.position;
//		}

		if (Other.tag == "Checkpoint1")			
		{
			agent.destination = checkpoint.transform.position;	
		}
	}
}
