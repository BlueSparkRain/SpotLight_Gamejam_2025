using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class APPTagsCaller : MonoSingleton<APPTagsCaller>
{
    //ֵ��App Tag��grid���ֵ����
    Dictionary<E_APPType, int> appTagDic = new Dictionary<E_APPType, int>();

    //App��ǩԤ�Ƽ�
    private GameObject appTagPrefab;

    [Header("����ײ�Ӧ�ñ�ǩ-������")]
    public Transform appTagContainer;


    private void Start()
    {
        
    }

    public void CallNewApp(E_APPType apptype)
    {


    }

    public void CloseApp(E_APPType apptype)
    {
        if (appTagDic.ContainsKey(apptype))
        {
            tagDel(appTagContainer.GetChild(appTagDic[apptype]));
            appTagDic.Remove(apptype);
        }
    }

    void tagDel(Transform apptag)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(apptag.DOLocalJump(Vector3.zero, 10, 1, 0.05f, true));
        seq.Append(apptag.DOLocalMoveY( -5,0.1f));
        seq.OnComplete(() =>
        {
            DestroyImmediate(apptag);
        });
    }

}
