using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCoroutineManager : MonoSingleton<MyCoroutineManager>
{

    private LinkedList<IEnumerator> corlists = new LinkedList<IEnumerator>();
    public void StartMyCoroutine(IEnumerator ie)
    {
        corlists.AddLast(ie);
    }

    public void UpdateMyCoroutine()
    {
        var node = corlists.First;
        while (node != null)
        {
            IEnumerator ie = node.Value;
            bool ret = true;
            if (ie.Current is IWait)
            {
                IWait wait = (IWait)ie.Current;
                if (wait.Tick())
                {
                    ret = ie.MoveNext();
                }
            }
            else
            {
                ret = ie.MoveNext();
            }
            if (!ret)
            {
                corlists.Remove(ie);
            }
            node = node.Next;
        }

    }
    public void StopMyCoroutine(IEnumerator ie)
    {
        corlists.Remove(ie);
    }
}

public interface IWait
{

    bool Tick();
}


public class WaitForMySeconds : IWait
{
    float frame;
    public WaitForMySeconds(float frame)
    {
        this.frame = frame;
    }
    public bool Tick()
    {
        frame -= Time.deltaTime;
        return frame <= 0;
    }



}



