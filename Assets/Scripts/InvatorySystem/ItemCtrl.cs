using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public ItemCreate item;
    public InventoryCreate bag;

    void OnTriggerStay(Collider other) //按F取得道具
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {
        if (!bag.itemList.Contains(item)) //如果格子是空的就加入物品到那格，如果有同樣東西數量就+1
        {
            for (int i = 0; i < bag.itemList.Count; i++)
            {
                if (bag.itemList[i] == null)
                {
                    bag.itemList[i] = item;
                    break;
                }
            }
        }
        else
        {
            item.count++;
        }

        BagCtrl.RefreshItem();

    }
}
