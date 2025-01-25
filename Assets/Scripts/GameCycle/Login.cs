using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _userNameInputField;

    [SerializeField]
    private TMP_InputField _passwordInputField;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.interactable = false;
        _button.onClick.AddListener(LogIn);
        
        _userNameInputField.onValueChanged.AddListener(ValidateUsername);
        _passwordInputField.onValueChanged.AddListener(Validate);
    }

    private void ValidateUsername(string username)
    {
        if (username.Length > 10)
        {
            _userNameInputField.SetTextWithoutNotify(_userNameInputField.text[..10]);
        }
        
        Validate(username);
    }

    private void Validate(string _)
    {
        if (_userNameInputField.text.Length < 1)
            return;
        
        if (_passwordInputField.text.Length < 3)
            return;

        _button.interactable = true;
    }

    private void LogIn()
    {
        DaysManager.Instance.SetPlayerName(_userNameInputField.text);
    }
}
