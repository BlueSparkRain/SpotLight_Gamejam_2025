using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[ExecuteAlways]
public class Land : MonoBehaviour
{
    public int2 ID;
    [Range(-1,1)]//-1:ÓÐÕÏ°­ 0:¿Õ 1:ÓÐµØ¿é
    public int state;

    public Material Mn1;
    public Material M0;
    public Material M1;

    
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        switch (state)
        {
            case -1:
                renderer.material = Mn1;
                break;
            case 0:
                renderer.material = M0;
                break;
            case 1:
                renderer.material = M1;
                break;
            
        }
    }
}
