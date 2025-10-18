using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    // These will be shown together but a darkened filter will be put on whichever one isn't accessible at the moment
    public GenericInventory dayInventory;
    public GenericInventory nightInventory;

    private void ShowInventory()
    {
        // This will print the items using sprites maybe?
    }
}