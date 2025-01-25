using UnityEngine;

public static class InputManager
{
    private static MainInputActions _actions;

    public static MainInputActions.NavigationActions NavigationActions => _actions.Navigation;

    public static MainInputActions.MancheteTyperActions MancheteTyperActions => _actions.MancheteTyper;

    
    static InputManager()
    {
        _actions = new MainInputActions();
    }

    public static void SwitchToMancheteTyper()
    {
        _actions.Navigation.Disable();
        _actions.MancheteTyper.Enable();
    }
    
    public static void SwitchToNavitgation()
    {
        _actions.Navigation.Enable();
        _actions.MancheteTyper.Disable();
    }
}
