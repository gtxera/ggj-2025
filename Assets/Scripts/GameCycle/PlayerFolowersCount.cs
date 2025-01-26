using System;
using TMPro;
using UnityEngine;

public class PlayerFolowersCount : MonoBehaviour
{
    [SerializeField]
    private int[] _counts;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        SetFollowers(0);
        DaysManager.Instance.NextDay += (day, _, _) => SetFollowers(day);
    }

    private void SetFollowers(int day)
    {
        _text.text = $"Seguidores: {Post.FormatNumber(_counts[day])}";
    }
}
