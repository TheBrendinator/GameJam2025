using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Inventory inventory;
    public BasicAxe basicAxeModel;
    private List<GenericItem> globalItemList = new List<GenericItem>();
    private Quaternion itemRotation = Quaternion.identity;
    private Vector3 itemPosition = new Vector3(0, 0, 0);

    void Start()
    {
        globalItemList.Add(Instantiate(basicAxeModel, itemPosition, itemRotation));

        inventory.AddItem(new InventoryItem(globalItemList[0]));
        inventory.ShowInventory();
    }
}