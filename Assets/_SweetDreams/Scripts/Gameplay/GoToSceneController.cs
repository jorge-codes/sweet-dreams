using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneController : MonoBehaviour
{
    [SerializeField] private float delayDefault = 0.7f;
    public void GoToScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName, delayDefault));
    }

    private IEnumerator LoadScene(string sceneName, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
