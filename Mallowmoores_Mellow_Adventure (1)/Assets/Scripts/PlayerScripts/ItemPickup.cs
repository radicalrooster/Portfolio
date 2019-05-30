using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
	//An integer that says which item had been picked up
	public static int PickedupItem;
	
	//An empty GameObject where the sprite of the item is been displayed
	public GameObject itemHere;
	
	// Use this for initialization
	void Start ()
	{
		GetComponent<SpriteRenderer>().sprite = itemHere.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Checks if the player walks over the item and updates the value and destroys the item.
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("HIT " + this.gameObject.name);
			if (this.gameObject.name == "weapon0")
			{
				PickedupItem = 1;
			}

			Destroy(this.gameObject);
		
		}
	}
}
