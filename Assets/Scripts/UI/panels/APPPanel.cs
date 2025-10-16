using DG.Tweening;
using System.Collections;
using UnityEngine;

public class APPPanel : BasePanel
{
    protected Vector3 bornPos = Vector3.zero;
    public void SetWebBornPos(Vector3 _bornpos)
    {
        Debug.Log("cacskad:"+_bornpos);
        bornPos = _bornpos;
    }
    public override void HidePanel()
    {
        base.HidePanel();
    }
    public override IEnumerator HidePanelTweenEffect()
    {
        // 1. 创建一个新的 Sequence
        Sequence sequence = DOTween.Sequence();

        // 2. 将第一个动画（缩放）添加到 Sequence 中作为 Append
        // Append() 会将这个 Tween 放在 Sequence 的起始位置 (时间 0)
        sequence.Append(root.DOScale(0, transTime));

        // 3. 使用 Join() 将第二个动画（移动）添加到 Sequence 中
        // Join() 确保第二个 Tween 与前一个 Tween (即缩放动画) 同时开始
        // 这里的 Vector3.one 是一个示例，表示移动到的目标位置
        sequence.Join(root.DOMove(bornPos, transTime));

        // 2. 告诉协程：等待这个动画（scaleTween）播放完成
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

    protected override void Init()
    {
        base.Init();
    }
}
