using UnityEngine;

public class MenuSceneManager : MonoBehaviour
{
    public void testOpen()
    {
        UIManager.Instance.ShowPanel<SceneTransPanel>(null,null);
    }
    public void testHide()
    {
        UIManager.Instance.HidePanel<SceneTransPanel>();
    }
}
