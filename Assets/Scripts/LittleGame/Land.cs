using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[ExecuteAlways]
public class Land : MonoBehaviour
{
    public GameObject bugManagerObj;
    BugManager bugManagerScript;

    public int2 ID;
    [Range(-1,2)]//-1:ÓĞÕÏ°­ 0:¿Õ 1:ÓĞµØ¿é 2:½öäÖÈ¾´íÎóµØ¿é
    public int state;
    public int LockState;

    public Material Mn1;
    public Material M0;
    public Material M1;
    public Material M2;

    private void Start()
    {
        if(state==2)
            LockState = 2;
        bugManagerScript = bugManagerObj.GetComponent<BugManager>();
    }

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        switch (state)
        {
            case -1:
                renderer.material = Mn1;
                break;
            case 0:
                if(LockState==2)
                {
                    renderer.material = M2;
                    state = 2;
                    break;
                }
                renderer.material = M0;
                break;
            case 1:
                renderer.material = M1;
                break;
            case 2:
                if(bugManagerScript.renderBug)
                    renderer.material = M2;
                else
                    renderer.material = Mn1;
                break;
        }


    }
}
