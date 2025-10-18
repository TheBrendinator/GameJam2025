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

        Debug.log("Inventory full");
        return false;
    }

    public bool DropItem(int index)
    {
        try
        {
            // Creates object and copies item data to it
            GameObject droppedItem = new GameObject();
            droppedItem.AddComponent<Rigidbody>();
            droppedItem.AddComponent<ItemInstanceContainer>().item = items[index];
            GameObject itemModel = Instantiate(items[index].model, droppedItem.transform);

            items.RemoveAt(index);
        }

        catch
        {
            Debug.log("Failed to drop item... How?");
            return false;
        }

        return true;
    }
}