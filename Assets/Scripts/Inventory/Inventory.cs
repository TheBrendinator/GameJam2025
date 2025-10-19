using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemSO> items = new List<ItemSO>();
    public ItemSO equippedItem;
    public GameObject temp;

    public void AddItem(ItemSO item)
    {
        items.Add(item);
        //Destroy(item);
        // Debug.Log(item.itemName + " added to inventory.");
    }

    public void RemoveItem(ItemSO item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
    }

    public void EquipItem(ItemSO item)
    {
        if (items.Contains(item))
        {
            equippedItem = item;
        }
    }
    
    public void UnequipItem(ItemSO item)
    {
        equippedItem = null;
    }

    public void UpdateEquippedPosition()
    {
        try
        {
            GameObject playerHand = GameObject.Find("hand_ik.L");
            Destroy(temp);
            temp = Instantiate(equippedItem.itemPrefab, playerHand.transform.position, playerHand.transform.rotation);
        }
        catch
        {
            temp = null;
        }
    }

    public void Update()
    {
        UpdateEquippedPosition();
    }
}