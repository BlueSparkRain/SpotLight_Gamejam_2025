using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

 public class UniTaskTimer
 {
     /// <summary>
     /// 异步延迟指定时间后执行一个操作。
     /// </summary>
     /// <param name="duration">延迟时间（秒）</param>
     /// <param name="onComplete">延迟结束后执行的操作</param>
     /// <param name="token">用于取消操作的 CancellationToken</param>
     public static async UniTask DelayAndExecute(float duration, System.Action onComplete, CancellationToken token = default)
     {
         // UniTask.Delay(TimeSpan) 是零 GC 的等待方法
         // PlayerLoopTiming.Update 表示在 Update 周期检查时间
         await UniTask.Delay(System.TimeSpan.FromSeconds(duration),
                             ignoreTimeScale: false, // 是否受 Time.timeScale 影响
                             PlayerLoopTiming.Update,
                             token);

         // 在执行操作前检查是否被取消
         if (token.IsCancellationRequested)
         {
             return;
         }

         // 确保回调在主线程执行（UniTask 默认就是主线程）
         onComplete?.Invoke();
     }
 }
