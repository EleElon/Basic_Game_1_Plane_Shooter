using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour {
    [Header("---------- UI References ----------")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider vfxSlider;

    public Text masterText;
    public Text musicText;
    public Text vfxText;

    [Header("---------- Audio Mixer ----------")]
    public AudioMixer audioMixer;

    // Keys lưu trong PlayerPrefs
    private const string MasterKey = "MasterVolume";
    private const string MusicKey = "MusicVolume";
    private const string VFXKey = "VFXVolume";

    void Start() {
        InitializeSlider(masterSlider, MasterKey, "MasterVolume", masterText);
        InitializeSlider(musicSlider, MusicKey, "MusicVolume", musicText);
        InitializeSlider(vfxSlider, VFXKey, "VFXVolume", vfxText);
    }

    void InitializeSlider(Slider slider, string key, string exposedParam, Text text) {
        float savedVolume = PlayerPrefs.GetFloat(key, 0.75f);
        slider.value = savedVolume;
        ApplyVolume(exposedParam, savedVolume, text);

        slider.onValueChanged.AddListener((value) => OnVolumeSliderChanged(value, key, exposedParam, text));
    }

    void OnVolumeSliderChanged(float value, string key, string exposedParam, Text text) {
        ApplyVolume(exposedParam, value, text);
        SaveVolume(key, value);
    }

    void ApplyVolume(string exposedParam, float value, Text text) {
        float volumeInDb = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20;
        audioMixer.SetFloat(exposedParam, volumeInDb);

        if (text != null) {
            text.text = $"{exposedParam.Replace("Volume", "")}: {(int)(value * 100)}%";
        }
    }

    void SaveVolume(string key, float value) {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }
}