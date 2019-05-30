using System.Security.Cryptography.X509Certificates;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyScripts : MonoBehaviour
{	
	public enum AIstates { Patrol, Attack, };    //  enum for all the Enemy states.
	public AIstates states;                                      // all the states the ai can have.
	public enum TypeEnemy{ Slime, Worker,}         // the different types of enemies
	public TypeEnemy type;                                       // the enemy type.
	[Header("AI Pathpoints")]

	private Playerscript health;
	private NavMeshAgent agent;
	[SerializeField]
	private GameObject Objplayer;
	private Transform Player;
	
	[SerializeField]
	private GameObject[] PatrolPathObject;                       // the PatrolPath.
	[SerializeField]
	private Transform[] point;                                   // the path that the enemy should follow.
        
	private int destPoint = 0;                                   // the amount of destinations the NavMeshAgent has
	private float notdeath;
	[SerializeField]
	private float dist;                                          //the distance in between the enemy and the player.
	public bool dmge;											   //a function that determines if dmg should be done.
	
	// bool to determine the 
	private bool attacking;
	
	
	// Use this for initialization
	void Awake()
	{
		Player = GameObject.FindGameObjectWithTag("Player").transform;
		Objplayer = GameObject.FindGameObjectWithTag("Player");
		if(!Objplayer)	
		{
			Debug.Log("Make sure your player is tagged!!");
		}
		agent = GetComponent<NavMeshAgent>();
	}

	public void Update()
	{
	
		dist = Vector3.Distance(Player.position, transform.position);
	
		
		// Choose the next destination point when the agent gets close to the current one.
		// if their health is high enough          
		if (!agent.pathPending && agent.remainingDistance < 1f)
		{
			GotoNextPoint();
		}

		if (type == TypeEnemy.Slime)
		{
			PatrolPathObject = GameObject.FindGameObjectsWithTag("AIPoint");
			for (int i = 0; i < PatrolPathObject.Length; i++)
			{
				point[i] = PatrolPathObject[i].transform;
			}
		}
		HealthDrain();
		GotoNextPoint();
		AiChoices();
	}
	// Update is called once per frame
	public void HealthDrain()
	{
		Debug.Log("Dis: " + dist);
		transform.rotation = Quaternion.identity;

		if (dist < 1f)
		{
			Debug.Log("Hello");
			dmge = true;
		}

		if (dist > 1)
		{
			dmge = false;
		}

	}

	void AiChoices()
	{
		if (states == AIstates.Attack)
		{
			Patrol();
			Attack();
		}

		if (states == AIstates.Patrol)
		{
			Patrol();
			Attack();
		}
	}

	void Attack()
		{
			StopAllCoroutines();
			if (dist <= 5)
			{
				states = AIstates.Attack;
				agent.SetDestination(Player.position); // ... set the destination of the nav mesh agent to the player.
				//Debug.Log("chase the sleepy boi");
			}
		}

		void Patrol()
		{
			GotoNextPoint();
			StopAllCoroutines();
			if (dist >= 5)
			{
				states = AIstates.Patrol; // sets the ai to patrol if the player is too far away.
			}
		}

	void GotoNextPoint() 
	{
		// Returns if no points have been set up
		if (point.Length == 0)
			return;

		// Set the agent to go to the currently selected destination.
		agent.destination = point[destPoint].position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % point.Length;
	}
	
}