using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _mixer;
    
    [SerializeField]
    private Slider _masterSlider;

    [SerializeField]
    private Slider _sfxSlider;

    [SerializeField]
    private Slider _musicSlider;

    private void Start()
    {
        _sfxSlider.onValueChanged.AddListener((f) => _mixer.SetFloat("SFXVolume", Mathf.Log10(f) * 20));
        _musicSlider.onValueChanged.AddListener((f) => _mixer.SetFloat("MusicVolume", Mathf.Log10(f) * 20));
        _masterSlider.onValueChanged.AddListener((f) => _mixer.SetFloat("MasterVolume", Mathf.Log10(f) * 20));
    }
}
