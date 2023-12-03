using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    private static AudioPlayer instance;

    private void Awake()
    {
         if (instance == null)
         {
            instance = this;
            DontDestroyOnLoad(gameObject);
         }
         else
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void StopAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}

