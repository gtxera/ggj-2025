using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFX : MonoBehaviour
{
    public static SFX Instance { get; private set; }
    
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        Instance = this;
    }

    public void Play(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }
}
