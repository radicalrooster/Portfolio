using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan_Animator : MonoBehaviour {
	
	
	private Animator m_Anim;            // Reference to the player's animator component.
	private Rigidbody2D m_Rigidbody2D;
	private Vector3 previousPosition;
	public float CurSpeed;
	
	#region Movement Bool
	
	private bool Up;
	private bool Down;
	private bool Right;
	private bool Left;
	
	#endregion

	// Use this for initialization
	void Awake () {
		m_Anim = GetComponent<Animator>();                  // finding the animator.
		m_Rigidbody2D = GetComponent<Rigidbody2D>();        // getting the rigidbody of the player. 
		Right = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	#region Setmovement
		
		Vector3 curMove = transform.position - previousPosition;
		CurSpeed = curMove.magnitude / Time.deltaTime;
		previousPosition = transform.position;
		//Debug.Log(curMove);
		
		if (curMove.x >= 0.02f)
		{
			Debug.Log("Right");
			Right = true;
			m_Anim.SetBool("Right", true);
		}
		else
		{
			
			Right = false;
			m_Anim.SetBool("Right", false);
		}
		
		if (curMove.x <= -0.02f)
		{
			Debug.Log("Left");
			Left = true;
			m_Anim.SetBool("Left", true);
		}
		else
		{
			Left = false;
			m_Anim.SetBool("Left", false);
		}

		if (curMove.z >= 0.02f)
		{
			Debug.Log("Up");
			Up = true;
			m_Anim.SetBool("Up", true);
		}
		else
		{
			
			Up = false;
			m_Anim.SetBool("Up", false);
		}
		
		if (curMove.z <= -0.02f)
		{
			Debug.Log("Down");
			Down = true;
			m_Anim.SetBool("Down", true);
		}
		else
		{
			Down = false;
			m_Anim.SetBool("Down", false);
		}
	#endregion
	}
}


