using UnityEngine;

// A container is wrapped around Item Instance which is the object that actually holds the item data
// This works around a few quirks of using ScriptableObject to allow creating item objects in-world
public class ItemInstanceContainer : MonoBehaviour
{
    public ItemInstance item;

    public ItemInstance TakeItem()
    {
        Destroy(gameObject);
        return item;   
    }
}