
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoSingleton<SceneLoadManager>
{
    public void AdditiveNewScene(int buildindex)
    {
        SceneManager.LoadScene(buildindex,LoadSceneMode.Additive);
    }

    public void UnloadScene(int buildindex) {
        SceneManager.UnloadSceneAsync(buildindex);
    }
    public void LoadNewScene(int buildindex)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(buildindex);
    }
}
