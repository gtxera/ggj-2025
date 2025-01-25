using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-9999999)]
public class DaysManager : MonoBehaviour
{
    public static DaysManager Instance { get; private set; }

    public string PlayerName { get; private set; } = "testePlayer";
    
    public Action<int, string, FakeNews> NextDay;
    public Action TransitionStarted;

    public bool IsFinalDay => _fakeNews.Length == _currentDay;

    [SerializeField]
    private FakeNews[] _fakeNews;

    [SerializeField]
    private float _waitTimeBetweenDays;

    [SerializeField]
    private float _fadeDuration;

    [SerializeField]
    private Image _fadeImage;
    
    private int _currentDay;

    private void Awake()
    {
        if (Instance is not null)
            Debug.LogError("DOIS DAYS MANAGER");
        
        Instance = this;
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public void GoToNextDay(string fakeNewsVersion)
    {
        TransitionStarted?.Invoke();
        StartCoroutine(WaitForNextDay(fakeNewsVersion));
    }

    private IEnumerator WaitForNextDay(string fakeNewsVersion)
    {
        yield return new WaitForSeconds(_waitTimeBetweenDays);

        var tween = _fadeImage.DOFade(1, _fadeDuration);
        tween.onComplete += () =>
        {
            _currentDay++;
            NextDay?.Invoke(_currentDay, fakeNewsVersion, IsFinalDay ? null : _fakeNews[_currentDay]);
            _fadeImage.DOFade(0, 0.2f);
        };
    }

    public FakeNews GetInitialFakeNews()
    {
        return _fakeNews[0];
    }
}
