using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOnClick : MonoBehaviour
{
    [SerializeField]
    private AudioClip _sound;

    private void Start()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(() => SFX.Instance.Play(_sound));
    }
}
