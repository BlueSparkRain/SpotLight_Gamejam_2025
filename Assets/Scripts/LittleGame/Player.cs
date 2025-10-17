using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int2 position=new  (0,0);
    private int2 worldPosition=new int2(-20,-15);
    public bool useItem1=false;
    public GameObject slot;
    Slot slotScript;
    public bool hasMove=false;

    private void Awake()
    {
        worldPosition += 5 * position;
    }
    void Start()
    {
        slotScript = slot.GetComponent<Slot>();

        transform.position = new Vector3(worldPosition.x, worldPosition.y, 48);

    }

    // Update is called once per frame
    void Update()
    {
        hasMove = false;
        if (useItem1)
        {

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                Move(new(0,1));
                hasMove = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(new(-1, 0));
                hasMove = true;

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(new(0, -1));
                hasMove = true;

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(new(1, 0));
                hasMove = true;

            }
        }
    }

    void Move(int2 m)
    {
        
        if(position.x+m.x>=0&&position.x+m.x<8&&position.y+m.y>=0&&position.y+m.y<8&&GetLandState(position.x+m.x,position.y+m.y)==1)
        {
            transform.position += new Vector3(5 * m.x, 5 * m.y, 0);
            position += m;
            Debug.Log("P:" + position);
        }
        
    }

    int GetLandState(int x, int y)
    {
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
            return slotScript.land8x8[x, y].state;
        else
            return -2;
    }
}
