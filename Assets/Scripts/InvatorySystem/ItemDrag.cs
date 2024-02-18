using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent; //原格子位置
    public InventoryCreate bag;
    public InventoryCreate combineArea;

    private int currentItemID; //現在物品ID

    public void OnBeginDrag(PointerEventData eventData) //開始拖動(按住物件)
    {
        originalParent = transform.parent;  //現在的格子是原格子
        currentItemID = originalParent.GetComponent<Slot>().slotID;     //現在格子的ID是原格子ID
        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) //拖動過程
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData) //拖動結束(放開物件)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null) //如果滑鼠碰到的東西存在
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "ItemImage") //如果滑鼠碰到ItemImage(其他物品)
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                var temp = bag.itemList[currentItemID];
                bag.itemList[currentItemID] =
                    bag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];
                bag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            #region 碰到空格

            if (eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)") //如果滑鼠碰到空格子
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                if (originalParent.name == "slot1" || originalParent.name == "slot2" ||
                    originalParent.name == "slot3") //如果原位置是合成欄的格子
                {
                    bag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] =
                        combineArea.itemList[currentItemID];
                    combineArea.itemList[currentItemID] = null;
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }

                bag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] =
                    bag.itemList[currentItemID];
                
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID != currentItemID)
                {
                    bag.itemList[currentItemID] = null;
                }

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            if (eventData.pointerCurrentRaycast.gameObject.name == "slot1") //如果滑鼠碰到slot1
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                if (originalParent.name == "slot2" || originalParent.name == "slot3") //如果原位置是其他合成格
                {
                    combineArea.itemList[0] = combineArea.itemList[currentItemID];
                    combineArea.itemList[currentItemID] = null;
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }

                combineArea.itemList[0] = bag.itemList[currentItemID];
                bag.itemList[currentItemID] = null;

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            if (eventData.pointerCurrentRaycast.gameObject.name == "slot2") //如果滑鼠碰到slot2
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                if (originalParent.name == "slot1" || originalParent.name == "slot3") //如果原位置是其他合成格
                {
                    combineArea.itemList[1] = combineArea.itemList[currentItemID];
                    combineArea.itemList[currentItemID] = null;
                    GetComponent<CanvasGroup>().blocksRaycasts = true;
                    return;
                }

                combineArea.itemList[1] = bag.itemList[currentItemID];
                bag.itemList[currentItemID] = null;

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            #endregion
        }

        transform.SetParent(originalParent);
        transform.position = originalParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
