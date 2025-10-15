using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : MonoSingleton<GameSceneManager>
{ 
    public DesktopAPP currentApp;

    public GraphicRaycaster graphicRaycaster;

    [Header("APP槽位")]
    public Transform AppSloContainers;

    public DesktopAPPSlot targetEmptSlot;

    void Start()
    {
        EventCenter.Instance.AddEventListener<DesktopAPP>(E_EventType.E_selectNewApp, Select_a_NewApp);
        EventCenter.Instance.AddEventListener(E_EventType.E_dragAPPDone,() => targetEmptSlot = DragNewTargetSlot());
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //        Debug.Log(Input.mousePosition);
    //}


    /// <summary>
    /// 点击新的APP
    /// </summary>
    /// <param name="_currentApp"></param>
    void Select_a_NewApp(DesktopAPP _currentApp) {
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
        y =(int) (dragEndPos.x - 210) / 212;
        x =(int) (1200 - dragEndPos.y) / 212;
        //Debug.Log("坐标L:("+x+","+y+")");
        return AppSloContainers?.GetChild(11 * x + y).GetComponent<DesktopAPPSlot>();
    }
}
