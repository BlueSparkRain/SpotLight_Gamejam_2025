using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="BlogData",menuName = "SO_Data/BlogData")]
public class BlogSOData :ScriptableObject
{
    [Header("BlogID")]
   public float ID;
   public List<BlogData> blogDatas = new List<BlogData>();
}

[Serializable]
public class BlogData {
    [Header("发布日期")]
    public  string datatime;
    [TextArea]
    [Header("条目内容")]
    public string content;
}