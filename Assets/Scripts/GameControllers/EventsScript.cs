using UnityEngine;
using UnityEngine.Events;

public class EventsScript : MonoBehaviour
{
    public UnityEvent action;

    public void Act()
    {
        action.Invoke();
    }
}
