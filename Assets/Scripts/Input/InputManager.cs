using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private MainInputActions _actions;

    private void Start()
    {
        _actions = new MainInputActions();
    }
}
