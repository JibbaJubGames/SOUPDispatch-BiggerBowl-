using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer gameAudioMixer;
    
    [SerializeField] private static Slider effectsSlider;
    [SerializeField] public static float effectsVolume;
    
    [SerializeField] private static Slider voiceSlider;
    [SerializeField] public static float voiceVolume;
    
    [SerializeField] private static Slider musicSlider;
    [SerializeField] public static float musicVolume;

    // Start is called before the first frame update
    void Start()
    {
        SetSliders();
        AudioPrefInitialize();
        SaveAndLoad.SetAudioPrefs();
    }

    private static void SetSliders()
    {
        effectsSlider = GameObject.FindGameObjectWithTag("FXSlider").GetComponent<Slider>();
        voiceSlider = GameObject.FindGameObjectWithTag("VoiceSlider").GetComponent<Slider>();
        musicSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>();
    }

    public void AudioPrefInitialize()
    {

        SetSliders();
        UpdateEffectVolume();
        UpdateMusicVolume();
        UpdateVoiceVolume();
    }

    public static void LoadAudioPrefs()
    {
        effectsSlider.value = SaveAndLoad.playerSave.effectsVolume;
        voiceSlider.value = SaveAndLoad.playerSave.voicesVolume;
        musicSlider.value = SaveAndLoad.playerSave.musicVolume;
    }

    public void UpdateEffectVolume()
    {
        effectsVolume = effectsSlider.value;
        gameAudioMixer.SetFloat("Effects", Mathf.Log10(effectsVolume)*20);
    }

    public void UpdateVoiceVolume()
    {
        voiceVolume = voiceSlider.value;
        gameAudioMixer.SetFloat("Voices", Mathf.Log10(voiceVolume) * 20);
    }

    public void UpdateMusicVolume()
    {
        musicVolume = musicSlider.value;
        gameAudioMixer.SetFloat("Music", Mathf.Log10(musicVolume) * 20);
    }
}
