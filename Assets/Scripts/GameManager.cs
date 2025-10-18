using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Inventory inventory;
    public Axe axe = new Axe();


    public GenericItem[] itemList;

    void Start()
    {
        Vector3 itemPosition = new Vector3(0, 0, 0);
        Quaternion itemRotation = Quaternion.identity;
        Axe newAxe = Instantiate(axe, itemPosition, itemRotation);
        InventoryItem newnewAxe = new InventoryItem("Axe", null, newAxe);

        inventory.AddItem(newnewAxe);
        inventory.ShowInventory();
    }
}