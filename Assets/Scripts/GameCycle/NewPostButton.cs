using System;
using UnityEngine;
using UnityEngine.UI;

public class NewPostButton : MonoBehaviour
{
    private Button _button;
    
    private void Start()
    {
        DaysManager.Instance.TransitionStarted += OnTransitionStarted;
        DaysManager.Instance.NextDay += (day, _, _) => OnNextDay(day);

        _button = GetComponent<Button>();
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
