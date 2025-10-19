using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        ItemSO someInstance = Resources.Load("Axe") as ItemSO;
        inventory.AddItem(someInstance);
        inventory.EquipItem(someInstance);
    }
}