using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

//增加新线索版+新线索版Tag
public class ClueBoardRiserManager : MonoSingleton<ClueBoardRiserManager>
{
    public ClueBoardTagFather  clueBoardTagFather;
    public ClueBoardFather clueBoardFather;

    protected override void InitPlayer()
    {
        base.InitPlayer();
        clueBoardTagFather=FindAnyObjectByType<ClueBoardTagFather>();
        clueBoardFather = FindAnyObjectByType<ClueBoardFather>();
    }
   
    public void AddNewBoard(E_ClueBoardPerson person,UnityAction action=null) 
    {
        clueBoardFather.AddNewPersonBoard(person,action );
        clueBoardTagFather.AddNewPersonBoardTag(person);
        action?.Invoke();
    }
}
