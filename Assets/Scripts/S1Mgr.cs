using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S1Mgr : MonoBehaviour
{
   #region UI控制

    public Slider slidHP;   //血量條
    public Slider slidStamina;  //耐力條
    public Scrollbar scrolArmsBar;  //武器欄
    public Scrollbar scrolHealBar;  //回血欄
    public Button btnMenu;  //回到主選單按鈕

    #endregion
    
    #region UI介面控制

    public CanvasGroup SettingCtrl;  //設定介面控制
    public CanvasGroup BagCtrl;  //背包介面控制
    public CanvasGroup MapCtrl;  //地圖介面控制
    
    #endregion

    private bool isBagOpen;
    private bool isMapOpen;
    private bool isSettingOpen;

    void Start()
    {
        isBagOpen = false;  //未打開背包
        isMapOpen = false;  //未打開地圖
        isSettingOpen = false;  //未打開設定

        //隱藏設定介面
        SettingCtrl.alpha = 0;
        SettingCtrl.blocksRaycasts = false;
        
        //隱藏背包介面
        BagCtrl.alpha = 0;
        BagCtrl.blocksRaycasts = false;

        //隱藏地圖介面
        MapCtrl.alpha = 0;
        MapCtrl.blocksRaycasts = false;

        slidHP.value = 100;  //初始血量設定

        slidStamina.value = 1;  //初始耐力設定
        scrolArmsBar.value = 0; //武器欄初始位置
        scrolHealBar.value = 0; //回血欄初始位置

        btnMenu.onClick.AddListener(OnBtnMenuClick);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //按Esc開/關設定
        {
            isSettingOpen = !isSettingOpen;
            
            if (isSettingOpen)
            {
                SettingCtrl.alpha = 1;
                SettingCtrl.blocksRaycasts = true;
            }
            else
            {
                CloseInterface();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))  //按Tab開/關背包
        {
            isBagOpen = !isBagOpen;
            
            if (isBagOpen)
            {
                BagCtrl.alpha = 1;
                BagCtrl.blocksRaycasts = true;
            }
            else
            {
                CloseInterface();
            }
        }

        if (Input.GetKeyDown(KeyCode.M))    //按M開/關地圖
        {
            isMapOpen = !isMapOpen;
            
            if (isMapOpen)
            {
                MapCtrl.alpha = 1;
                MapCtrl.blocksRaycasts = true;
            }
            else
            {
                CloseInterface();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) //按Q滑桿就往右跑，超過最大值就變第一格
        {
            scrolArmsBar.value += 1;
            if (scrolArmsBar.value > 1)
            {
                scrolArmsBar.value = 0;
            }
        }

        //按數字鍵跳到對應欄位
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            scrolHealBar.value = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            scrolHealBar.value = 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
    
        {
            scrolHealBar.value = 1;
        }

        if(slidStamina.value != 1)  //耐力條每秒回復0.1
        {
            slidStamina.value += 0.1f * Time.deltaTime;
        }
    }

    void CloseInterface()   //關閉介面
    {
        SettingCtrl.alpha = 0;
        SettingCtrl.blocksRaycasts = false;
        BagCtrl.alpha = 0;
        BagCtrl.blocksRaycasts = false;
        MapCtrl.alpha = 0;
        MapCtrl.blocksRaycasts = false;
    }

    void OnBtnMenuClick()
    {
        SceneManager.LoadScene("S0");
    }
}
