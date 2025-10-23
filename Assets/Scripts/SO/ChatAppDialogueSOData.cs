using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;


[CreateAssetMenu(fileName = "ChatAppDialogueData", menuName = "SO_Data/ChatAppDialogueData")]
public class ChatAppDialogueSOData : ScriptableObject
{
    [TextArea]
    [Header("简要描述信息")]
    public string Discription;

    [Header("对话流ID")]
    public float CharAppDialogueID;
    public List<CharAppDialogueData> data=new List<CharAppDialogueData>();
}

[Serializable]
public class CharAppDialogueData {
    [Header("人物")]
    public E_ChatDialogueType DialogueType = E_ChatDialogueType.AuraMind;
    [Header("内容")]
    [TextArea]
    public string content;
}

public enum E_ChatDialogueType
{
    AuraMind,
    Player,
    UnKnown,
}
