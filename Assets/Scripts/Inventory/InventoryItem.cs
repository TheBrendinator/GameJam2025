using UnityEngine;

// This class probably shouldn't be touched, it's only for displaying the items in a menu and saving them in the inventory
// The items stats are still saved from the actual items object (e.g. BasicAxe.cs)
[System.Serializable]
public class InventoryItem
{
    public GenericItem item;
    public string itemName;
    public Sprite itemIcon;

    public InventoryItem(GenericItem item)
    {
        this.item = item;

        itemName = item.itemName;

        itemIcon = item.itemIcon;
    }
}