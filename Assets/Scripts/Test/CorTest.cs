using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class CorTest : MonoBehaviour
{
    IEnumerator MyCor()
    {
        Debug.Log("MyCor£º"+Time.realtimeSinceStartup);
        yield return new WaitForMySeconds(2);
        Debug.Log("MyCor£º" + Time.realtimeSinceStartup);
    }


    IEnumerator Cor()
    {
        Debug.Log("UnityCor£º" + Time.realtimeSinceStartup);
        yield return new WaitForSeconds(2);
        Debug.Log("UnityCor£º" + Time.realtimeSinceStartup);
    }


    private void Start()
    {
        //StartCoroutine(Cor());
        MyCoroutineManager.Instance.StartMyCoroutine(MyCor());
    }
    private void Update()
    {
        MyCoroutineManager.Instance.UpdateMyCoroutine();
    }


    IEnumerator Test()
    {
        Console.WriteLine();
        yield return new WaitForSeconds(1);
        Console.WriteLine();
        yield return new WaitForSeconds(1);
        Console.WriteLine();
        yield return new WaitForSeconds(1);
        Console.WriteLine();
        yield return new WaitForSeconds(1);
        Console.WriteLine();

    }

}
