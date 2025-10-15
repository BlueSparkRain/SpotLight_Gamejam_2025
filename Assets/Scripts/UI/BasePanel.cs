using System.Collections;
using UnityEngine;
public abstract class BasePanel : MonoBehaviour
{

    protected Transform root;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        root = transform.GetChild(0);

    }
    public float transTime = 0.5f;

    /// <summary>
    /// 面板进入动画缓动逻辑
    /// </summary>
    /// <returns></returns>
    /// <summary>
    /// 面板关闭调用
    /// </summary>
    public abstract IEnumerator ShowPanelTweenEffect();
    /// <summary>
    /// 面板显示调用
    /// </summary>
    public virtual void ShowPanel()
    {
        transform.SetAsLastSibling();
        Init();
    }
    /// <summary>
    /// 面板退出动画缓动逻辑
    /// </summary>
    public abstract IEnumerator HidePanelTweenEffect();
    /// <summary>
    /// 面板退出调用
    /// </summary>
    public virtual void HidePanel()
    {
    }
    protected virtual void Init() { }


}
