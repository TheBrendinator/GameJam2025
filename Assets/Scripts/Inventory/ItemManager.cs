using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        Quaternion itemRotation = Quaternion.identity;
        Vector3 itemPosition = new Vector3(0, 0, 0);
        // inventory.AddItem(Instantiate(Resources.Load("Basic Axe"), itemPosition, itemRotation));
        ItemSO someInstance = Resources.Load("Axe") as ItemSO;
        inventory.AddItem(someInstance);
    }
}