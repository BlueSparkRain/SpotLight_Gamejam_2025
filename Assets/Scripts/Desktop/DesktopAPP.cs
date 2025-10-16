using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum E_APPType
{
    社交媒体,
    聊天软件,
    直播软件,
}

public class DesktopAPP : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerClickHandler,
                                        IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //记录点击次数
    public int clickCount;
    
    float timer;
    //当前的槽位
    DesktopAPPSlot slot;
    //存储拖拽之前的槽位
    DesktopAPPSlot pre_slot;
    Image image;

    //当前正被选择
    bool isSelecting;

    public E_APPType apptype;

    bool appIsRuning = false;


    public void freeSelect(){
        isSelecting = false;
        slot?.HideSlot();
        }
    public void setSelect() => isSelecting = true;

    //射线探测
    private GraphicRaycaster m_Raycaster;
    private EventSystem m_EventSystem;

    private PointerEventData m_PointerEventData;
    public void OnPointerClick(PointerEventData eventData)
    {
        selectSelf();
        clickCount++;
        timer = 1;
    }

    void selectSelf() {
        isSelecting = true;
        EventCenter.Instance.EventTrigger(E_EventType.E_selectNewApp, this);
    }

    void onAppClose(E_APPType _apptype) {
        if (apptype == _apptype)
        {
            image.color = Color.white;
            appIsRuning = false;
        }
    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener(E_EventType.E_mouseFree, freeSelect);
        EventCenter.Instance.AddEventListener<E_APPType>(E_EventType.E_closeApp, onAppClose);
    }

    void Start()
    {
        image = GetComponent<Image>();
        m_EventSystem ??= EventSystem.current;
        m_Raycaster ??= GetComponent<GraphicRaycaster>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        slot ??= transform.parent.GetComponent<DesktopAPPSlot>();
        slot?.ShowSlot();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelecting)
            slot?.HideSlot();
    }

    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else clickCount = 0;

        if (!appIsRuning && clickCount > 1)
        {
            clickCount = 0;
            appIsRuning = true;
            //打开软件：呼叫面板
            image.color = Color.black;
            APPTagsCaller.Instance.CallNewAppTag(apptype);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        clickCount=0;
        selectSelf();

        //拖拽APP，释放本槽
        slot?.GetApp(false);
        pre_slot = slot;
        slot= null;

        EventCenter.Instance.EventTrigger(E_EventType.E_mouseFree);
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //isDraging = false;
        
        //拖拽完毕，释放AP，选择最近的槽位
        //GameSceneManager.Instance.isDragingAPP = false;

        EventCenter.Instance.EventTrigger(E_EventType.E_dragAPPDone);
        if (GameSceneManager.Instance.targetEmptSlot.HasApp) {
            Debug.Log("ERROR:目标槽已满");
            slot = pre_slot;
        }
        else {
            //归位至新槽
            Debug.Log("成功移至目标槽");
            slot = GameSceneManager.Instance.targetEmptSlot;
        }

        slot.GetApp(true);


        transform.SetParent(slot.transform);
        transform.localPosition=Vector3.zero;

        EventCenter.Instance.EventTrigger(E_EventType.E_mouseFree);
        
        isSelecting = true;
        slot.ShowSlot();
    }
}
