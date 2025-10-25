using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class TaskUnitFactory : MonoSingleton<TaskUnitFactory>
{
    string taskUnitPath = "Prefab/基础元素/任务条目/TaskUnit";
    public Transform taskBoard;
    public void GetNewTask(string content)
    {
        Addressables.InstantiateAsync(taskUnitPath, taskBoard).Completed += (handle) =>
        {
            TaskUnit newTask=handle.Result.GetComponent<TaskUnit>();
            newTask.Init(content);
        };
    }
}
