using UnityEngine;

public class SoundEffectsController : MonoBehaviour
{
    private AudioSource audioSource = null;

    public void PlayOneShot(AudioClip clip)
    {
        // TODO: improve to handle max 4-8 sounds
        // 8 is the limit for mobile devices, for example
        audioSource.PlayOneShot(clip);
    }
    
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }
}
