using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public AudioClip clickSound;
    public AudioClip toggleSound;

    public bool isBGMEnabled = true;
    public bool isSFXEnabled = true;

    private float bgmVolume = 1f;
    private float sfxVolume = 1f;
 
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

    public void PlayBGM(AudioClip bgm)
    {
        if (isBGMEnabled)
        {
            bgmSource.clip = bgm;
            bgmSource.Play();
        }
    }

    public void PlaySFX(AudioClip sfx)
    {
        if (isSFXEnabled)
        {
            sfxSource.PlayOneShot(sfx);
        }
    }

    public void PlayClick()
    {
        PlaySFX(clickSound);
    }

    public void PlayToggleSound()
    {
        PlaySFX(toggleSound);
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        bgmSource.volume = bgmVolume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = sfxVolume;
    }

    public void ToggleBGM(bool isEnabled)
    {
        isBGMEnabled = isEnabled;
        if (isBGMEnabled)
        {
            bgmSource.Play();
        }
        else
        {
            bgmSource.Pause();
        }
    }

    public void ToggleSFX(bool isEnabled)
    {
        isSFXEnabled = isEnabled;
    }
}
