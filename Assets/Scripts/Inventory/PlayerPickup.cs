using UnityEngine;
using System.Collections.Generic;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private List<ItemSO> itemToGivePlayer;

    void Awake() {
        // if want random, pick at start
    }

    void OnTriggerEnter(Collider other)
    {
        // cehck if gameobject has tag player
        //  if is, give item

    }

}
