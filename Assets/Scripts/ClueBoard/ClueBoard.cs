using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ClueBoard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Transform pivot;
    [Header("ËõÂÔ°´Å¥")]
    public Button minusButton;
    [Header("¹Ø±Õ°´Å¥")]
    public Button delButton;
    Vector3 popPos;
    Vector3 bornPos;
    Vector3 hidePos;
    Vector3 closePos;
    public ClueBoardTag clueTag;
    float animTime=0.4f;

    bool isHiding;
    void Start()
    {
        pivot = transform.parent;
        bornPos = pivot.position;
        popPos = pivot.position - new Vector3(250, 0, 0);
        hidePos = pivot.position + new Vector3(400, 0, 0);
        closePos = pivot.position + new Vector3(500, 0, 0);

        pivot.position = closePos;
        minusButton.onClick.AddListener(HideBoard);
        delButton.onClick.AddListener(CloseBoard);
    }
    public void HideBoard()
    {
        isHiding = true;
        pivot.DOMove(hidePos, animTime);
    }
    public void CloseBoard()
    {
        isHiding = false;
        pivot.DOMove(closePos, animTime);
        clueTag.ShowTag();
    }
    public void ShowBoard()
    {
        pivot.DOMove(bornPos, animTime);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isHiding)
        {
            ShowBoard();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isHiding)
        {
            HideBoard();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isHiding)
        {
            ShowBoard();
            isHiding = false;
        }
    }
}
