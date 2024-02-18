using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item",menuName = "Inventory/New Item")]    //在unity中創建一個項目
public class ItemCreate : ScriptableObject    //必須配合Create Asset Nenu  https://kendevlog.wordpress.com/2017/11/10/unity%E5%AD%B8%E7%BF%92%E7%AD%86%E8%A8%988-scriptable-object%E4%BD%BF%E7%94%A8%E9%A0%88%E7%9F%A5/
{
    public string itemName;
    [TextArea]  //可讓文字變成多行
    public string info;
    public int count;
    public Sprite sprite;
    public bool canCombine;
}
