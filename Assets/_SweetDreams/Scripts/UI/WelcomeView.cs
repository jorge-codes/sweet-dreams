using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeView : MonoBehaviour
{
    [SerializeField] private Button buttonPlay = null;
    [SerializeField] private Button buttonCredits = null;
    [SerializeField] private Button buttonBack = null;
    [SerializeField] private AudioClip clipButtonCredits = null;
    [SerializeField] private AudioClip clipButtonCancel = null;
    [SerializeField] private AudioSource audioSource = null;

    [SerializeField] private TextMeshProUGUI labelVersion = null;
    [SerializeField] private string labelVersionFormat = "v{0}";

    [Space(10), Header("Mini Views")]
    [SerializeField] private GameObject viewTitle = null;
    [SerializeField] private GameObject viewCredits = null;
    
    [Space(10), Header("Intro scene config")]
    [SerializeField] private string nextSceneName = "_IntroScene";

    private void OnEnable()
    {
        buttonPlay.onClick.AddListener(OnButtonPlayPressed);
        buttonCredits.onClick.AddListener(OnButtonCreditsPressed);
        buttonBack.onClick.AddListener(OnButtonBackPressed);
    }

    private void OnDisable()
    {
        buttonPlay.onClick.RemoveAllListeners();
        buttonCredits.onClick.RemoveAllListeners();
        buttonBack.onClick.RemoveAllListeners();
    }

    private void Start()
    {
        labelVersion.text = GetVersionString(labelVersionFormat);
    }

    private void OnButtonPlayPressed()
    {
        audioSource.PlayOneShot(clipButtonCredits);
        StartCoroutine(GoToIntroScene());
    }

    private void OnButtonCreditsPressed()
    {
        audioSource.PlayOneShot(clipButtonCredits);
        ShowCredits();
    }

    private void OnButtonBackPressed()
    {
        audioSource.PlayOneShot(clipButtonCancel);
         ShowTitle();
    }

    private IEnumerator GoToIntroScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(nextSceneName);
    }

    private void ShowCredits()
    {
        viewCredits.SetActive(true);
        viewTitle.SetActive(false);
    }

    private void ShowTitle()
    {
        viewCredits.SetActive(false);
        viewTitle.SetActive(true);
    }

    private string GetVersionString(string format)
    {
        var version = Application.version;
        return string.Format(format, version);
    }


}
