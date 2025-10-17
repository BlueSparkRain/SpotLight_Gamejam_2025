using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int2 position = new(0, 0);
    
    private int2 worldPosition = new int2(-20, -15);

    bool[,] walkable = new bool[8, 8];

    public GameObject slot;
    Slot slotScript;
    public GameObject player;
    Player playerScript;
    int2 playerPrePosition;

    void Start()
    {
        
        slotScript = slot.GetComponent<Slot>();
        playerScript = player.GetComponent<Player>();
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                walkable[x, y] = true;
            }
        }

        for (int x=0;x<8;x++)
        {
            for(int y=0;y<8;y++)
            {
                if (slotScript.land8x8[x, y].state != 1)
                    walkable[x, y] = false;
            }
        }
        walkable[playerScript.position.x, playerScript.position.y]=false; 
    }

    void LateUpdate()
    {
        if(playerScript.hasMove)
        {
            

            MoveEnemyAway();
            walkable[playerPrePosition.x, playerPrePosition.y] = true;
            playerPrePosition = playerScript.position;
            walkable[playerPrePosition.x, playerPrePosition.y] = false;
        }
    }

    void MoveEnemyAway()
    {
        int2 bestTarget = position;
        float maxDist = -1;
        List<int2> bestPath = null;

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (!walkable[x, y]) continue;
                int2 pos = new int2(x, y);
                float dist = math.distance(pos, playerScript.position);
                var path = AStarGrid.FindPath(position, pos, walkable);
                if (path == null) continue;

                if (dist > maxDist)
                {
                    maxDist = dist;
                    bestTarget = pos;
                    bestPath = path;
                }
            }
        }

        // 敌人沿最优路径前进一步
        if (bestPath != null && bestPath.Count > 1)
        {
            position = bestPath[1];
            transform.position = new Vector3(worldPosition.x+5 * position.x, worldPosition.y + 5 * position.y,48);
            Debug.Log("E:"+ position);
        }
    }
}
