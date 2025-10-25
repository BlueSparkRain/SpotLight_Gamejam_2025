using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum E_ClueBoardPerson { 
    研究员,
    角色2,
    角色3,
    角色4,
}

[CreateAssetMenu(fileName = "PersonClueData", menuName = "SO_Data/PersonClueData")]
public class PersonClueSOData : ScriptableObject
{
   [Header("嫌疑人")]
   public E_ClueBoardPerson Person;
    [Header("嫌疑人照片")]
    public Sprite photo;
    [Header("嫌疑人姓名")]
    public string personName;
   [Header("年龄")]
   public int age;
   [Header("身份")]
   public string major;
   [Header("嫌疑人线索数据")]
   public List<PersonClueData> personClueDatas;
}

[Serializable]
public class PersonClueData {
    //[Header("线索ID")]
    //public int clueID;
    [Header("线索内容")]
    [TextArea]
    public string clueContent;
}