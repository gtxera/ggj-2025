using UnityEngine;

[CreateAssetMenu(fileName = "FeedScript", menuName = "Scriptable Objects/FeedScript")]
public class FeedScript : ScriptableObject
{
    public string username;
    public string postText;
    public int likes;
    public int comments;
    public int shares;
}
