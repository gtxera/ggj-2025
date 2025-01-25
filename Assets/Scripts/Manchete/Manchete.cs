using UnityEngine;

[CreateAssetMenu(fileName = "Manchete", menuName = "Scriptable Objects/Manchete")]
public class Manchete : ScriptableObject
{
    [SerializeField]
    private string _text;

    public string Texto => _text;
}
