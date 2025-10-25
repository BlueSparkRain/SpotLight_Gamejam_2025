using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DialogueManager : MonoSingleton<DialogueManager>
{
    [Header("当前进行的对话线")]
    public DialogueDataSequence currentDialogueSq;
    DialoguePanel D_Panel;//对话面板

    private Dictionary<float, DialogueDataSequence> dialogueDic = new Dictionary<float, DialogueDataSequence>();

    [ContextMenu("打印所有对话数据ID")]
    void PrintDicID(){
        foreach (var kvp in dialogueDic){ 
            Debug.Log("DialogueManager-dic-key:"+ kvp.Key);
        }
    }

    int bigDialogueNum = 14;
    string AITalkSeqPath = "SO_Data/AIDialogueSequenceData/AITalkSeq";
    protected override void InitPlayer(){
        base.InitPlayer();
        DialogueDataSequence aiTalkData = null;
        for (int i = 1; i <= bigDialogueNum; i++){
            Addressables.LoadAssetAsync<DialogueDataSequence>(AITalkSeqPath + i).Completed += (obj) => {
                aiTalkData = obj.Result;
                dialogueDic.Add(aiTalkData.ID, aiTalkData);
            };
        }
    }
    /// <summary>
    /// 为目标对话线添加委托
    /// </summary>
    /// <param name="ID">对话线ID</param>
    /// <param name="index">事件触发的位置索引</param>
    /// <param name="action">对话委托</param>
    public void AddDialogueEvent(float ID, int index, Action action){
        currentDialogueSq.eventList.Add(new DialogueEvent(index, action));
    }

    /// <summary>
    /// 根据对话线的ID开启一段对话
    /// </summary>
    /// <param name="ID">对话线序号</param>
    /// <param name="action">对话委托</param>
    public void BeginDialogueSequence(float ID, Action action = null){
        SetCurrentDialogueSquence(ID);
        action?.Invoke();//接收对话委托
        UIManager.Instance.ShowPanel<DialoguePanel>(panel =>{
            panel.ShowDialogue(currentDialogueSq.dialogueLine[currentDialogueSq.currentIndex].speaker.ToString(),
                                                                currentDialogueSq.dialogueLine[currentDialogueSq.currentIndex].content,
                                                                currentDialogueSq.needTyping, currentDialogueSq.fadeDuration,
                                                                currentDialogueSq.canQuickShow, currentDialogueSq.canAutonNext);
            D_Panel = panel;
        }, null);
    }

    /// <summary>
    /// 用于隐藏当前文本并显示下一句文本
    /// </summary>
    public IEnumerator NextDialogue(){
        ActionCheck();
        if (currentDialogueSq?.currentIndex + 1 < currentDialogueSq?.dialogueLine.Count){
            currentDialogueSq.currentIndex++;
            D_Panel.ShowDialogue(currentDialogueSq.dialogueLine[currentDialogueSq.currentIndex].speaker.ToString(),
                                 currentDialogueSq.dialogueLine[currentDialogueSq.currentIndex].content,
                                 currentDialogueSq.needTyping, currentDialogueSq.fadeDuration,
                                 currentDialogueSq.canQuickShow, currentDialogueSq.canAutonNext);
        }
        else{
            EndDialogueSquence();//结束对话
        }
        yield return null;
    }

    /// <summary>
    /// 设置当前对话线
    /// </summary>
    /// <param name="ID">对话序列ID</param>
    void SetCurrentDialogueSquence(float ID){
        if (dialogueDic.ContainsKey(ID)){
            currentDialogueSq = dialogueDic[ID];
            currentDialogueSq.currentIndex = 0;
        }
        else
            Debug.Log("ERROR:未找到目标对话数据");
    }

    /// <summary>
    /// 每结束一句对话时检查是否有委托需要执行
    /// </summary>
    void ActionCheck(){
        if (currentDialogueSq){
            for (int i = 0; i < currentDialogueSq.eventList.Count; i++){
                if (currentDialogueSq.eventList[i].eventIndex == currentDialogueSq.currentIndex){
                    currentDialogueSq.eventList[i].MyEvent?.Invoke();
                    //Debug.Log("检测到对话事件触发！");
                }
            }
        }
    }

    /// <summary>
    /// 结束一段对话序列
    /// </summary>
    void EndDialogueSquence(){
        currentDialogueSq?.eventList.Clear();
        currentDialogueSq = null;
        UIManager.Instance.HidePanel<DialoguePanel>();
    }

    void OnApplicationQuit(){
        foreach (var item in dialogueDic) { 
            item.Value.currentIndex = 0;
        }
        dialogueDic.Clear();
        currentDialogueSq?.eventList.Clear();
        currentDialogueSq = null;
    }

}
