using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluePersonTag : MonoBehaviour
{
    public E_ClueBoardPerson person;
    ClueBoardFather boardFather;
    Button button;

    public void Init(E_ClueBoardPerson _person) { 
        person = _person;
    }
    void Start()
    {
        boardFather = FindAnyObjectByType<ClueBoardFather>();
        button = GetComponent<Button>();
        button.onClick.AddListener(CallClueBoard);
    }

    void CallClueBoard() {
        EventCenter.Instance.EventTrigger<E_ClueBoardPerson>(E_EventType.E_switchClueBoard,person);
        Debug.Log("ºô½Ð"+person+"°å×Ó");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
