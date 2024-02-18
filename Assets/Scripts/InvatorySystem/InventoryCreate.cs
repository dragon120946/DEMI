using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory",menuName = "Inventory/New Inventory")] 
public class InventoryCreate : ScriptableObject
{
    public List<ItemCreate> itemList = new List<ItemCreate>();
}
