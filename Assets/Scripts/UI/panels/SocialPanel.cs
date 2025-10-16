using DG.Tweening;
using System.Collections;
using UnityEngine;
public class SocialPanel : APPPanel
{
    protected override void onclickDelButton()
    {
        base.onclickDelButton();
        UIManager.Instance.HidePanel<SocialPanel>();
        APPTagsCaller.Instance.CloseAppTag(E_APPType.Éç½»Ã½Ìå);
    }
    protected override void onclickminusButton()
    {
        base.onclickminusButton();
        UIManager.Instance.HidePanel<SocialPanel>();
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
