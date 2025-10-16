using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor.Rendering;
using UnityEngine;

public class APPTagsCaller : MonoSingleton<APPTagsCaller>
{
    public List<E_APPType>  appTypeList = new List<E_APPType>();

    //App标签预制件
    public GameObject appTagObjRef;

    [Header("桌面底部应用标签-父容器")]
    public HorizontalContainer appTagsContainer;
    public void CallNewAppTag(E_APPType apptype)
    {

        if (appTypeList.Contains(apptype)) {
            Debug.Log("此应用为单例模式");
            return;
        }
        else {
            appTypeList.Add(apptype);
            GameObject tagobj;
            tagobj = Instantiate(appTagObjRef);
            tagobj.GetComponent<ButtomAppTag>().Init(apptype);
            appTagsContainer.Add(tagobj.transform);

            APPCaller.Instance.CallApp(apptype,tagobj.transform.position);
            EventCenter.Instance.EventTrigger(E_EventType.E_minusApp,apptype);
        }
    }

    private void Update()
    {
    }

    public void CloseAppTag(E_APPType apptype)
    {
        if (appTypeList.Contains(apptype))
        {
            EventCenter.Instance.EventTrigger(E_EventType.E_closeApp, apptype);
            Transform delTag = appTagsContainer.transform.GetChild(appTypeList.IndexOf(apptype));
            delTag.SetParent(null);

            appTypeList.Remove(apptype);
            appTagsContainer.Remove(delTag, 0.1f);
            delTagAnim(delTag);
        }
    }


    void delTagAnim(Transform apptag)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(apptag.DOJump(apptag.position+10*Vector3.up, 10, 1, 0.05f, true));
        seq.Append(apptag.DOLocalMoveY(-20, 0.05f));
        seq.SetAutoKill(true); // 动画播放完毕后自动销毁 Tween
        seq.Play();            // 开始播放 Sequence
        seq.OnComplete(() =>
        {
            DestroyImmediate(apptag.gameObject);
        });
    }

}
