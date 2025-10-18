using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    // Both the day and night inventories are included within a singular inventory however 
    public GenericInventory inventory;

    public void Start()
    {
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        // This will print the items using sprites maybe?
    }
    
    private bool DropItem(int index)
    {
        try
        {
            // Creates object and copies item data to it
            GameObject droppedItem = new GameObject();
            droppedItem.AddComponent<Rigidbody>();
            droppedItem.AddComponent<ItemInstanceContainer>().item = inventory.items[index];
            GameObject itemModel = Instantiate(inventory.items[index].item.model, droppedItem.transform);

            inventory.items.RemoveAt(index);
        }

        catch
        {
            return false;
        }

        return true;
    }
}