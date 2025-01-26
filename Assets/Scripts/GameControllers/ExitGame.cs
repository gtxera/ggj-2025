using System;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Application.Quit);
    }
}
