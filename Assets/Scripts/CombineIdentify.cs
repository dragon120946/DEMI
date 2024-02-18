using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CombineIdentify : MonoBehaviour
{
    public Button btnCombine;
    public InventoryCreate combine;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    private bool isAxe = false;
    private bool isGasLamp = false;
    private bool isGasLampPow = false;
    private bool isLightSword = false;
    void Start()
    {
        btnCombine.interactable = false;
        btnCombine.onClick.AddListener(OnBtnCombineClick);
    }

    void Update()
    {
        //斧頭
        if ((combine.itemList[0].name == "Branch" && combine.itemList[1].name == "Glass") 
            ||(combine.itemList[0].name == "Glass" && combine.itemList[1].name == "Branch"))
        {
            isAxe = true;
            btnCombine.interactable = true;
        }
        else
        {
            isAxe = false;
            btnCombine.interactable = false;
        }
        
        if ((combine.itemList[0].name == "Flashlight" && combine.itemList[1].name == "R.Gem") 
            ||(combine.itemList[0].name == "R.Gem" && combine.itemList[1].name == "Flashlight"))
        {
            isLightSword = true;
            btnCombine.interactable = true;
        }
        else
        {
            isLightSword = false;
            btnCombine.interactable = false;
        }
        
        if ((combine.itemList[0].name == "Battery" && combine.itemList[1].name == "TinPaper") 
            ||(combine.itemList[0].name == "TinPaper" && combine.itemList[1].name == "Battery"))
        {
            isGasLamp = true;
            btnCombine.interactable = true;
        } 
        else
        {
            isGasLamp = false;
            btnCombine.interactable = false;
        }
        
        if ((combine.itemList[0].name == "GasLamp" && combine.itemList[1].name == "Lighter") 
              ||(combine.itemList[0].name == "Lighter" && combine.itemList[1].name == "GasLamp"))
        {
            isGasLampPow = true;
            btnCombine.interactable = true;
        }
        else
        {
            isGasLampPow = false;
            btnCombine.interactable = false;
        }
    }

    void OnBtnCombineClick()
    {
        Debug.Log(123);
        Destroy(slot1.transform.GetChild(1));
        Destroy(slot2.transform.GetChild(1));
        
        if (isAxe)
        {
            
        }

        if (isGasLamp)
        {
            
        }

        if (isGasLampPow)
        {
            
        }

        if (isLightSword)
        {
            
        }
    }
}
