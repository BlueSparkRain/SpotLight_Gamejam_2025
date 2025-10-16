using System.Collections.Generic;
using UnityEngine;

public interface IApp
{
    public void CallMe(Vector3 appearPos);
    public void HideMe();
}

/// <summary>
/// �������
/// </summary>
public class ChatApp : IApp
{
    public void CallMe(Vector3 appearPos) =>
        UIManager.Instance.ShowPanel<ChatPanel>(null,(panel) => panel.SetWebBornPos(appearPos));

    public void HideMe() =>
        UIManager.Instance.HidePanel<ChatPanel>();
}
/// <summary>
/// �罻ý��
/// </summary>
public class SocialApp : IApp
{
    public void CallMe(Vector3 appearPos) =>
        UIManager.Instance.ShowPanel<SocialPanel>(null,(panel) => panel.SetWebBornPos(appearPos));

    public void HideMe() =>
    UIManager.Instance.HidePanel<SocialPanel>();

}
/// <summary>
/// ֱ�����
/// </summary>
public class LiveApp : IApp
{
    public void CallMe(Vector3 appearPos) =>
        UIManager.Instance.ShowPanel<SocialPanel>(null, (panel) => panel.SetWebBornPos(appearPos));

    public void HideMe() =>
    UIManager.Instance.HidePanel<SocialPanel>();

}

public class APPCaller : MonoSingleton<APPCaller>
{
    public Transform AppTagsContainer;

    /// <summary>
    /// ���Ӧ��ʱ������ײ�����һ��app��ǩ��������ҳ
    /// </summary>
    public void ShowAppTag()
    {




    }

    /// <summary>
    /// ���Ӧ�õĹرռ���ɾ������ײ���һ��app��ǩ
    /// </summary>
    public void CloseAppTag()
    {




    }

    public void CallApp(E_APPType appType, Vector3 appearPos)
    {
        IApp app;
        switch (appType)
        {
            case E_APPType.�罻ý��:
                app = new SocialApp();
                break;
            case E_APPType.�������:
                app = new ChatApp();
                break;
            case E_APPType.ֱ�����:
                app = new LiveApp();
                break;
            default:
                app = new ChatApp();
                break;
        }
        app.CallMe(appearPos);
    }

    public void HideApp(E_APPType appType) {
        IApp app;
        switch (appType)
        {
            case E_APPType.�罻ý��:
                app = new SocialApp();
                break;
            case E_APPType.�������:
                app = new ChatApp();
                break;
            case E_APPType.ֱ�����:
                app = new LiveApp();
                break;
            default:
                app = new ChatApp();
                break;
        }
        app.HideMe();
    }
}
