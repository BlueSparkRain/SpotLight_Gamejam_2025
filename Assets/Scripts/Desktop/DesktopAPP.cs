using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

enum APP_Type
{
    �罻ý��,
    �������,
}

public class DesktopAPP : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerClickHandler,
                                        IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //��¼�������
    public int clickCount;
    
    float timer;
    //��ǰ�Ĳ�λ
    DesktopAPPSlot slot;
    //�洢��ק֮ǰ�Ĳ�λ
    DesktopAPPSlot pre_slot;
    Image image;

    //��ǰ����ѡ��
    bool isSelecting;
    //bool isDraging;

    public void freeSelect(){
        isSelecting = false;
        slot?.HideSlot();
        }
    public void setSelect() => isSelecting = true;

    //����̽��
    private GraphicRaycaster m_Raycaster;
    private EventSystem m_EventSystem;

    private PointerEventData m_PointerEventData;
    public void OnPointerClick(PointerEventData eventData)
    {
        SelectSelf();
        clickCount++;
        timer = 1;
    }

    void SelectSelf() {
        isSelecting = true;
        EventCenter.Instance.EventTrigger(E_EventType.E_selectNewApp, this);
    }

    void Start()
    {
        image = GetComponent<Image>();
        m_EventSystem ??= EventSystem.current;
        m_Raycaster ??= GetComponent<GraphicRaycaster>();
        EventCenter.Instance.AddEventListener(E_EventType.E_mouseFree, freeSelect);
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

        if (clickCount > 1)
        {
            //��������������
            image.color = Color.red;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        clickCount=0;
        //isDraging = true;
        SelectSelf();

        //��קAPP���ͷű���
        slot?.getApp(false);
        pre_slot = slot;
        slot= null;

        EventCenter.Instance.EventTrigger(E_EventType.E_mouseFree);
        
        //GameSceneManager.Instance.isDragingAPP = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //isDraging = false;
        
        //��ק��ϣ��ͷ�AP��ѡ������Ĳ�λ
        //GameSceneManager.Instance.isDragingAPP = false;

        EventCenter.Instance.EventTrigger(E_EventType.E_dragAPPDone);
        if (GameSceneManager.Instance.targetEmptSlot.HasApp) {
            Debug.Log("ERROR:Ŀ�������");
            slot = pre_slot;
        }
        else {
            //��λ���²�
            Debug.Log("�ɹ�����Ŀ���");
            slot = GameSceneManager.Instance.targetEmptSlot;
        }

        slot.getApp(true);


        transform.SetParent(slot.transform);
        transform.localPosition=Vector3.zero;

        EventCenter.Instance.EventTrigger(E_EventType.E_mouseFree);
        
        isSelecting = true;
        slot.ShowSlot();
    }
}
