using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMechanics : MonoBehaviour
{
	private Animator m_Anim;
	
	public float speed;

	public AudioSource attackSound;

	#region Booleans
	public bool walkingLeft = false;
	public bool walkingUp = false;
	public bool walkingRight = false;
	public bool walkingDown = true;
	public bool isAttacking = false;
	#endregion

	#region GameObjects
	public GameObject HeldItemDown;
	public GameObject HeldItemRight;
	public GameObject HeldItemUp;
	public GameObject HeldItemLeft;
	public GameObject HeldItemDownAtt;
	public GameObject HeldItemRightAtt;
	public GameObject HeldItemUpAtt;
	public GameObject HeldItemLeftAtt;
	#endregion
	
	private void Awake()
	{
		m_Anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	//The movement of the player
	void Update ()
	{
		#region Movement
		
		if (Input.GetKey(KeyCode.S) && isAttacking != true)
		{
			transform.Translate(Vector2.down * speed);
			m_Anim.SetBool("down", true);
			HeldItemLeft.SetActive(false);
			HeldItemRight.SetActive(false);
			HeldItemUp.SetActive(false);
			HeldItemLeftAtt.SetActive(false);
			HeldItemRightAtt.SetActive(false);
			HeldItemUpAtt.SetActive(false);
			walkingDown = true;
			walkingLeft = false;
			walkingRight = false;
			walkingUp = false;
		}
		else
		{
			m_Anim.SetBool("down", false);
		}

		if (Input.GetKey(KeyCode.A) && isAttacking != true)
		{
			transform.Translate(Vector2.left * speed);
			m_Anim.SetBool("left", true);
			HeldItemRight.SetActive(false);
			HeldItemUp.SetActive(false);
			HeldItemDown.SetActive(false);
			HeldItemDownAtt.SetActive(false);
			HeldItemRightAtt.SetActive(false);
			HeldItemUpAtt.SetActive(false);
			walkingDown = false;
			walkingLeft = true;
			walkingRight = false;
			walkingUp = false;
		}
		else
		{
			m_Anim.SetBool("left", false);
		}

		if (Input.GetKey(KeyCode.D) && isAttacking != true)
		{
			transform.Translate(Vector2.right * speed);
			m_Anim.SetBool("right", true);
			HeldItemLeft.SetActive(false);
			HeldItemUp.SetActive(false);
			HeldItemDown.SetActive(false);
			HeldItemDownAtt.SetActive(false);
			HeldItemLeftAtt.SetActive(false);
			HeldItemUpAtt.SetActive(false);
			walkingDown = false;
			walkingLeft = false;
			walkingRight = true;
			walkingUp = false;
		}
		else
		{
			m_Anim.SetBool("right", false);
		}

		if (Input.GetKey(KeyCode.W) && isAttacking != true)
		{
			transform.Translate(Vector2.up * speed);
			m_Anim.SetBool("up", true);
			HeldItemLeft.SetActive(false);
			HeldItemRight.SetActive(false);
			HeldItemDown.SetActive(false);
			HeldItemDownAtt.SetActive(false);
			HeldItemLeftAtt.SetActive(false);
			HeldItemRightAtt.SetActive(false);
			walkingDown = false;
			walkingLeft = false;
			walkingRight = false;
			walkingUp = true;
		}
		else
		{
			m_Anim.SetBool("up", false);
		}
		
		#endregion

		#region ItemActivity
		if (isAttacking == false && walkingDown == true)
		{
			HeldItemDownAtt.SetActive(false);
			HeldItemDown.SetActive(true);
		}
		
		if (isAttacking == false && walkingLeft == true)
		{
			HeldItemLeftAtt.SetActive(false);
			HeldItemLeft.SetActive(true);
		}
		
		if (isAttacking == false && walkingUp == true)
		{
			HeldItemUpAtt.SetActive(false);
			HeldItemUp.SetActive(true);
		}
		
		if (isAttacking == false && walkingRight == true)
		{
			HeldItemRightAtt.SetActive(false);
			HeldItemRight.SetActive(true);
		}
		#endregion

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Attack();
//			attackSound.Play();
		}

		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			isAttacking = false;
		}
	}

	#region Attacking

	public void Attack()
	{
		if (walkingDown == true)
		{
			isAttacking = true;
			HeldItemDown.SetActive(false);
			HeldItemDownAtt.SetActive(true);
		}

		if (walkingLeft == true)
		{
			isAttacking = true;
			HeldItemLeft.SetActive(false);
			HeldItemLeftAtt.SetActive(true);
		}

		if (walkingRight == true)
		{
			isAttacking = true;
			HeldItemRight.SetActive(false);
			HeldItemRightAtt.SetActive(true);
		}

		if (walkingUp == true)
		{
			isAttacking = true;
			HeldItemUp.SetActive(false);
			HeldItemUpAtt.SetActive(true);
		}
	}

	#endregion


	#region Gates

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Gate19")
		{
			SceneManager.LoadScene("BossFight");
		}
		if (other.tag == "Gate18")
		{
			SceneManager.LoadScene("Factory_5");
		}
		if (other.tag == "Gate17")
		{
			SceneManager.LoadScene("Factory_6");
		}
		if (other.tag == "Gate16")
		{
			SceneManager.LoadScene("Factory_7");
		}
		if (other.tag == "Gate15")
		{
			SceneManager.LoadScene("Factory_5");
		}
		if (other.tag == "Gate14")
		{
			SceneManager.LoadScene("Factory_7");
		}
		if (other.tag == "Gate13")
		{
			SceneManager.LoadScene("Factory_3");
		}
		if (other.tag == "Gate12")
		{
			SceneManager.LoadScene("Factory_6");
		}
		if (other.tag == "Gate11")
		{
			SceneManager.LoadScene("Factory_3");
		}
		if (other.tag == "Gate10")
		{
			SceneManager.LoadScene("Factory_1");
		}
		if (other.tag == "Gate9")
		{
			SceneManager.LoadScene("Factory_3");
		}
		if (other.tag == "Gate8")
		{
			SceneManager.LoadScene("Factory_5");
		}
		if (other.tag == "Gate7")
		{
			SceneManager.LoadScene("Factory_4");	
		}
		if (other.tag == "Gate6")
		{
			SceneManager.LoadScene("Factory_2");
		}
		if (other.tag == "Gate5")
		{
			SceneManager.LoadScene("Stad3");
		}
		if (other.tag == "Gate4")
		{
			SceneManager.LoadScene("Factory_1");	
		}
		if (other.tag == "Gate3")
		{
			SceneManager.LoadScene("Stad2");
		}
		if (other.tag == "Gate2")
		{
			SceneManager.LoadScene("Stad3");
		}
		if (other.tag == "Gate1")
		{
			SceneManager.LoadScene("Stad1");
		}
	}
	#endregion
	


//	void faceMouse()
//	{
//		Vector3 mousePos = Input.mousePosition;
//		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
//		
//		Vector2 direction = new Vector2(
//			mousePos.x - transform.position.x, 
//			mousePos.y - transform.position.y
//			);
//		transform.up = -direction;
//	}
}
