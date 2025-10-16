using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtomAppTag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image image;
    Transform child;
    Button callButton;
    public E_APPType appType=E_APPType.聊天软件;

    //软件开启状态
    bool isAppOpening = false;
    APPCaller appCaller;

    public ButtomAppTag(E_APPType apptype) { 
        this.appType = apptype;
    }

    private void Start()
    {
        image = GetComponent<Image>();
        callButton = GetComponent<Button>();
        callButton?.onClick.AddListener(onClickCallButton);
        child = transform.GetChild(0);
    }


    void onClickCallButton()
    {
        if (!isAppOpening)
        {
            appCaller ??= APPCaller.Instance;
            Debug.Log(transform.position + "-" + this.name);
            appCaller.CallApp(appType, transform.position);
        }
        else
        {
            appCaller ??= APPCaller.Instance;
            Debug.Log(transform.position + "-" + this.name);
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

        sequence.SetAutoKill(true); // 动画播放完毕后自动销毁 Tween
        sequence.Play();            // 开始播放 Sequence
    }
}
