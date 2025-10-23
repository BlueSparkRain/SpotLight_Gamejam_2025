using UnityEngine;

public class AddressableTest : MonoBehaviour
{
    DialogueManager DialogueManagerInstance;
    private void Start()
    {
        DialogueManagerInstance = DialogueManager.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DialogueManagerInstance.BeginDialogueSequence(1, () =>
            {
                DialogueManager.Instance.AddDialogueEvent(1, 2, T1);
                DialogueManager.Instance.AddDialogueEvent(1, 4, T2);
            });
        }
    }

    void T1()
    {
        //Debug.Log("Fuck Me!");
    }

    void T2()
    {
        //Debug.Log("Fuck You!");
    }
}
