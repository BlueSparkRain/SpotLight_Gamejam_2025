using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransPanel : BasePanel
{
    public CanvasGroup canvasGroup;
    public override void HidePanel(){
    }

    public void onClickExitButton() { 
    Application.Quit();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(canvasGroup.DOFade(0,0.5f));
        yield return sequence.WaitForCompletion();
        yield return null;
    }

    public override void ShowPanel()
    {

    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        // 1. 创建一个新的 Sequence
        Sequence sequence = DOTween.Sequence();
        sequence.Append(canvasGroup.DOFade(1, 0.5f));
        yield return sequence.WaitForCompletion();
    }

    protected override void Init()
    {
        base.Init();
    }
}
