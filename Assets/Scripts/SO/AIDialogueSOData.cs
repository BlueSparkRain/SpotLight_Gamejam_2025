using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;


[CreateAssetMenu(fileName = "AIDialogueData", menuName = "SO_Data/AIDialogueData")]
public class AIDialogueSOData : ScriptableObject
{
    [TextArea]
    [Header("简要描述信息")]
    public string Discription;

    [Header("对话流ID")]
    public float AIDialogueID;
    public List<AIDialogueData> data=new List<AIDialogueData>();
}


[Serializable]
public class AIDialogueData {
    [Header("人物")]
    public E_AIDialogueType DialogueType = E_AIDialogueType.AuraMind;
    [Header("内容")]
    [TextArea]
    public string content;
}

public enum E_AIDialogueType
{
    AuraMind,
    Player,
    UnKnown,
}
