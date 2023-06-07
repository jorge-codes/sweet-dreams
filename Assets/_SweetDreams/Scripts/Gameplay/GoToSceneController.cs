using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToSceneController : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
