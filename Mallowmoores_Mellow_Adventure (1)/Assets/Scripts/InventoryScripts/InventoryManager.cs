using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //All the different sprites of the weapons
    public Sprite equipWeapon0;
    public Sprite equipWeapon1;
    public Sprite equipWeapon2;
    public Sprite equipWeapon3;
    public Sprite equipWeapon4;
    public Sprite equipWeapon5;
    
    //Acceses the ItemPick Script and the ShowItemsStats Script
    private ItemPickup _itemPickup;
    private ShowItemStats _showItemStats;
    
    //Checks which item to put in the heldItem GameObject
    public int equipmentSlot;

    //A boolean that checks if the item has been picked up for the ShowItemStat
    public static bool weapon1PickedUp = false;
    public static bool weapon2PickedUp = false;
    public static bool weapon3PickedUp = false;
    public static bool weapon4PickedUp = false;
    public static bool weapon5PickedUp = false;
    public static bool weapon6PickedUp = false;
    
    //The item that the player holds
    public GameObject heldItem;
    
    //Al the items that can been showed in the inventory
    public GameObject weapon0;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public GameObject weapon5;

    public void Start()
    {
        
    }

    public void Update()
    {
        //Checks which item has been picked up
        #region Item Pick Up Check
        if (ItemPickup.PickedupItem == 1)
        {
            weapon0.SetActive(true);
            weapon1PickedUp = true;
        }
        if (ItemPickup.PickedupItem == 2)
        {
            weapon1.SetActive(true);
            weapon2PickedUp = true;
        }
        if (ItemPickup.PickedupItem == 3)
        {
            weapon2.SetActive(true);
            weapon3PickedUp = true;
        }
        if (ItemPickup.PickedupItem == 4)
        {
            weapon3.SetActive(true);
            weapon4PickedUp = true;
        }
        if (ItemPickup.PickedupItem == 5)
        {
            weapon4.SetActive(true);
            weapon5PickedUp = true;
        }
        if (ItemPickup.PickedupItem == 6)
        {
            weapon5.SetActive(true);
            weapon6PickedUp = true;
        }
        #endregion

        equipmentSlot = ShowItemStats.ItemSlot;
        
    }

    //Changes the sprite of the item the player is holding
    #region Equip Weapon
    public void EquipWeapon()
    {
        if (equipmentSlot == 0 && ItemPickup.PickedupItem == 1)
        {
            heldItem.gameObject.GetComponent<SpriteRenderer>().sprite = equipWeapon0;
            Debug.Log("Item has been equiped");
        }
        if (equipmentSlot == 1 && ItemPickup.PickedupItem == 2)
        {
            heldItem.gameObject.GetComponent<SpriteRenderer>().sprite = equipWeapon1;
            Debug.Log("Item has been equiped");
        }
        if (equipmentSlot == 2 && ItemPickup.PickedupItem == 3)
        {
            heldItem.gameObject.GetComponent<SpriteRenderer>().sprite = equipWeapon2;
            Debug.Log("Item has been equiped");
        }
        if (equipmentSlot == 3 && ItemPickup.PickedupItem == 4)
        {
            heldItem.gameObject.GetComponent<SpriteRenderer>().sprite = equipWeapon3;
            Debug.Log("Item has been equiped");
        }
        if (equipmentSlot == 4 && ItemPickup.PickedupItem == 5)
        {
            heldItem.gameObject.GetComponent<SpriteRenderer>().sprite = equipWeapon4;
            Debug.Log("Item has been equiped");
        }
        if (equipmentSlot == 5 && ItemPickup.PickedupItem == 6)
        {
            heldItem.gameObject.GetComponent<SpriteRenderer>().sprite = equipWeapon5;
            Debug.Log("Item has been equiped");
        }
        else
        {
            Debug.Log("You can equip that item right now");
        }
    }
    #endregion
}