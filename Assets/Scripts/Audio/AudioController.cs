using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _mixer;

    [SerializeField]
    private Slider _sfxSlider;

    [SerializeField]
    private Slider _musicSlider;

    private void Start()
    {
        _sfxSlider.onValueChanged.AddListener((f) => _mixer.SetFloat("SFXVolume", f));
    }
}
