using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesktopAppSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    Image slotBack;
    void Start()
    {
        slotBack = GetComponent<Image>();
        EventCenter.Instance.AddEventListener(E_EventType.E_BossHit, HideSlot);
    }

    public void ShowSlot()
    {
        slotBack.color = new Color(1, 1, 1, 0.2f);
    }
    public void HideSlot()
    {
        slotBack.color = new Color(1, 1, 1, 0);
    }
  
    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
