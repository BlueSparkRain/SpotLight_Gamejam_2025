using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AddressableAssets;

public class ClueFactoryManager : MonoSingleton<ClueFactoryManager>
{
    //记录每个嫌疑人的线索数据
    Dictionary<E_ClueBoardPerson, PersonClueSOData> personBoardsDic=new Dictionary<E_ClueBoardPerson, PersonClueSOData>();
    //[Header("线索条目预制件")]
    //public GameObject clueUnitPrefab;

    ClueBoardFather boardFather;

    string clueUnitPath = "Prefab/基础元素/线索板条目/ClueUnit";

    private int personNum=3;

    [ContextMenu("打印字典数")]
    void PrintDicNum()
    {
        Debug.Log(personBoardsDic.Count);
    }

    protected override void InitPlayer()
    {
        base.InitPlayer();
        boardFather=FindAnyObjectByType<ClueBoardFather>();

        PersonClueSOData personClueSOData=null;

        for (int i = 1; i <= personNum; i++) {
            Addressables.LoadAssetAsync<PersonClueSOData>("SO_Data/PersonClueData/PersonClueData"+i).Completed+= (obj)=> {
               personClueSOData = obj.Result;
               Debug.Log(personClueSOData);

               if (personBoardsDic.ContainsKey(personClueSOData.Person))
                   Debug.Log("ClueFactoryManager读取到重复的PersonClueSOData！");
               else{
                   personBoardsDic.Add(personClueSOData.Person, personClueSOData);
                   Debug.Log(personClueSOData.Person + "--" + personClueSOData);
               }
            };       
        }
    }

    GameObject newClueObj;
    PersonClueSOData targetSOData;
    /// <summary>
    /// 为目标线索板添加线索
    /// </summary>
    /// <param name="person"></param>
    /// <param name="clueID">逻辑ID（>0）</param>
    public void AddNewClue(E_ClueBoardPerson person, int clueID) {

        Debug.Log("线索增加"+person);
        if (personBoardsDic.ContainsKey(person))
        {
            Addressables.InstantiateAsync(clueUnitPath).Completed+=(handle)=> {

                newClueObj = handle.Result;
                targetSOData = personBoardsDic[person];
                string content = targetSOData.personClueDatas[clueID - 1].clueContent;

                newClueObj.GetComponent<ClueUnit>().Init(content);

                boardFather.AddNewClue(person, newClueObj);


            };
        }


      
    }
}
