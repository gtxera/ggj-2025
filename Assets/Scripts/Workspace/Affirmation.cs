using System;
using UnityEngine;
using UnityEngine.UI;

public class Affirmation : MonoBehaviour
{
    [SerializeField]
    private Sprite _affirmationSprite;

    [SerializeField]
    private Image _affirmationImage;

    [SerializeField]
    private GameManager _gameManager;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OpenAffirmation);
    }

    private void OpenAffirmation()
    {
        _affirmationImage.sprite = _affirmationSprite;
        _gameManager.SwitchPopUp((int)Popups.Affirmation);
    }
}
