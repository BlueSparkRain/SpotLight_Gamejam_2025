using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class ClueUnit : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [Header("线索文本")]
    public TMP_Text contentText;
    [Header("Image")]
    public Image image;
    private RectTransform rectTransform;

    private void Awake()
    {
        contentText=GetComponentInChildren<TMP_Text>();
        rectTransform= GetComponent<RectTransform>();   
    }

    public void Init(string content) { 
        contentText.text = content;
        FitHeight();
    }

    //根据文本量调整自身长短
    public void FitHeight() { 
    
    
    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.black;
     
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      image.color = Color.white;
    }
}
