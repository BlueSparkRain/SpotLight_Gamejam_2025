using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskUnit : MonoBehaviour
{
    public TMP_Text contentText;
    public void Init(string content)
    {
        contentText.text = content;
    }
}
