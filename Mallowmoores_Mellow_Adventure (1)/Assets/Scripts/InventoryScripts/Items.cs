using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Items
{
    //The values you have to use to add an item to the game
    public int itemID;
    public string itemName;
    public string itemDesc;
    public string itemType;
    
    public Items(int id, string name, string desc, string type)
    {
        this.itemID = id;
        this.itemName = name;
        this.itemDesc = desc;
        this.itemType = type;
    }
}