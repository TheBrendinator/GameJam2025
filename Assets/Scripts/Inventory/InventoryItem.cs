using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public Sprite itemIcon;
    public Axe itemModel;

    public InventoryItem(string name, Sprite icon, Axe model)
    {
        itemName = name;
        itemIcon = icon;
        itemModel = model;
    }
}