using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SocialBlog : MonoBehaviour
{
    public Button gameButton;
    //public UnityEvent UnityEvent;
    DialogueManager DialogueManagerInstance;
    UIManager uiManager;

    ClueFactoryManager clueFactoryManager;

    private void Awake()
    {
        uiManager = UIManager.Instance;
        clueFactoryManager=ClueFactoryManager.Instance; 
        DialogueManagerInstance = DialogueManager.Instance;
        gameButton.onClick.AddListener(GameButton);
    }

    bool isInit;
    private void OnEnable()
    {
        if (!isInit){
            isInit=true;
            StartCoroutine(StartTalk6());
        }
    }
    IEnumerator StartTalk6()
    {
        yield return new WaitForSeconds(1);
        DialogueManagerInstance.BeginDialogueSequence(6, () => {
            DialogueManagerInstance.AddDialogueEvent(6, 6, () => {
                clueFactoryManager.AddNewClue(E_ClueBoardPerson.研究员, 2);
                StartCoroutine(StartTalk8());
            });
        });
    }

    IEnumerator StartTalk8() {
        yield return new WaitForSeconds(1);
        BeginTalk8();
    }

    void BeginTalk8() {
        DialogueManagerInstance.BeginDialogueSequence(8, () => {
            DialogueManagerInstance.AddDialogueEvent(8, 0, () => {
                //选项
                clueFactoryManager.AddNewClue(E_ClueBoardPerson.研究员, 3);
                BeginPlayerSelect();
            });
        });
    }

    void BeginPlayerSelect()
    {
        uiManager.ShowPanel<PlayerSelectPanel>(panel =>
        {
            panel.CreateOneSelectButton("继续", () =>
            {
                clueFactoryManager.AddNewClue(E_ClueBoardPerson.研究员, 4);
                //分值++；
            });
            panel.CreateOneSelectButton("到此为止", () =>
            {
                clueFactoryManager.AddNewClue(E_ClueBoardPerson.研究员, 4);
                //分值--；
            });
        }, null);
    }



    public void GameButton() {
        DialogueManagerInstance.BeginDialogueSequence(9, () => {
            DialogueManagerInstance.AddDialogueEvent(9, 7, () => {
               
                uiManager.ShowPanel<PlayerSelectPanel>(panel =>
                {
                    panel.CreateOneSelectButton("执行", () =>
                    {
                        //进行小游戏
                        EventCenter.Instance.EventTrigger(E_EventType.E_MinusAllPanels);
                        SceneLoadManager.Instance.AdditiveNewScene(2);  
                    });
                    panel.CreateOneSelectButton("稍等", () =>
                    {
                        //分值--；
                    });
                }, null);
            });
        });

   }
}
