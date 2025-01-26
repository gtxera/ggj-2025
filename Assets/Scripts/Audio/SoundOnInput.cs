using UnityEngine;
using Random = UnityEngine.Random;

public class SoundOnInput : MonoBehaviour
{
    private MainInputActions _actions;


    [SerializeField]
    private AudioClip _click;

    [SerializeField]
    private AudioClip[] _typingSounds;

    private void Start()
    {
        _actions = new MainInputActions();
        _actions.Enable();

        _actions.Main.Type.performed += (_) =>
        {
            SFX.Instance.Play(_typingSounds[Random.Range(0, _typingSounds.Length)]);
        };
        
        _actions.Main.Click.performed += (_) => SFX.Instance.Play(_click);
    }
}
