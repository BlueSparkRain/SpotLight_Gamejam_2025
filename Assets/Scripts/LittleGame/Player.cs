using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bugManagerObj;
    BugManager bugManagerScript;
    bool usingItem1 => bugManagerScript.usingItem1;
    int Item1Count => bugManagerScript.item1Count;
    bool mirrorBug => bugManagerScript.mirrorBug;
    bool renderBug => bugManagerScript.renderBug;
    bool item1Bug => bugManagerScript.item1Bug;

    public bool IsMoving = false;

    public TextMeshProUGUI Item1CountText;

    public int2 position = new(0, 0);
    private int2 worldPosition = new int2(-20, -15);
   
    public GameObject slotObj;
    Slot slotScript;
    public bool hasMove = false;
    //¾µÏñÏà¹Ø
    
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

        bugManagerScript = bugManagerObj.GetComponent<BugManager>();
        slotScript = slotObj.GetComponent<Slot>();
        Item1CountText.text = "Item1: " + Item1Count;
        //transform.position = new Vector3(worldPosition.x, worldPosition.y, 48);

    }

    // Update is called once per frame
    void Update()
    {
        Item1CountText.text = "Item1: " + Item1Count;
        hasMove = false;
        if (usingItem1&&!IsMoving)
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
        else if(!IsMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(new(0, 1));
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

        if (position.x + m.x >= 0 && position.x + m.x < 8 && position.y + m.y >= 0 && position.y + m.y < 8 && GetLandState(position.x + m.x, position.y + m.y) == 1)
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
                MirrorPosition = new(7 - position.x, position.y);
                mirror.transform.position = new Vector3(-20 + MirrorPosition.x * 5, -15 + MirrorPosition.y * 5, 48);
                haveMirror = true;
            }
            MirrorPosition = new(7 - position.x, position.y);
            mirror.transform.position = new Vector3(-20 + MirrorPosition.x * 5, -15 + MirrorPosition.y * 5, 48);
        }
        else
        {
            if (haveMirror)
            {
                Destroy(mirror);
                haveMirror = false;
            }
        }
    }
    void MovewithItem1(int2 m)
    {

        if (m.x == 0)
        {
            for (int y = 1; y < 8; y++)
            {
                if (GetLandState(position.x, position.y + y * m.y) == 0||(GetLandState(position.x , position.y +y* m.y) == 2 && renderBug))
                {
                    for (int i = 1; i <= y; i++)
                    {
                        slotScript.land8x8[position.x, position.y + y * m.y].state = slotScript.land8x8[position.x, position.y + (y - i) * m.y].state;
                    }
                        slotScript.land8x8[position.x, position.y].state = 0;
                    transform.position += new Vector3(5 * m.x, 5 * m.y, 0);
                    position += m;
                    hasMove = true;
                    bugManagerScript.usingItem1 = false;
                    bugManagerScript.item1Count--;
                    break;
                }
                else if (GetLandState(position.x, position.y + y * m.y) < 0|| GetLandState(position.x, position.y + y * m.y) == 2)
                {
                    break;
                }
            }
        }

        else if (m.y == 0)
        {
            for (int x = 1; x < 8; x++)
            {
                if (GetLandState(position.x + x * m.x, position.y) == 0|| (GetLandState(position.x + x * m.x, position.y ) == 2 && renderBug))
                {
                    for (int i = 1; i <= x; i++)
                    {
                        slotScript.land8x8[position.x + x * m.x, position.y].state = slotScript.land8x8[position.x + (x - i) * m.x, position.y].state;
                    }
                        slotScript.land8x8[position.x, position.y].state = 0;
                    transform.position += new Vector3(5 * m.x, 5 * m.y, 0);
                    position += m;
                    hasMove = true;
                    bugManagerScript.usingItem1 = false;
                    bugManagerScript.item1Count--;
                    break;
                }
                else if (GetLandState(position.x + x * m.x, position.y) < 0|| GetLandState(position.x + x * m.x, position.y) ==2)
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
}
