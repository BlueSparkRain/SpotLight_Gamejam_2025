using System.Collections.Generic;
using UnityEngine;

public interface IAppCanCall
{
    public void CallMe(Vector3 appearPos);
    public void HideMe();
}

/// <summary>
/// 聊天软件
/// </summary>
public class ChatApp : IAppCanCall
{
    public void CallMe(Vector3 appearPos) =>
        UIManager.Instance.ShowPanel<ChatPanel>(null,(panel) => panel.SetWebBornPos(appearPos));

    public void HideMe() =>
        UIManager.Instance.HidePanel<ChatPanel>();
}

/// <summary>
/// 社交媒体
/// </summary>
public class SocialApp : IAppCanCall
{
    public void CallMe(Vector3 appearPos) =>
        UIManager.Instance.ShowPanel<SocialPanel>(null,(panel) => panel.SetWebBornPos(appearPos));
    public void HideMe() =>
    UIManager.Instance.HidePanel<SocialPanel>();

}
/// <summary>
/// 直播软件
/// </summary>
public class LiveApp : IAppCanCall
{
    public void CallMe(Vector3 appearPos) =>
        UIManager.Instance.ShowPanel<LivePanel>(null, (panel) => panel.SetWebBornPos(appearPos));

    public void HideMe() =>
    UIManager.Instance.HidePanel<LivePanel>();
}

public class APPCaller : MonoSingleton<APPCaller>
{
   
    /// <summary>
    /// 点击应用时在桌面底部新增一个app标签，并打开网页
    /// </summary>
    public void ShowAppTag()
    {

    }

    /// <summary>
    /// 点击应用的关闭键，删除桌面底部的一个app标签
    /// </summary>
    public void CloseAppTag()
    {

    }
    public void CallApp(E_APPType appType, Vector3 appearPos)
    {
        IAppCanCall app;
        switch (appType)
        {
            case E_APPType.社交媒体:
                app = new SocialApp();
                break;
            case E_APPType.聊天软件:
                app = new ChatApp();
                break;
            case E_APPType.直播软件:
                app = new LiveApp();
                break;
            default:
                app = new ChatApp();
                break;
        }
        app.CallMe(appearPos);
    }
    public void HideApp(E_APPType appType) {
        IAppCanCall app;
        switch (appType)
        {
            case E_APPType.社交媒体:
                app = new SocialApp();
                break;
            case E_APPType.聊天软件:
                app = new ChatApp();
                break;
            case E_APPType.直播软件:
                app = new LiveApp();
                break;
            default:
                app = new ChatApp();
                break;
        }
        app.HideMe();
    }
}
