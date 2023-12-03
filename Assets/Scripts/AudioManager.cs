using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon; // serialize makes these visible and settable in inspector, but not public
    [SerializeField] Image soundOffIcon;

    private bool isMuted = false;

    void Start()
    {
        Load();
        UpdateIcon();
        AudioListener.pause = isMuted;
    }

    public void OnButtonPress()
    {
        if (!isMuted)
        {
            isMuted = true;
            AudioListener.pause = true;
        }
        else
        {
            isMuted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (!isMuted)
        {
            soundOffIcon.enabled = false;
            soundOnIcon.enabled = true;
        }
        else
        {
            soundOffIcon.enabled = true;
            soundOnIcon.enabled = false;
        }
    }

    private void Load()
    {
        isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1; // 0 is default value if no "IsMuted" found in prefs
    }

    private void Save()
    {
        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
    }
}

