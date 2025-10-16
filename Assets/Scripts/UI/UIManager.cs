using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ��������UI���
/// ע�⣺Ԥ����������������豣��һ��
/// </summary>
public class UIManager : BaseSingleton<UIManager>
{

    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();
    public void ShowPanel<T>(UnityAction<T> end_callBack, UnityAction<T> before_callBack) where T : BasePanel
    {
        //��ȡ�������Ԥ����������������豣��һ��
        string panelName = typeof(T).Name;
        BasePanel panel;
        //�������
        if (panelDic.ContainsKey(panelName))
        {
            panel = panelDic[panelName];
            if (!panel.gameObject.activeSelf)
                panel.gameObject.SetActive(true);

            before_callBack?.Invoke(panelDic[panelName] as T);
            panel.ShowPanel();
            MonoManager.Instance.StartCoroutine(panel.ShowPanelTweenEffect());
            //Debug.Log("����Ѵ���:" + panelName);
            end_callBack?.Invoke(panelDic[panelName] as T);
            return;
        }
        //��������壬�ȼ�����Դ
        GameObject panelobj = Resources.Load<GameObject>("Prefab/UIPanel/" + panelName);


        //�����Ԥ�Ƽ���������Ӧ��layer�£�������ԭ�������Ŵ�С
        panelobj = GameObject.Instantiate(panelobj);
        panelobj.transform.SetAsFirstSibling();

        //��ȡ��ӦUI�������
        panel = panelobj.GetComponent<BasePanel>();
        before_callBack?.Invoke(panel as T);
        panel.ShowPanel();
        MonoManager.Instance.StartCoroutine(panel.ShowPanelTweenEffect());
        //Debug.Log("����壡" + panelName);
        end_callBack?.Invoke(panel as T);
        //�洢panel
        if (!panelDic.ContainsKey(panelName))
        {
            panelDic.Add(panelName, panel);
        }
    }

    public void HidePanel<T>(bool isDestroy = false)
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            if (isDestroy)
            {
                //ѡ������ʱ�Ż��Ƴ��ֵ�
                GameObject.Destroy(panelDic[panelName].gameObject);
                panelDic.Remove(panelName);
            }
            else //��ʧ��
                MonoManager.Instance.StartCoroutine(PanelHideEnd(panelDic[panelName]));
        }
    }
    IEnumerator PanelHideEnd(BasePanel panel)
    {
        panel.HidePanel();
        yield return panel.HidePanelTweenEffect();
        panel.gameObject.SetActive(false);

    }
}
