using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider voiceSlider;

    void Start()
    {
        // Cargar valores guardados
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.25f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.35f);
        voiceSlider.value = PlayerPrefs.GetFloat("VoiceVolume", 0.50f);

        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
        SetVoiceVolume(voiceSlider.value);
    }

    public void SetMusicVolume(float value)
    {
        masterMixer.SetFloat("Music", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("Music", value);
    }

    public void SetSFXVolume(float value)
    {
        masterMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SFX", value);
    }

    public void SetVoiceVolume(float value)
    {
        masterMixer.SetFloat("Voice", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("Voice", value);
    }
}
