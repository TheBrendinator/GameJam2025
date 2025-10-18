// Defines what an item is in general
using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public GameObject model;
    public string description;
}