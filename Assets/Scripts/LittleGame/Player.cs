using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int Item1Count = 2;

    public int2 position=new  (0,0);
    private int2 worldPosition=new int2(-20,-15);
    public bool usingItem1=false;
    public GameObject slotObj;
    Slot slotScript;
    public bool hasMove=false;
    //¾µÏñÏà¹Ø
    public bool mirrorBug = false;
    bool haveMirror = false;
    public GameObject playerMirror;
    int2 MirrorPosition;
    GameObject mirror;

    private void Awake()
    {
        worldPosition += 5 * position;
    }
    void Start()
    {
        slotScript = slotObj.GetComponent<Slot>();

        transform.position = new Vector3(worldPosition.x, worldPosition.y, 48);

    }

    // Update is called once per frame
    void Update()
    {
        
        hasMove = false;
        if (usingItem1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                MovewithItem1(new(0, 1));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                MovewithItem1(new(-1, 0));
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                MovewithItem1(new(0, -1));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MovewithItem1(new(1, 0));
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                Move(new(0,1));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(new(-1, 0));
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(new(0, -1));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(new(1, 0));
            }
        }
        MirrorMove();
    }

    void Move(int2 m)
    {
        
        if(position.x+m.x>=0&&position.x+m.x<8&&position.y+m.y>=0&&position.y+m.y<8&&GetLandState(position.x+m.x,position.y+m.y)==1)
        {
            transform.position += new Vector3(5 * m.x, 5 * m.y, 0);
            position += m;
            hasMove = true;
            //Debug.Log("P:" + position);
        } 
    }
    void MirrorMove()
    {
        if (mirrorBug)
        {
            if (!haveMirror)
            {
                mirror = Instantiate(playerMirror);
                MirrorPosition = new(7-position.x, position.y);
                mirror.transform.position = new Vector3(-20+ MirrorPosition.x*5, -15+ MirrorPosition.y*5, 48);
                haveMirror = true;
            }
            MirrorPosition = new(7 - position.x, position.y);
            mirror.transform.position = new Vector3(-20 + MirrorPosition.x * 5, -15 + MirrorPosition.y * 5, 48);
        }
    }
    void MovewithItem1(int2 m)
    {
        
        if(m.x==0)
        {
            for(int y=1;y<8;y++)
            {
                if(GetLandState(position.x, position.y+y*m.y)==0)
                {
                    for(int i=1;i<=y;i++)
                    {
                        slotScript.land8x8[position.x, position.y + y * m.y].state = slotScript.land8x8[position.x, position.y + (y-i) * m.y].state;
                    }
                    slotScript.land8x8[position.x, position.y].state = 0;
                    transform.position += new Vector3(5 * m.x, 5 * m.y, 0);
                    position += m;
                    hasMove = true;
                    usingItem1 = false;
                    Item1Count--;
                    break;
                }
                else if(GetLandState(position.x, position.y + y * m.y) < 0)
                {
                    break;
                }
            }
        }

        else if (m.y == 0)
        {
            for (int x = 1; x < 8; x++)
            {
                if (GetLandState(position.x+ x * m.x, position.y ) == 0)
                {
                    for (int i = 1; i <= x; i++)
                    {
                        slotScript.land8x8[position.x + x * m.x, position.y].state = slotScript.land8x8[position.x+ (x - i) * m.x, position.y ].state;
                    }
                    slotScript.land8x8[position.x, position.y].state = 0;
                    transform.position += new Vector3(5 * m.x, 5 * m.y, 0);
                    position += m;
                    hasMove = true;
                    usingItem1 = false;
                    Item1Count--;
                    break;
                }
                else if (GetLandState(position.x+ x * m.x, position.y ) < 0)
                {
                    break;
                }
            }
        }
    }

    int GetLandState(int x, int y)
    {
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
            return slotScript.land8x8[x, y].state;
        else
            return -2;
    }

    public void UseItem1()
    {
        if (usingItem1)
            usingItem1 = false;
        else if(Item1Count>=1)
            usingItem1 = true;
    }

    public void UseMirrorBug()
    {
        if (mirrorBug)
            mirrorBug = false;
        else
            mirrorBug = true;
    }
}
