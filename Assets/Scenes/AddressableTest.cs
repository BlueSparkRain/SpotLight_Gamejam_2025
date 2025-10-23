using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressableTest : MonoBehaviour
{
    public E_ClueBoardPerson person;
    public int clueID;
    ClueFactoryManager clueFactoryManagerInstance;
    ClueBoardRiserManager clueBoardRiserManager;



    void Start()
    {
        clueFactoryManagerInstance = ClueFactoryManager.Instance;
        clueBoardRiserManager = ClueBoardRiserManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            clueBoardRiserManager.AddNewBoard(person);
        }

            if (Input.GetKeyDown(KeyCode.P)) {
            clueFactoryManagerInstance.AddNewClue(person, 1);
        }
    }
}
