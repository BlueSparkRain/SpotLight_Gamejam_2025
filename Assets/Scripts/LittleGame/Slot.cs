using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Slot : MonoBehaviour
{
   
    public Land[,] land8x8 = new Land[8,8];
    public GameObject playerObj;

    void Awake()
    {
        Player player = playerObj.GetComponent<Player>();

        foreach (Transform child in transform)
        {
            Land land=child.GetComponent<Land>();
            land8x8[land.ID.x, land.ID.y] = land;
        }
    }

    void Update()
    {
    }
}
