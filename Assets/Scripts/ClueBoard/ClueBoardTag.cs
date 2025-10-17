using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClueBoardTag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image backImage;
    Transform pivot;
    Vector3 showPos;
    Vector3 closePos;
    public ClueBoard clueBoard;

    float animTime = 0.4f;
    private void Start()
    {
        pivot = transform.parent;
        backImage = transform.parent.GetComponent<Image>();
        backImage.enabled = false;

        showPos = pivot.position;
        closePos = pivot.position + new Vector3(500, 0, 0);
    }

    public void CloseTag()
    {
        pivot.DOMove(closePos, animTime);
    }

    public void ShowTag()
    {
        pivot.DOMove(showPos, animTime);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CloseTag();
        clueBoard.ShowBoard();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        backImage.enabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        backImage.enabled = false;
    }
}
