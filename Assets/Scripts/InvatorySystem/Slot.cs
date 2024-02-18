using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int slotID;      //格子ID
    public Image slotImage;     //物品圖片
    public Text slotCount;      //物品數量
    public Text itemName;   //物品名稱
    public Text itemInfo;   //物品詳細
    public GameObject itemInSlot;   //格子內的物品
    public GameObject info;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        info.SetActive(true);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        info.SetActive(false);
    }
    
    void Start()
    {
        info.SetActive(false);
    }

    public void SetSlot(ItemCreate item)
    {
        if (item == null)
        {
            info.SetActive(false);
            itemInSlot.SetActive(false);
            return;
        }
        slotImage.sprite = item.sprite;
        slotCount.text = item.count.ToString();
        itemName.text = item.itemName;
        itemInfo.text = item.info;
    }
}
