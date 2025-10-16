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
        // 1. ����һ���µ� Sequence
        Sequence sequence = DOTween.Sequence();

        // 2. ����һ�����������ţ���ӵ� Sequence ����Ϊ Append
        // Append() �Ὣ��� Tween ���� Sequence ����ʼλ�� (ʱ�� 0)
        sequence.Append(root.DOScale(0, transTime));

        // 3. ʹ�� Join() ���ڶ����������ƶ�����ӵ� Sequence ��
        // Join() ȷ���ڶ��� Tween ��ǰһ�� Tween (�����Ŷ���) ͬʱ��ʼ
        // ����� Vector3.one ��һ��ʾ������ʾ�ƶ�����Ŀ��λ��
        sequence.Join(root.DOMove(bornPos, transTime));

        // 2. ����Э�̣��ȴ����������scaleTween���������
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
