using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class APPPanel : BasePanel
{
    protected Vector3 bornPos = Vector3.zero;
    [Header("缩略窗口按钮")]
    public Button minusButton;
    [Header("关闭窗口按钮")]
    public Button delButton;

    public E_APPType appType;

    //关闭应用
    protected virtual void onclickDelButton(){
    }
    //缩略应用
    protected virtual void onclickminusButton(){
        EventCenter.Instance.EventTrigger<E_APPType>(E_EventType.E_minusApp,appType);
    }

    public void SetWebBornPos(Vector3 _bornpos)
    {
        bornPos = _bornpos;
    }

    public override void HidePanel()
    {
        base.HidePanel();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(root.DOScale(0, transTime));
        sequence.Join(root.DOMove(bornPos, transTime));
        yield return sequence.WaitForCompletion();

    }
    public override void ShowPanel()
    {
        base.ShowPanel();
    }

    public override IEnumerator ShowPanelTweenEffect()
    { 
        root.localScale = Vector3.zero;
        root.position = bornPos;
        Sequence sequence = DOTween.Sequence();

        sequence.Append(root.DOScale(1, transTime));
        sequence.Join(root.DOLocalMove(Vector3.zero, transTime));
        yield return sequence.WaitForCompletion();
    }


    protected override void Awake()
    {
        base.Awake();
        //minusButton.onClick.AddListener(onclickminusButton);
        //delButton.onClick.AddListener(onclickDelButton);
    }
  

    protected override void Init()
    {
        minusButton.onClick.AddListener(onclickminusButton);
        delButton.onClick.AddListener(onclickDelButton);
    }
}
