using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//增加新线索版+新线索版Tag
public class ClueBoardRiserManager : MonoSingleton<ClueBoardRiserManager>
{
    ClueBoardTagFather  clueBoardTagFather;
    ClueBoardFather clueBoardFather;

    protected override void InitPlayer()
    {
        base.InitPlayer();
        clueBoardTagFather=FindAnyObjectByType<ClueBoardTagFather>();
        clueBoardFather = FindAnyObjectByType<ClueBoardFather>();
    }
   
    public void AddNewBoard(E_ClueBoardPerson person) {

        clueBoardFather.AddNewPersonBoard(person);
        clueBoardTagFather.AddNewPersonBoardTag(person);
    }
}
