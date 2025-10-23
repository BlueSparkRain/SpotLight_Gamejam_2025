using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugManager : MonoBehaviour
{
    public bool usingItem1 = false;
    public int item1Count = 2;
    public bool mirrorBug=false;
    public bool renderBug = false;
    public bool item1Bug = false;
    int FCount=0;
    void Update()
    {
        
        if(item1Bug&&FCount%50==0)
        {
            item1Count--;
            
        }
        if (item1Count < 0)
                usingItem1 = false;
        FCount++;
    }

    public void UseItem1()
    {
        if(!item1Bug)
        {
            if (usingItem1)
                usingItem1 = false;
            else if (item1Count >= 1)
                usingItem1 = true;
        }
        else
        {
            item1Count++;
            if(item1Count>0)
                usingItem1 = true;
        }
      
    }
    
    public void UseMirrorBug()
    {
        if (mirrorBug)
            mirrorBug = false;
        else
            mirrorBug = true;
    }

    public void UseRenderBug()
    {
        if (renderBug)
            renderBug = false;
        else
            renderBug = true;
    }

    public void Useitem1Bug()
    {
        if (item1Bug)
            item1Bug = false;
        else
            item1Bug = true;
    }


}
