using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    // All item properties go in here
    public string itemName;
    // public Sprite itemIcon;
    public GameObject itemPrefab;
    public bool isConsumable;
    public bool dayItem;
    public bool nightItem;
    public int attackDamage;
    public double attackSpeed;
    public int defense;
    public int quantity;
}
