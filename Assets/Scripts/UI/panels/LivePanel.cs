using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePanel :APPPanel
{
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
