using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemStats : MonoBehaviour
{
    private ItemPickup _itemPickup;
    private InventoryManager _invManager;
    
    public static int ItemSlot;
    
    public Text itemName;
    public Text itemDesc;
    public Text itemType;

    public Color startColor;
    public Color mouseOverColor;
    private bool mouseOver = false;

    void Update()
    {
        
    }

    //Checks if the mouse is hovering over an collected item and than shows the information about the item that has been
    //declared in the ItemManager Script
    void OnMouseEnter()
    {
        mouseOver = true;
        GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
        Debug.Log("HIT " + gameObject.name);
        if (gameObject.name == "0" && InventoryManager.weapon1PickedUp == true)
        {
            ItemSlot = 1;
        }
        if (gameObject.name == "1" && InventoryManager.weapon2PickedUp == true)
        {
            ItemSlot = 2;
        }
        if (gameObject.name == "2" && InventoryManager.weapon3PickedUp == true)
        {
            ItemSlot = 3;
        }
        if (gameObject.name == "3" && InventoryManager.weapon4PickedUp == true)
        {
            ItemSlot = 3;
        }
        if (gameObject.name == "4" && InventoryManager.weapon5PickedUp == true)
        {
            ItemSlot = 4;
        }
        if (gameObject.name == "5" && InventoryManager.weapon6PickedUp == true)
        {
            ItemSlot = 5;
        }
        
        itemName.text = ItemManager.Instance.items[ItemSlot].itemName;
        itemDesc.text = ItemManager.Instance.items[ItemSlot].itemDesc;
        itemType.text = ItemManager.Instance.items[ItemSlot].itemType;
    }

    //Does noting really...
    void OnMouseExit()
    {
        mouseOver = false;
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
        Debug.Log("BYE CUNT");
    }
}
