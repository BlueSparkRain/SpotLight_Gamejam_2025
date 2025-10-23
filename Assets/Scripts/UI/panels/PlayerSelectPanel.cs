using DG.Tweening;
using System.Collections;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerSelectPanel : BasePanel
{
    CanvasGroup canvasGroup;
    [Header("选择按钮")]
    string  buttonPrefabPath= "Prefab/基础元素/玩家选择按钮/PlayerSelectButton";

    public Transform buttonsContainer;

    public override void HidePanel()
    {
        base.HidePanel();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(canvasGroup.DOFade(0, transTime));
        yield return sequence.WaitForCompletion();
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Join(canvasGroup.DOFade(1, transTime));
        yield return sequence.WaitForCompletion();
    }

    public void CreateOneSelectButton(string content, UnityAction action) {
        Button newButton;
        Addressables.InstantiateAsync(buttonPrefabPath, buttonsContainer).Completed += (handle) =>
        {
            handle.Result.GetComponentInChildren<TMP_Text>().text=content;
            newButton= handle.Result.GetComponent<Button>();
            newButton.onClick.AddListener(action);
            newButton.onClick.AddListener(() => { UIManager.Instance.HidePanel<PlayerSelectPanel>();});  
        };
    }

    protected override void Init()
    {
        base.Init();
        canvasGroup=GetComponent<CanvasGroup>();

        
    }
}
