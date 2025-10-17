using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor.Rendering;
using UnityEngine;

public class APPTagsCaller : MonoSingleton<APPTagsCaller>
{
    public List<E_APPType>  appTypeList = new List<E_APPType>();

    //App��ǩԤ�Ƽ�
    public GameObject appTagObjRef;

    [Header("����ײ�Ӧ�ñ�ǩ-������")]
    public HorizontalContainer appTagsContainer;
    public void CallNewAppTag(E_APPType apptype)
    {

        if (appTypeList.Contains(apptype)) {
            Debug.Log("��Ӧ��Ϊ����ģʽ");
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
            //delTag.SetParent(null);
            appTypeList.Remove(apptype);

            delTagAnim(delTag);
            appTagsContainer.Remove(delTag, 0.2f);
        }
    }


    void delTagAnim(Transform apptag)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(apptag.DOJump(apptag.position+10*Vector3.up, 10, 1, 0.1f, true));
        seq.Append(apptag.DOLocalMoveY(-100, 0.1f));
        seq.SetAutoKill(true); // ����������Ϻ��Զ����� Tween
        seq.Play();            // ��ʼ���� Sequence
        seq.OnComplete(() =>
        {
            DestroyImmediate(apptag.gameObject);
        });
    }

}
