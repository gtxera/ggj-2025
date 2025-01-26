using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundOnClick : MonoBehaviour
{
    [SerializeField]
    private AudioClip _sound;

    private AudioSource _player;

    private void Start()
    {
        _player.clip = _sound;
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(() => _player.Play());
    }
}
