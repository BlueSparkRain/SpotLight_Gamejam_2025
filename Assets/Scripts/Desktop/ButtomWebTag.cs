using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtomWebTag : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    Image image;
    Transform child;

    private void Start()
    {
        image=GetComponent<Image>();
        child=transform.GetChild(0);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(1,1,1,0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(1, 1, 1, 0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        child.DOLocalJump(Vector3.zero,10,1,0.3f,true);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(child.DOScale(Vector3.one * 1.2f, 0.15f));
        sequence.Append(child.DOScale(Vector3.one, 0.15f));

        sequence.SetAutoKill(true); // 动画播放完毕后自动销毁 Tween
        sequence.Play();            // 开始播放 Sequence
    }
}
