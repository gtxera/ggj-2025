using System;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    private AudioClip _menuMusic;

    [SerializeField]
    private AudioClip _gameMusic;
    
    private AudioSource _source;
    
    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = _menuMusic;
        _source.Play();
        DaysManager.Instance.NextDay += (_, _, _) => StopMusic();
        
    }

    public void StartGame()
    {
        _source.clip = _gameMusic;
        _source.Play();
    }

    private void StopMusic()
    {
        _source.Stop();
    }
}
