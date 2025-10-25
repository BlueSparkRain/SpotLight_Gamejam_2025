using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CollectableClue : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image image;
    [Header("线索内容")]
    public string clueContent;
    [Header("end")]
    public Transform end;

    [Header("确认面板")]
    public Transform confirmBoard;

    bool isBoardOpen=false;
 
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isBoardOpen)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(confirmBoard.DOMove(transform.position, 0.2f));
            sequence.Join(confirmBoard.DOScale(Vector3.zero, 0.2f));
        }
        else
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(confirmBoard.DOMove(end.position, 0.2f));
            sequence.Join(confirmBoard.DOScale(Vector3.one, 0.2f));
        }
        isBoardOpen = !isBoardOpen;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(255,0,0,50);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(0, 0, 0, 50);
       
    }
    
}
