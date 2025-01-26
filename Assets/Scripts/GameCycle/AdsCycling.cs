using System;
using UnityEngine;
using UnityEngine.UI;

public class AdsCycling : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _ads;
    
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        SetAd(0);
        DaysManager.Instance.NextDay += (day, _, _) => SetAd(day);
    }

    private void SetAd(int day)
    {
        _image.sprite = _ads[day];
    }
}
