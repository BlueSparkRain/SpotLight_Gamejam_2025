using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
[DefaultExecutionOrder(1)]
public class Win : MonoBehaviour
{
    public GameObject enemyObj;
    Player playerScript;
    Enemy enemyScript;
  LittleGameManager gameManager;

    void Start()
    {
        playerScript = GetComponent<Player>();
        enemyScript = enemyObj.GetComponent<Enemy>();
        gameManager=LittleGameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //≤‚ ‘
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.Win();
        }

        if (playerScript.position.x == enemyScript.position.x && playerScript.position.y == enemyScript.position.y)
        {
            Debug.Log("win");
            gameManager.Win();
        }

    }

    

  
}
