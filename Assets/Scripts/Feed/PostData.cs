using UnityEngine;

[CreateAssetMenu(fileName = "PostData", menuName = "Scriptable Objects/PostData")]
public class PostData : ScriptableObject
{
    [SerializeField]
    private User _user;

    [SerializeField, Multiline]
    private string _text;

    [SerializeField]
    private Sprite _image;

    [SerializeField]
    private int _likes;
    
    [SerializeField]
    private int _comments;
    
    [SerializeField]
    private int _shares;

    public User User => _user;
    public string Text => _text;
    public Sprite Image => _image;
    public int Likes => _likes;
    public int Comments => _comments;
    public int Shares => _shares;
}
