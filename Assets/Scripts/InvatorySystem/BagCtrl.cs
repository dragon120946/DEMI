using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagCtrl : MonoBehaviour
{
    static BagCtrl instance;

    public InventoryCreate bag;     //背包數據
    public GameObject slotGrid;     //格子群組
    public GameObject emptySlot;    //空格子
    public List<GameObject> slot = new List<GameObject>();  //格子數量
    
    void Awake()    //無法理解
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    void OnEnable()    //按下Play後執行
    {
        RefreshItem();
    }

    public static void RefreshItem()    //刷新物品(開始遊戲和得到物品會觸發)
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)    //到Grid下的子物件數量(格子數)為止
        {
            if (instance.slotGrid.transform.childCount == 0)    //如果得到相同物品，就把多生成的格子刪除
            {
                break;    //跳出迴圈
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slot.Clear();     //清空多的格子
        }

        for (int i = 0; i < instance.bag.itemList.Count; i++)   //到背包欄位的數量為止
        {
            instance.slot.Add(Instantiate(instance.emptySlot));     //生成空格子
            instance.slot[i].transform.SetParent(instance.slotGrid.transform);      //移動格子圖層到Grid下
            instance.slot[i].GetComponent<Slot>().slotID = i;   //獲取格子的ID
            instance.slot[i].GetComponent<Slot>().SetSlot(instance.bag.itemList[i]);    //將背包數據傳輸到格子
        }
    }
}
