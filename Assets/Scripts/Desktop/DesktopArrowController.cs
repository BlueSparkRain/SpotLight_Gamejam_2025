using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class DesktopArrowController : MonoBehaviour
{
    [Header("0:聊天  1：社媒  2：直播 3：线索板")]
    public List<Transform> apps = new List<Transform>();
    public Transform arrow;
    EventCenter eventCenter;
    private void OnEnable()
    {
        eventCenter = EventCenter.Instance;
        eventCenter.AddEventListener<int>(E_EventType.E_ArrowAppear,ShowArrow);
        eventCenter.AddEventListener(E_EventType.E_ArrowHide, HideArroow);
    }

    /// <summary>
    /// ID:0:聊天  1：社媒  2：直播
    /// </summary>
    /// <param name="appID"></param>
    public void ShowArrow(int appID)
    {
        if (appID > apps.Count) {
            Debug.Log("ERROR:索引超过软件数目！");
            return;
        }
        Transform parent = apps[appID].parent;
        arrow.transform.SetParent(parent);
        arrow.localPosition = new Vector3(0,-80,0);
        arrow.DOScale(0.8f,0.2f);
        arrow.GetComponent<CanvasGroup>().DOFade(1, 0.1f);
        arrow.DOLocalMoveY(-200, 0.1f).From();
    }

    public void HideArroow() {
        arrow.DOScale(0, 0.2f);
        arrow.DOLocalMoveY(-200, 0.1f);
        arrow.GetComponent<CanvasGroup>().DOFade(0, 0.1f);
    }

    private void OnDisable()
    {
        eventCenter.RemoveEventListener<int>(E_EventType.E_ArrowAppear, ShowArrow);
        eventCenter.RemoveEventListener(E_EventType.E_ArrowHide, HideArroow);
    }
}
