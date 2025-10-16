using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtomAppTag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image image;
    Transform child;
    Button callButton;
    public E_APPType appType=E_APPType.�������;

    //�������״̬
    bool isAppOpening = false;
    APPCaller appCaller;

    public void Init(E_APPType apptype) { 
        this.appType = apptype;
    }

    void onAppMinus(E_APPType _apptype) {
        if (appType == _apptype)
        {
           // appCaller = APPCaller.Instance;
            isAppOpening = !isAppOpening;
        }
    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener<E_APPType>(E_EventType.E_minusApp,onAppMinus);    
    }

    private void Awake()
    {
        appCaller ??= APPCaller.Instance;
        image = GetComponent<Image>();
        callButton = GetComponent<Button>();
        callButton.onClick.AddListener(onClickCallButton);
        child = transform.GetChild(0);
    }

    public void onClickCallButton()
    {
        if (!isAppOpening)
        {
            appCaller = APPCaller.Instance;
            appCaller.CallApp(appType, transform.position);
        }
        else
        {
            appCaller = APPCaller.Instance;
            appCaller.HideApp(appType);
        }
        isAppOpening = !isAppOpening;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(1, 1, 1, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(1, 1, 1, 0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        child.DOLocalJump(Vector3.zero, 10, 1, 0.3f, true);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(child.DOScale(Vector3.one * 1.2f, 0.15f));
        sequence.Append(child.DOScale(Vector3.one, 0.15f));

        sequence.SetAutoKill(true); // ����������Ϻ��Զ����� Tween
        sequence.Play();            // ��ʼ���� Sequence
    }
}
