using UnityEngine;
using UnityEngine.UI;

public class NewPostButton : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    
    private Button _button;
    
    private void Start()
    {
        DaysManager.Instance.TransitionStarted += OnTransitionStarted;
        DaysManager.Instance.NextDay += (day, _, _) => OnNextDay(day);

        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (DaysManager.Instance.IsFinalDay)
        {
            _gameManager.SwitchMainScreens(MainScreens.Credits);
        }
        else
        {
            _gameManager.SwitchPopUp(PopUps.Post);
        }
    }

    private void OnTransitionStarted()
    {
        _button.interactable = false;
    }

    private void OnNextDay(int day)
    {
        _button.interactable = true;
    }
}
