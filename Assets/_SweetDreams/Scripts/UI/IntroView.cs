using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroView : MonoBehaviour
{
    
    [SerializeField] public string nextSceneName = "___WelcomeScreen";

    public void GoToWelcomeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    
}
