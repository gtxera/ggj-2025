using UnityEngine;

[CreateAssetMenu(fileName = "User", menuName = "Scriptable Objects/User")]
public class User : ScriptableObject
{
    [SerializeField]
    private string _username;

    [SerializeField]
    private Sprite _icon;

    public string Username => _username == "player" ? DaysManager.Instance.PlayerName : _username;
    public Sprite Icon => _icon;
}
