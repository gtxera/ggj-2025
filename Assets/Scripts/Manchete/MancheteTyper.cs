using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MancheteTyper : MonoBehaviour
{
    [SerializeField]
    private Manchete _manchete;

    private string _currentText;
    private int _currentIndex;

    private void Start()
    {
        InputManager.MancheteTyperActions.Type.performed += Type;
    }

    private void Type(InputAction.CallbackContext ctx)
    {
        _currentText += _manchete.Texto[_currentIndex];
        _currentIndex++;
    }
}
