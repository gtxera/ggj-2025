using System;
using UnityEngine;

[DefaultExecutionOrder(-9999999)]
public class DaysManager : MonoBehaviour
{
    public static DaysManager Instance { get; private set; }

    public Action<int, string> NextDay;

    private int _currentDay = 1;

    private void Awake()
    {
        if (Instance is not null)
            Debug.LogError("DOIS DAYS MANAGER");
        
        Instance = this;
    }

    public void GoToNextDay(string fakeNewsVersion)
    {
        _currentDay++;
        NextDay?.Invoke(_currentDay, fakeNewsVersion);
    }
}
