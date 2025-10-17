
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoSingleton<SceneLoadManager>
{

    public void LoadNewScene(int buildindex)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(buildindex);
    }
}
