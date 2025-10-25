using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum E_DisplayType{
    Defalut, Fading, Typing
}

public class DialoguePanel : BasePanel
{
    [Header("高级文本")]
    public AdvancedText displayText;
    [Header("文本讲述者")]
    public TMP_Text speakerNameText;
    [Header("触摸板")]
    public Button touchButton;

    //可以快速显示
    bool _canQuickShow;
    //自动显示下一句
    bool _canAutonNext;

    /// <summary>
    /// 显示对话框
    /// </summary>
    /// <param name="speaker">讲述者</param>
    /// <param name="content">内容</param>
    /// <param name="needTyping">使用打字机效果</param>
    /// <param name="fadeDuration">打印间隔</param>
    /// <param name="canQickShow">快速显示</param>
    /// <param name="canAutonNext">自动下一句</param>
    public void ShowDialogue(string speaker, string content, bool needTyping = true, float fadeDuration = 0.2f, bool canQickShow = true, bool canAutonNext = false)
    {
        speakerNameText.text = speaker;

        if (displayText.text != "")
            displayText.TextDisAppear();

        _canQuickShow = canQickShow;
        _canAutonNext = canAutonNext;

        if (needTyping)
            StartCoroutine(displayText.ShowText(content, E_DisplayType.Typing, fadeDuration));
        else
            StartCoroutine(displayText.ShowText(content, E_DisplayType.Fading, fadeDuration));
    }

    void OnClickNextButton()
    {
        if (displayText.typingCor != null)
            displayText.TextQuickShow();
        else
            StartCoroutine(DialogueManager.Instance.NextDialogue());
    }

    public override void HidePanel()
    {
        base.HidePanel();
        displayText.TextDisAppear();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(root.DOLocalMove(new Vector3(0,-500,0), transTime));
        yield return sequence.WaitForCompletion();
    }

    public override void ShowPanel(){
        base.ShowPanel();
    }
    public override IEnumerator ShowPanelTweenEffect()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(root.DOLocalMove(Vector3.zero, transTime));
        yield return sequence.WaitForCompletion();
    }
    bool isInit=false;
    protected override void Init()
    {
        base.Init();
        if (!isInit)
        {
            touchButton.onClick.AddListener(OnClickNextButton);
            isInit = true;
        }
        root.localPosition = new Vector3(0, -1000, 0);
    }
}
