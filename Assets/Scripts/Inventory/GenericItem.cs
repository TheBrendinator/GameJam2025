using UnityEngine;

public abstract class GenericItem : MonoBehaviour 
{
    public string itemName;
    public Sprite itemIcon;
    public bool isConsumable;
    public bool dayItem;
    public bool nightItem;
    public int attackDamage;
    public double attackSpeed;
    public int defense;
    public int quantity;
}