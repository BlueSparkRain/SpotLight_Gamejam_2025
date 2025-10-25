using System.Collections;
using System.Diagnostics.Tracing;
using UnityEngine;

public class GameSceneManager : MonoSingleton<GameSceneManager>
{
    public DesktopAPP currentApp;
    [Header("APP槽位")]
    public Transform AppSloContainers;
    public DesktopAPPSlot targetEmptSlot;

    DialogueManager DialogueManagerInstance;
    TaskUnitFactory TaskUnitFactoryInstance;
    UIManager uiManager;
    EventCenter eventCenter;

    void Start()
    {
        TaskUnitFactoryInstance = TaskUnitFactory.Instance;
        uiManager = UIManager.Instance;
        eventCenter=EventCenter.Instance;
        DialogueManagerInstance = DialogueManager.Instance;
        EventCenter.Instance.AddEventListener<DesktopAPP>(E_EventType.E_selectNewApp, Select_a_NewApp);
        EventCenter.Instance.AddEventListener(E_EventType.E_dragAPPDone, () => targetEmptSlot = DragNewTargetSlot());

        uiManager.ShowPanel<PlayerSelectPanel>(panel => {
            panel.CreateOneSelectButton("请打开直播软件", () => {
                eventCenter.EventTrigger(E_EventType.E_ArrowAppear,2);

                StartCoroutine(StartAITalk1());
            } );
        
        }, null);
    }

    IEnumerator StartAITalk1()
    {
        yield return new WaitForSeconds(3);
        eventCenter.EventTrigger(E_EventType.E_FreezeLivePanel);
        BeginTalk2();
    }

    void BeginTalk2()
    {
        DialogueManagerInstance.BeginDialogueSequence(2, () =>
        {
            DialogueManagerInstance.AddDialogueEvent(2, 2, BeginPlayerSelect2);

        });
    }

    void BeginPlayerSelect2()
    {
        uiManager.ShowPanel<PlayerSelectPanel>(panel =>
        {
            panel.CreateOneSelectButton("好久不见", () =>
            {

                DialogueManagerInstance.BeginDialogueSequence(2.1f, () =>
                {
                    DialogueManagerInstance.AddDialogueEvent(2.1f, 0, () =>
                    {
                        BeginTalk3();
                    });
                });
            });
            panel.CreateOneSelectButton("别废话", () =>
            {
                BeginTalk3();
            });
        }, null);
    }

    void BeginTalk3()
    {
        DialogueManagerInstance.BeginDialogueSequence(3, () =>{
            DialogueManagerInstance.AddDialogueEvent(3, 7, () =>{
                BeginPlayerSelect3();
            });
        });
    }

    void BeginPlayerSelect3()
    {
        uiManager.ShowPanel<PlayerSelectPanel>(panel =>
        {
            panel.CreateOneSelectButton("笑死，2035年了，还有人还将无法保证的“公正“奉为圭臬?", () =>
            {
                Debug.Log("nnn");

                DialogueManagerInstance.BeginDialogueSequence(3.1f, () =>
                {
                    DialogueManagerInstance.AddDialogueEvent(3.1f, 0, () =>
                    {
                        StartCoroutine(StartAITalk4());
                    });
                });
            });
            panel.CreateOneSelectButton("多说无益，调用今天的目标档案吧。", () =>
            {
                Debug.Log("mmm");
                StartCoroutine(StartAITalk4());
            });
        }, null);
    }

    IEnumerator StartAITalk4()
    {
        yield return new WaitForSeconds(1);
        BeginTalk4();
    }

    void BeginTalk4()
    {
        DialogueManagerInstance.BeginDialogueSequence(4, () =>{
            DialogueManagerInstance.AddDialogueEvent(4, 2, () => {
                AddTask1();
            });
        });
    }

    void AddTask1()
    {
        TaskUnitFactoryInstance.GetNewTask("·搜集研究员的信息");
        eventCenter.EventTrigger(E_EventType.E_ActiveLivePanel);
        StartCoroutine(StartAITalk5());
    }

    IEnumerator StartAITalk5()
    {
        yield return new WaitForSeconds(1);
        BeginTalk5();
    }

    void BeginTalk5() {
        DialogueManagerInstance.BeginDialogueSequence(5, () => {
            DialogueManagerInstance.AddDialogueEvent(5, 4, () => {
                uiManager.ShowPanel<PlayerSelectPanel>(panel => {
                    panel.CreateOneSelectButton("请打开社媒软件", () => {
                        eventCenter.EventTrigger(E_EventType.E_ArrowAppear, 1);
                    });
                }, null);
            });
        });
    }


    /// <summary>
    /// 点击新的APP
    /// </summary>
    /// <param name="_currentApp"></param>
    void Select_a_NewApp(DesktopAPP _currentApp)
    {
        if (_currentApp == currentApp)
        {
            //Debug.Log("点击了同一个APP");
            return;
        }
        currentApp?.freeSelect();
        currentApp = _currentApp;
        currentApp.setSelect();
    }


    /// <summary>
    /// 得到APP拖拽结束后新的目标槽位
    /// </summary>
    /// <returns></returns>
    DesktopAPPSlot DragNewTargetSlot()
    {
        Vector3 dragEndPos = Input.mousePosition;
        int x;
        int y;
        y = (int)(dragEndPos.x - 210) / 212;
        x = (int)(1200 - dragEndPos.y) / 212;
        return AppSloContainers?.GetChild(11 * x + y).GetComponent<DesktopAPPSlot>();
    }
}
