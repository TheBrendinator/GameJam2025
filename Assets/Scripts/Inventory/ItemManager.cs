using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        ItemSO axe = Resources.Load("Axe") as ItemSO;
        ItemSO sword = Resources.Load("Sword") as ItemSO;
        inventory.AddItem(axe);
        inventory.AddItem(sword);
        inventory.EquipItem(axe);
    }
}