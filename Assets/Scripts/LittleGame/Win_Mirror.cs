using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(2)]
public class Win_Mirror : MonoBehaviour
{
    public GameObject enemyObj;
    Player playerScript;
    Enemy enemyScript;

    void Start()
    {
        playerScript = GetComponent<Player>();
        enemyScript = enemyObj.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.mirrorBug&&(7-playerScript.position.x)==enemyScript.position.x&& playerScript.position.y == enemyScript.position.y)
        {
            Debug.Log("win");
        }

    }
}
