using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FinalCutscene : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private string _finalText;

    [SerializeField]
    private float _charactersPerSecond;

    [SerializeField]
    private RectTransform _creditsBase;

    [SerializeField]
    private float _endCreditsPosition;

    [SerializeField]
    private float _creditsDuration;
    
    public void Start()
    {
        var text = "";
        var tween = DOTween.To(
            () => text,
            x => text = x,
            _finalText,
            _finalText.Length / _charactersPerSecond)
            .OnUpdate(() =>
            {
                _text.SetText(text);
            })
            .OnComplete(() =>
            {
                StartCoroutine(CreditsRoutine());
            });
    }

    private IEnumerator CreditsRoutine()
    {
        yield return new WaitForSeconds(5f);
        
        var tween = _creditsBase.DOAnchorPosY(_endCreditsPosition, _creditsDuration).SetEase(Ease.Linear);

        var complete = false;

        tween.onComplete += () => complete = true;

        while (!complete)
        {
            yield return null;
        }

        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
}
