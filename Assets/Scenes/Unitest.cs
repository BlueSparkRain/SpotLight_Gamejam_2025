using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Unitest : MonoBehaviour
{
    private CancellationTokenSource cts = new CancellationTokenSource();

    private void Awake()
    {
    }

    private void OnEnable()
    {
        Debug.Log("777");
    }

    //private void Start()
    //{
    //    // 延迟 3 秒后执行 Debug.Log
    //    UniTaskTimer.DelayAndExecute(3f, () =>
    //    {
    //        Debug.Log("【UniTask 延迟计时器】3秒已过，任务完成！");
    //    }, cts.Token).Forget(); // 使用 Forget 启动任务

    //    Debug.Log("任务已启动，等待 3 秒...");
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        // 在任务完成前按下 C 键，取消任务
    //        cts.Cancel();
    //        Debug.Log("任务被取消。");
    //    }
    //}

    //private void OnDestroy()
    //{
    //    cts?.Cancel();
    //    cts?.Dispose();
    //}
}
