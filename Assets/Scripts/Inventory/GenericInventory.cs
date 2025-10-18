using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
public class GenericInventory : ScriptableObject
{
    // Used https://gamedevbeginner.com/how-to-make-an-inventory-system-in-unity/ as reference

    public int maxItems = 20;
    public List<ItemInstance> items = new();

    public bool AddItem(ItemInstance itemToAdd)
    {
        for(int i = 0; i < maxItems; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                return true;
            }
        }

        return false;
    }
}