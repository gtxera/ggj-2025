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

    [SerializeField]
    private int _dayToAppear;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OpenAffirmation);

        DaysManager.Instance.NextDay += (day, _, _) => TryEnable(day);
        TryEnable(0);
    }

    private void OpenAffirmation()
    {
        _affirmationImage.sprite = _affirmationSprite;
        _gameManager.SwitchPopUp((int)Popups.Affirmation);
    }

    private void TryEnable(int day)
    {
        gameObject.SetActive(day >= _dayToAppear);
    }
}
