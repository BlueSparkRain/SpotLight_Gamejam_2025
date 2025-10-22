using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClueUnit : MonoBehaviour
{
    [Header("线索文本")]
    public TMP_Text contentText;

    private RectTransform rectTransform;

    private void Awake()
    {
        contentText=GetComponentInChildren<TMP_Text>();
        rectTransform= GetComponent<RectTransform>();   
    }

    //根据文本量调整自身长短
    public void FitHeight() { 
    
    
    
    }
}
