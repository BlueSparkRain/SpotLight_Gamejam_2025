using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Land : MonoBehaviour
{
    public int2 ID;
    [Range(-1,1)]//-1:ÓÐÕÏ°­ 0:¿Õ 1:ÓÐµØ¿é
    public int state;

    public Material Mn1;
    public Material M0;
    public Material M1;


    private void Start()
    {
        Material myMaterial = GetComponent<Material>();
        switch (state)
        {
            case -1:
                myMaterial = Mn1;
                break;
            case 0:
                myMaterial = M0;
                break;
            case 1:
                myMaterial = M1;
                break;
        }
            



    }
}
