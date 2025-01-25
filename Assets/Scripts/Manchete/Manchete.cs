using UnityEngine;

[CreateAssetMenu(fileName = "Manchete", menuName = "Scriptable Objects/Manchete")]
public class Manchete : ScriptableObject
{
    public static string Erase => "{erase={0}}";

    [SerializeField]
    private string _text;

    public string Texto => _text;
}
