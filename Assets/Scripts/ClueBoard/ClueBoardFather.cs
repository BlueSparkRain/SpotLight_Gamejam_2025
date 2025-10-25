using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
public class ClueBoardFather : MonoBehaviour
{
    Dictionary<E_ClueBoardPerson,GameObject> boardDic=new Dictionary<E_ClueBoardPerson, GameObject>();
    string path = "Prefab/基础元素/线索板条目/CluePersonDataBoard";
    Transform activeBoard;
    ClueFactoryManager clueFactoryManager;
    void OnEnable()
    {
        EventCenter.Instance.AddEventListener<E_ClueBoardPerson>(E_EventType.E_switchClueBoard, SwitchBoard);
    }

    private void Start()
    {
        clueFactoryManager=ClueFactoryManager.Instance;
    }
    void SwitchBoard(E_ClueBoardPerson person)
    {
        foreach (E_ClueBoardPerson t in boardDic.Keys){
            if (t == person){
                boardDic[t].SetActive(true);
                activeBoard = boardDic[t].transform;
            }
            else
                boardDic[t].SetActive(false);
        }
        Debug.Log(boardDic.Count+ "pppppppppppppppppppp"+activeBoard);
    }


    public void AddNewClue(E_ClueBoardPerson person,GameObject newClueIbj) {
        SwitchBoard(person);
        if (!activeBoard) {
            Debug.Log("无激活线索板");
            return;
        }
        activeBoard.GetComponent<CluePersonDataBoard>().AddNewClue(newClueIbj.transform);
    }

    public void AddNewPersonBoard(E_ClueBoardPerson person,UnityAction callback=null) {
        if (boardDic.ContainsKey(person)){
            Debug.Log("尝试重复创建同一线索板！");
            return;
        }
        Addressables.InstantiateAsync(path, transform).Completed+=(handle)=> {
            GameObject boardObj = handle.Result;
            boardObj.transform.localPosition = Vector3.zero;
            boardDic.Add(person, boardObj);

            PersonClueSOData sodata= clueFactoryManager.GetPersonSOData(person);
            CluePersonDataBoard dataBoard= boardObj.GetComponent<CluePersonDataBoard>();
            dataBoard.Init(sodata.personName,sodata.age,sodata.major,sodata.photo);
            callback?.Invoke();
        };
    }
  
}
