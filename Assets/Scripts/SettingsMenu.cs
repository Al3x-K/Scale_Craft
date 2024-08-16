using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Toggle bgmToggle;
    public Toggle sfxToggle;

     private void Start()
    {
        bgmSlider.value = SoundManager.instance.bgmSource.volume;
        sfxSlider.value = SoundManager.instance.sfxSource.volume;

        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        bgmToggle.isOn = SoundManager.instance.bgmSource.isPlaying;
        sfxToggle.isOn = SoundManager.instance.isSFXEnabled; 

        bgmToggle.onValueChanged.AddListener(ToggleBGM);
        sfxToggle.onValueChanged.AddListener(ToggleSFX);
    }

    public void SetBGMVolume(float volume)
    {
        SoundManager.instance.SetBGMVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        SoundManager.instance.SetSFXVolume(volume);
    }

    public void ToggleBGM(bool isEnabled)
    {
        SoundManager.instance.ToggleBGM(isEnabled);
    }

    public void ToggleSFX(bool isEnabled)
    {
        SoundManager.instance.ToggleSFX(isEnabled);
    }

}
