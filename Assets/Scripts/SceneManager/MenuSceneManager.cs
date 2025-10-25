using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{

    public Button userNameButton;
    public Button userPassordButton;

    public GameObject enterText;


    [SerializeField] string username;
    [SerializeField] string password;

    public TMP_Text nameText;
    public TMP_Text passwordText;

    DialogueManager dialogueManager;
    UIManager uiManager;


    public CanvasGroup desktopCanvas;
    
    private void Start()
    {
        enterText.SetActive(false);
        dialogueManager =DialogueManager.Instance;
        uiManager=UIManager.Instance;
        userNameButton.onClick.AddListener(CallAI);
        userPassordButton.onClick.AddListener(CallAI);

        desktopCanvas.DOFade(1, 0.5f);
    }

    void CallAI() {
        dialogueManager.BeginDialogueSequence(1, () => {
            DialogueManager.Instance.AddDialogueEvent(1, 4, CallSelect);
            DialogueManager.Instance.AddDialogueEvent(1, 6, () =>
            {
                dataReady = true;
                enterText.SetActive(true);
            });
        });
    }

    void CallSelect() {
        uiManager.ShowPanel<PlayerSelectPanel>(panel => {
            panel.CreateOneSelectButton("不需要",fillData);
            panel.CreateOneSelectButton("这是我的设备，我能处理",fillData);
        },null);
    }

    bool dataReady=false;

    void fillData() { 
        nameText.text= username;
        passwordText.text = password;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (dataReady) {
                SceneLoadManager.Instance.LoadNewScene(1);
            }
        }
    }
}
