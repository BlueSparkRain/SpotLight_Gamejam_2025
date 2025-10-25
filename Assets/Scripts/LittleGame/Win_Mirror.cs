using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(1)]
public class Win_Mirror : MonoBehaviour
{
    public GameObject bugManagerObj;
    BugManager bugManagerScript;

    public GameObject enemyObj;
    Player playerScript;
    Enemy enemyScript;

    void Start()
    {
        bugManagerScript = bugManagerObj.GetComponent<BugManager>();
        playerScript = GetComponent<Player>();
        enemyScript = enemyObj.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bugManagerScript.mirrorBug&&(7-playerScript.position.x)==enemyScript.position.x&& playerScript.position.y == enemyScript.position.y)
        {
            Debug.Log("win");
        }

    }
}
