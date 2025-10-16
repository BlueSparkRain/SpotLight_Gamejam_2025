using System.Collections;
using UnityEngine;
public abstract class BasePanel : MonoBehaviour
{
    protected Transform root;
    protected virtual void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        root = transform.GetChild(0);

    }
    protected float transTime = 0.15f;

    /// <summary>
    /// �����붯�������߼�
    /// </summary>
    /// <returns></returns>
    /// <summary>
    /// ���رյ���
    /// </summary>
    public abstract IEnumerator ShowPanelTweenEffect();
    /// <summary>
    /// �����ʾ����
    /// </summary>
    public virtual void ShowPanel()
    {
        transform.SetAsLastSibling();
        Init();
    }
    /// <summary>
    /// ����˳����������߼�
    /// </summary>
    public abstract IEnumerator HidePanelTweenEffect();
    /// <summary>
    /// ����˳�����
    /// </summary>
    public virtual void HidePanel()
    {
    }
    protected virtual void Init() { }


}
