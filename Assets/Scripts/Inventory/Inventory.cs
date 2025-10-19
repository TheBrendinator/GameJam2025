using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemSO> items = new List<ItemSO>();

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

    public void DropItem(int index) {
        
    }
}