using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
	public Items[] items = new Items[4];
	
	private static ItemManager _instance;
	
	//The singleton for the ItemManager
	#region Singleton ItemManager
	public static ItemManager Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject go = new GameObject("ItemManager");
				go.AddComponent<ItemManager>();
			}

			return _instance;
		}
	}
	#endregion

	void Awake()
	{
		_instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		items[0] = new Items(0, "", "", "");
		items[1] = new Items(1, "Poking Device", "Poke the enemies with the fury of nature!", "melee");
		items[2] = new Items(2, "Water Hose", "Give live to the trees and death to the enemies!", "ranged");
		items[3] = new Items(3, "Weed Wacker", "This is a really wacky machine", "melee");
		items[4] = new Items(4, "Flamethrower", "HANS GET ZE FLAMMENWERFER!", "ranged");
		items[5] = new Items(5, "Manure Maker", "What smells so bad?", "ranged");
		items[6] = new Items(6, "Leaf Blower", "Blow your enemies away", "ranged");
		Debug.Log(items[0].itemName);
	}
}
