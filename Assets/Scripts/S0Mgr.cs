using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S0Mgr : MonoBehaviour
{
    public CanvasGroup imgPeopleCtrl;   //人員名單介面控制
    public CanvasGroup imgSettingCtrl;  //設定介面控制
    public CanvasGroup imgLoadCtrl;     //加載介面控制
    public CanvasGroup btnStartCtrl;    //開始按鈕控制
    public CanvasGroup btnLoadCtrl;     //加載按鈕控制
    public CanvasGroup btnSettingCtrl;  //設定按鈕控制
    public CanvasGroup btnPeopleCtrl;   //人員名單按鈕控制
    public CanvasGroup btnExitCtrl;     //離開按鈕控制
    
    public Button btnStart; //開始按鈕
    public Button btnLoad;  //加載按鈕
    public Button btnSetting;   //設定按鈕
    public Button btnPeople;    //人員名單按鈕
    public Button btnExit;  //離開按鈕

    public Button btnClosePeople;   //關閉人員名單
    public Button btnCloseLoad; //關閉加載
    public Button btnCloseSetting;  //關閉設定
    
    void Start()
    {
        //關閉所有介面
        imgPeopleCtrl.alpha = 0;
        imgPeopleCtrl.blocksRaycasts = false;
        imgSettingCtrl.alpha = 0;
        imgSettingCtrl.blocksRaycasts = false;
        imgLoadCtrl.alpha = 0;
        imgLoadCtrl.blocksRaycasts = false;
        
        btnStart.onClick.AddListener(OnBtnStartClick);
        btnLoad.onClick.AddListener(OnBtnLoadClick);
        btnSetting.onClick.AddListener(OnBtnSettingClick);
        btnPeople.onClick.AddListener(OnBtnPeopleClick);
        btnExit.onClick.AddListener(OnBtnExitClick);
        
        btnClosePeople.onClick.AddListener(OnBtnCloseClick);
        btnCloseLoad.onClick.AddListener(OnBtnCloseClick);
        btnCloseSetting.onClick.AddListener(OnBtnCloseClick);
    }

    void OnBtnStartClick()  //開始遊戲
    {
        SceneManager.LoadScene("S1");
    }
    
    void OnBtnLoadClick()   //加載遊戲
    {
        imgLoadCtrl.alpha = 1;
        imgLoadCtrl.blocksRaycasts = true;
        imgSettingCtrl.alpha = 0;
        imgSettingCtrl.blocksRaycasts = false;
        imgPeopleCtrl.alpha = 0;
        imgPeopleCtrl.blocksRaycasts = false;
        
        btnStartCtrl.alpha = 0;
        btnStartCtrl.blocksRaycasts = false;
        btnLoadCtrl.alpha = 0;
        btnLoadCtrl.blocksRaycasts = false;
        btnSettingCtrl.alpha = 0;
        btnSettingCtrl.blocksRaycasts = false;
        btnPeopleCtrl.alpha = 0;
        btnPeopleCtrl.blocksRaycasts = false;
        btnExitCtrl.alpha = 0;
        btnExitCtrl.blocksRaycasts = false;
    }
    
    void OnBtnSettingClick()    //打開設定
    {
        imgSettingCtrl.alpha = 1;
        imgSettingCtrl.blocksRaycasts = true;
        imgPeopleCtrl.alpha = 0;
        imgPeopleCtrl.blocksRaycasts = false;
        imgLoadCtrl.alpha = 0;
        imgLoadCtrl.blocksRaycasts = false;
        
        btnStartCtrl.alpha = 0;
        btnStartCtrl.blocksRaycasts = false;
        btnLoadCtrl.alpha = 0;
        btnLoadCtrl.blocksRaycasts = false;
        btnSettingCtrl.alpha = 0;
        btnSettingCtrl.blocksRaycasts = false;
        btnPeopleCtrl.alpha = 0;
        btnPeopleCtrl.blocksRaycasts = false;
        btnExitCtrl.alpha = 0;
        btnExitCtrl.blocksRaycasts = false;
    }

    void OnBtnPeopleClick() //打開人員名單
    {
        imgPeopleCtrl.alpha = 1;
        imgPeopleCtrl.blocksRaycasts = true;
        imgSettingCtrl.alpha = 0;
        imgSettingCtrl.blocksRaycasts = false;
        imgLoadCtrl.alpha = 0;
        imgLoadCtrl.blocksRaycasts = false;
        
        btnStartCtrl.alpha = 0;
        btnStartCtrl.blocksRaycasts = false;
        btnLoadCtrl.alpha = 0;
        btnLoadCtrl.blocksRaycasts = false;
        btnSettingCtrl.alpha = 0;
        btnSettingCtrl.blocksRaycasts = false;
        btnPeopleCtrl.alpha = 0;
        btnPeopleCtrl.blocksRaycasts = false;
        btnExitCtrl.alpha = 0;
        btnExitCtrl.blocksRaycasts = false;
    }
    
    void OnBtnExitClick()   //離開遊戲
    {
        Application.Quit();
    }

    void OnBtnCloseClick()  //關閉視窗
    {
        imgPeopleCtrl.alpha = 0;
        imgPeopleCtrl.blocksRaycasts = false;
        imgSettingCtrl.alpha = 0;
        imgSettingCtrl.blocksRaycasts = false;
        imgLoadCtrl.alpha = 0;
        imgLoadCtrl.blocksRaycasts = false;
        
        btnStartCtrl.alpha = 1;
        btnStartCtrl.blocksRaycasts = true;
        btnLoadCtrl.alpha = 1;
        btnLoadCtrl.blocksRaycasts = true;
        btnSettingCtrl.alpha = 1;
        btnSettingCtrl.blocksRaycasts = true;
        btnPeopleCtrl.alpha = 1;
        btnPeopleCtrl.blocksRaycasts = true;
        btnExitCtrl.alpha = 1;
        btnExitCtrl.blocksRaycasts = true;
    }
}
