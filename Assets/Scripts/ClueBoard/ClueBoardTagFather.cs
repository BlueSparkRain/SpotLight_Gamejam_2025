using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ClueBoardTagFather : MonoBehaviour
{
    string path = "Prefab/基础元素/线索板条目/CluePersonUnit";
   
    private List<E_ClueBoardPerson> personLists=new List<E_ClueBoardPerson>();
    public void AddNewPersonBoardTag(E_ClueBoardPerson person)
    {
        if (personLists.Contains(person)) {
            Debug.Log("尝试重复创建同一线索板Tag！");
            return;
        }
        Addressables.InstantiateAsync(path).Completed += (handle) => {
            GameObject newTag=handle.Result;
            newTag.GetComponent<CluePersonTag>().Init(person);
            newTag.transform.SetParent(transform);
            personLists.Add(person);
            //Debug.Log("新增一个Tag！" + person);
        };
    }
}
