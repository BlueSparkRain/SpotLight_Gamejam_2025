using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClueBoardPersonData : MonoBehaviour
{
    [Header("人物照片")]
    public Image photo;
    [Header("人物姓名")]
    public TMP_Text nameText;
    [Header("人物年龄")]
    public TMP_Text ageText;
    [Header("人物身份")]
    public TMP_Text majorText;

    [Header("线索板")]
    public Transform clueContent;

    /// <summary>
    /// 设置名字
    /// </summary>
    /// <param name="name"></param>
    public void setName(string name) => nameText.text = name;
    /// <summary>
    /// 设置年龄
    /// </summary>
    /// <param name="age"></param>
    public void setAge(int age) => ageText.text = age.ToString();
    /// <summary>
    /// 设置身份
    /// </summary>
    /// <param name="major"></param>
    public void setMajor(string major) => majorText.text = major;

    /// <summary>
    /// 添加新线索
    /// </summary>
    /// <param name="obj"></param>
    public void AddNewClue(Transform obj) {
        obj.SetParent(clueContent);
    
    }


}
