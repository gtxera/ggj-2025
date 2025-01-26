using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundOnClick : MonoBehaviour
{
    [SerializeField]
    private AudioClip _sound;

    [SerializeField]
    private AudioMixerGroup _group;

    private AudioSource _player;

    private void Start()
    {
        _player = GetComponent<AudioSource>();
        _player.clip = _sound;
        _player.outputAudioMixerGroup = _group;
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(() => _player.Play());
    }
}
