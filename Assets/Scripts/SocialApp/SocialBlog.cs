using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SocialBlog : MonoBehaviour
{
    public Button gameButton;
    public UnityEvent UnityEvent;
    DialogueManager DialogueManagerInstance;
    UIManager uiManager;

    private void Awake()
    {
        uiManager = UIManager.Instance;
        DialogueManagerInstance = DialogueManager.Instance;
        gameButton.onClick.AddListener(GameButton);
    }

    private void OnEnable()
    {
        StartCoroutine(StartTalk6());
    }
    IEnumerator StartTalk6()
    {
        yield return new WaitForSeconds(1);
        DialogueManagerInstance.BeginDialogueSequence(6, () => {
            DialogueManagerInstance.AddDialogueEvent(6, 6, () => {
                StartCoroutine(StartTalk8());
            });
        });
    }
    public void BeginTalk6() {
        Debug.Log("6666");
        DialogueManagerInstance.BeginDialogueSequence(6, () => {
            DialogueManagerInstance.AddDialogueEvent(6, 6, () => {
                StartCoroutine(StartTalk8());
            });
        });
    }
    IEnumerator StartTalk8() {
        yield return new WaitForSeconds(1);
        BeginTalk8();
    }

    void BeginTalk8() {
        Debug.Log("8888");
        DialogueManagerInstance.BeginDialogueSequence(8, () => {
            DialogueManagerInstance.AddDialogueEvent(8, 0, () => {
                //选项
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
                //分值++；
            });
            panel.CreateOneSelectButton("到此为止", () =>
            {
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
                        UnityEvent.Invoke();
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
