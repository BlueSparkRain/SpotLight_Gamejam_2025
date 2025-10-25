using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivePanel :APPPanel
{
    public TMP_Text  timerText; 

    private float elapsedTime; // 累积的时间

    void Update()
    {
        // 1. 累加时间
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f); // 总秒数除以60取整得分钟
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);  // 总秒数除以60取余得秒
   
        //int milliseconds = Mathf.FloorToInt((elapsedTime * 100f) % 100f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // 4. 更新 UI 文本
        timerText.text = timeString;
    }

    public void StopTimer()
    {
        enabled = false; // 禁用此脚本的 Update 方法
    }

    // 重置计时器
    public void ResetTimer()
    {
        elapsedTime = 0f;
        timerText.text = "00:00";
    }

    void FrezzeButtons() {

        minusButton.interactable = false;
        delButton.interactable = false;
    }

    void ActiveButtons() {
        minusButton.interactable = true;
        delButton.interactable = true;
    }
    protected override void Init()
    {
        base.Init();

        eventCenter.AddEventListener(E_EventType.E_FreezeLivePanel, FrezzeButtons);
        eventCenter.AddEventListener(E_EventType.E_ActiveLivePanel, ActiveButtons);
    }
    
    private void OnDisable()
    {
        eventCenter.RemoveEventListener(E_EventType.E_FreezeLivePanel, FrezzeButtons);
        eventCenter.RemoveEventListener(E_EventType.E_ActiveLivePanel, ActiveButtons);
    }

    protected override void onclickDelButton()
    {
        base.onclickDelButton();
        UIManager.Instance.HidePanel<LivePanel>();
        APPTagsCaller.Instance.CloseAppTag(E_APPType.直播软件);
    }
    protected override void onclickminusButton()
    {
        base.onclickminusButton();
        UIManager.Instance.HidePanel<LivePanel>();
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        ResetTimer();

    }

    public override void HidePanel()
    {
        base.HidePanel();
        StopTimer();
    }
}
