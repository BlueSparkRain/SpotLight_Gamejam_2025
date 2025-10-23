using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_ClueBoardPerson { 
    角色1,
    角色2,
    角色3,
    角色4,
}

[CreateAssetMenu(fileName = "PersonClueData", menuName = "SO_Data/PersonClueData")]
public class PersonClueSOData : ScriptableObject
{
   [Header("嫌疑人")]
   public E_ClueBoardPerson Person;
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