using System.Collections.Generic;
using UnityEngine.Events;

public class EventCenter : BaseSingleton<EventCenter>
{
    /// <summary>
    /// EventCenter��Ҫ���ã����ͳ�����϶ȣ�ʹ��ͬģ����룬����Ҫֱ�����û������˴˵ľ���ʵ��
    /// ����ԭ�����Ļ����ƣ��۲���ģʽ�������ͨ��
    /// �ؼ�������
    /// 1.�������ַ����¼�
    /// 2.��ӡ��Ƴ��¼�������
    /// 3.��������¼�������
    /// </summary>\
    /// 
    public EventCenter() { }

    private Dictionary<E_EventType, IEventInfo> eventDic = new Dictionary<E_EventType, IEventInfo>();

    /*�޲�****************************************************************/

    public void AddEventListener(E_EventType name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
            //��Ϊ�Ǹ��ࣨIEventInfo��װ���ࣨEventInfo������asΪ���ࣨEventInfo������ʹ�����е�actions
            (eventDic[name] as EventInfo).actions += action;
        else
            eventDic.Add(name, new EventInfo(action));
    }

    public void EventTrigger(E_EventType name)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo).actions?.Invoke();
    }

    public void RemoveEventListener(E_EventType name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo).actions -= action;
    }
    //�޲�Priority
    public void AddEventListener(E_EventType name, PriorityAction priorityAction)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as PriorityEventInfo).GetNewEvent(priorityAction);
        else
            eventDic.Add(name, new PriorityEventInfo(priorityAction));
    }

    public void EventTrigger_Priority(E_EventType name)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as PriorityEventInfo).allActions.ForEach(val => { val.Action?.Invoke(); });
    }

    public void RemoveEventListener(E_EventType name, PriorityAction priorityAction)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as PriorityEventInfo).allActions.Remove(priorityAction);
    }

    /*�в�****************************************************************/
    public void AddEventListener<T>(E_EventType name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo<T>).actions += action;
        else
            eventDic.Add(name, new EventInfo<T>(action));
    }

    public void EventTrigger<T>(E_EventType name, T info)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo<T>).actions?.Invoke(info);
    }
    public void RemoveEventListener<T>(E_EventType name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo<T>).actions -= action;
    }

    //�в�Priority
    public void AddEventListener<T>(E_EventType name, PriorityAction<T> priorityAction)
    {

        if (eventDic.ContainsKey(name))
            (eventDic[name] as PriorityEventInfo<T>).GetNewEvent(priorityAction);
        else
            eventDic.Add(name, new PriorityEventInfo<T>(priorityAction));
    }

    public void EventTrigger_Priority<T>(E_EventType name, T info)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as PriorityEventInfo<T>).allActions.ForEach(val => { val.Action?.Invoke(info); });
    }

    public void RemoveEventListener<T>(E_EventType name, PriorityAction<T> priorityAction)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as PriorityEventInfo<T>).allActions.Remove(priorityAction);
    }
    /// <summary>
    /// ��������¼�
    /// </summary>
    public void ClearAllEvents()
    {
        eventDic.Clear();
    }
}


/// <summary>
/// �в��Զ������ȼ�ί������
/// </summary>
/// <typeparam name="T"></typeparam>
public class PriorityAction<T>
{
    /// <summary>
    /// ���ȼ�
    /// </summary>
    public int Priority;

    public UnityAction<T> Action;

    public PriorityAction(int priority, UnityAction<T> action)
    {
        Priority = priority;
        Action = action;
    }
}

/// <summary>
/// �в����ȼ��¼���������
/// </summary>
/// <typeparam name="T"></typeparam>
public class PriorityEventInfo<T> : IEventInfo
{
    public List<PriorityAction<T>> allActions = new List<PriorityAction<T>>();

    //�����۲��� ��Ӧ�� ������Ϣ ��¼������
    public PriorityEventInfo(PriorityAction<T> action)
    {
        allActions.Add(action);
    }

    public void GetNewEvent(PriorityAction<T> action)
    {
        allActions.Add(action);
        //��������
        allActions.Sort((x, y) => y.Priority.CompareTo(x.Priority));
    }
}

/// <summary>
/// �޲��Զ������ȼ�ί������
/// </summary>
public class PriorityAction
{
    /// <summary>
    /// ���ȼ�
    /// </summary>
    public int Priority;

    public UnityAction Action;

    public PriorityAction(int priority, UnityAction action)
    {
        Priority = priority;
        Action = action;
    }
}

/// <summary>
/// �޲����ȼ��¼���������
/// </summary>
public class PriorityEventInfo : IEventInfo
{
    public List<PriorityAction> allActions = new List<PriorityAction>();

    //�����۲��� ��Ӧ�� ������Ϣ ��¼������
    public PriorityEventInfo(PriorityAction action)
    {
        allActions.Add(action);
    }

    public void GetNewEvent(PriorityAction action)
    {
        allActions.Add(action);
        //��������
        allActions.Sort((x, y) => y.Priority.CompareTo(x.Priority));
    }
}


//��Ϊ�˰�����Ӧ�۲��� ����ί����
public class EventInfo : IEventInfo
{
    public UnityAction actions;
    public List<PriorityAction> allActions;

    //�����۲��� ��Ӧ�� ������Ϣ ��¼������
    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}

public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}


//�˽ӿ����������滻ԭ�� װ������� ���࣬Ŀ�����ִ�����е�
public interface IEventInfo { }

public enum E_EventType
{
    E_mouseFree,
    E_selectNewApp,
    E_dragAPPDone,
}


