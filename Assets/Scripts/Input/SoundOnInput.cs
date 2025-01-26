using UnityEngine;
using Random = UnityEngine.Random;

public class SoundOnInput : MonoBehaviour
{
    private MainInputActions _actions;

    private AudioSource _audio;

    [SerializeField]
    private AudioClip _click;

    [SerializeField]
    private AudioClip[] _typingSounds;

    private void Start()
    {
        _actions = new MainInputActions();
        _actions.Enable();
        _audio = GetComponent<AudioSource>();

        _actions.Main.Type.performed += (_) =>
        {
            _audio.PlayOneShot(_typingSounds[Random.Range(0, _typingSounds.Length)]);
        };
        
        _actions.Main.Click.performed += (_) => _audio.PlayOneShot(_click);
    }
}
