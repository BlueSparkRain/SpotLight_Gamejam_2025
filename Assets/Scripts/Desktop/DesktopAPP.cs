using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesktopAPP : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler,IPointerClickHandler
{
    public int clickCount;
    float timer;
    DesktopAppSlot slot;
    Image image;
    public void OnPointerClick(PointerEventData eventData)
    {
        clickCount++;
        timer = 1; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        slot??=transform.parent.GetComponent<DesktopAppSlot>();
        slot?.ShowSlot();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slot?.HideSlot();
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0){
            timer -= Time.deltaTime;
        }
        else
            clickCount=0;


        if (clickCount >1)
        {
            //打开软件：呼叫面板
            image.color = Color.red;
        }
    }
}
