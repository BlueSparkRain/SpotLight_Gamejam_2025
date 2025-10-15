using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransPanel : BasePanel
{
    public override void HidePanel()
    {


    }

    public override IEnumerator HidePanelTweenEffect()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(root.DOScale(0, transTime));
        sequence.Join(root.DOMove(Vector3.zero, transTime));
        yield return sequence.WaitForCompletion();
        yield return null;
    }

    public override void ShowPanel()
    {

    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        root.position = Vector3.zero;
        // 1. ����һ���µ� Sequence
        Sequence sequence = DOTween.Sequence();

        // 2. ����һ�����������ţ���ӵ� Sequence ����Ϊ Append
        // Append() �Ὣ��� Tween ���� Sequence ����ʼλ�� (ʱ�� 0)
        sequence.Append(root.DOScale(1, transTime));

        // 3. ʹ�� Join() ���ڶ����������ƶ�����ӵ� Sequence ��
        // Join() ȷ���ڶ��� Tween ��ǰһ�� Tween (�����Ŷ���) ͬʱ��ʼ
        // ����� Vector3.one ��һ��ʾ������ʾ�ƶ�����Ŀ��λ��
        sequence.Join(root.DOLocalMove(Vector3.zero, transTime));

        yield return sequence.WaitForCompletion();
    }

    protected override void Init()
    {
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
