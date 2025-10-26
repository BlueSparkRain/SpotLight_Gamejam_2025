using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class LittleGameManager : MonoSingleton<LittleGameManager>
{
    string gamePaths= "Assets/Resources2/Prefab/LittleGame";
    UIManager uiManager;
    DialogueManager DialogueManagerInstance;

    protected override void InitPlayer()
    {
        base.InitPlayer();
        uiManager ??= UIManager.Instance;
        DialogueManagerInstance ??= DialogueManager.Instance;
    }

    public void Win() {

        SceneLoadManager.Instance.UnloadScene(2);
        //播放最后一段对话
        DialogueManagerInstance.BeginDialogueSequence(11, () =>
        {
            DialogueManagerInstance.AddDialogueEvent(11, 1, BeginPlayerSelect);
        });
    }

    void BeginPlayerSelect()
    {

        uiManager.ShowPanel<PlayerSelectPanel>(panel => {
            panel.CreateOneSelectButton("本次任务完美谢幕", () => {
                StartCoroutine(StartAITalk1());
            });

        }, null);
    }

    IEnumerator StartAITalk1()
    {
        yield return new WaitForSeconds(2);
        DialogueManagerInstance.BeginDialogueSequence(12, () =>
        {
            DialogueManagerInstance.AddDialogueEvent(12, 0, ShowLogo);

        });
    }

    void ShowLogo()
    {
        uiManager.ShowPanel<SceneTransPanel>(null, null);
        Debug.Log("ShiwLogo");
    }
}
