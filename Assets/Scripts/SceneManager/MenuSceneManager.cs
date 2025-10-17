using TMPro;
using UnityEngine;

public class MenuSceneManager : MonoBehaviour
{
    [SerializeField] string username;
    [SerializeField] string password;

    public TMP_Text nameText;
    public TMP_Text passwordText;

    bool dataReady=false;

    public void EnterDesktop() {
        if(dataReady)
        SceneLoadManager.Instance.LoadNewScene(1);
    }

    void fillData() { 
        nameText.text= username;
        passwordText.text = password;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            fillData();
            if (dataReady) { 
            EnterDesktop();
            }
            dataReady = true;
        }
    }
}
