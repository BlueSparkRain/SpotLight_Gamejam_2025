using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSequenceData", menuName = "SO_Data/DialogueSequenceData")]
public class DialogueDataSequence : ScriptableObject
{
    [Header("对话线ID")]
    public float ID;
    [Header("自动下一句")]
    public bool canAutonNext;
    [Header("可以快进")]
    public bool canQuickShow;
    [Header("打字机效果")]
    public bool needTyping;
    [Header("当前话语序号")]
    public int currentIndex;
    [Header("淡入时间")]
    public float fadeDuration;
    [Header("事件线")]
    public List<DialogueEvent> eventList = new List<DialogueEvent>();
    [Header("对话线")]
    public List<DialogueData> dialogueLine = new List<DialogueData>();
}
[Serializable]
public class DialogueEvent
{
    [Header("EventIndex")]
    public int eventIndex;
    [Header("UnityEvent")]
    public Action MyEvent;

    public DialogueEvent(int _eventIndex, Action _action)
    {
        eventIndex = _eventIndex;
        MyEvent = _action;
    }
}

[Serializable]
public class DialogueData
{
    [Header("讲述者")]
    public E_AIDialogueType speaker;
    [TextArea]
    [Header("内容文本")]
    public string content;
}


public enum E_AIDialogueType
{
    AuraMind,
    Player,
    UnKnown,
}