using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePanel :APPPanel
{
    
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
        APPTagsCaller.Instance.CloseAppTag(E_APPType.Ö±²¥Èí¼þ);
    }
    protected override void onclickminusButton()
    {
        base.onclickminusButton();
        UIManager.Instance.HidePanel<LivePanel>();
    }

    public override void ShowPanel()
    {
        base.ShowPanel();

    }

    public override void HidePanel()
    {
        base.HidePanel();
    }
}
