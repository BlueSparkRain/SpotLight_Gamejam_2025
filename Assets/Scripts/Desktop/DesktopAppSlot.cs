using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesktopAPPSlot : MonoBehaviour,IPointerClickHandler
{
    Image slotBack;
    bool hasApp=false;
    
    [ContextMenu("´òÓ¡Î»ÖÃ")]
    void printPos(){
        Debug.Log(transform.position);
    }

    public bool HasApp {  get { return hasApp; } }
    public void GetApp(bool istrue)=>hasApp=istrue;  

    void Start()
    {
        slotBack = GetComponent<Image>();
        EventCenter.Instance.AddEventListener(E_EventType.E_mouseFree, HideSlot);
        if(transform.childCount !=0 )
        hasApp = true;
    }

    public void ShowSlot()
    {
        slotBack.color = new Color(1, 1, 1, 0.2f);
    }
    public void HideSlot()
    {
        //Debug.Log("Òþ²Ø£¡");
        slotBack.color = new Color(1, 1, 1, 0);
    }
  

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!hasApp)
            EventCenter.Instance.EventTrigger(E_EventType.E_mouseFree);
    }
}
