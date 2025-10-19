using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Inventory inventory;
    public GameObject player;

    void Start()
    {
        Quaternion itemRotation = Quaternion.identity;
        Vector3 itemPosition = new Vector3(0, 0, 0);
        ItemSO someInstance = Resources.Load("Axe") as ItemSO;
        inventory.AddItem(someInstance);
        inventory.EquipItem(someInstance);
    }
}