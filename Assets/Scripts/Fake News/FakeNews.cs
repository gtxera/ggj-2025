using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "FakeNews", menuName = "Scriptable Objects/FakeNews")]
public class FakeNews : ScriptableObject
{
    [SerializeField]
    private Sprite _baseImage;
    
    [SerializeField, SerializedDictionary("Overlay", "Data")]
    private SerializedDictionary<Sprite, FakeNewsData> _posts;

    public SerializedDictionary<Sprite, FakeNewsData> Posts => _posts;
    public Sprite BaseImage => _baseImage;

    public Sprite GetFullImageFor(Sprite overlay)
    {
        return _posts[overlay].FullImage;
    }
    
    public string GetTextFor(Sprite overlay)
    {
        return _posts[overlay].Text;
    }

    public PostData GetPostFor(Sprite overlay)
    {
        return _posts[overlay].Post;
    }
    
    [Serializable]
    public struct FakeNewsData
    {
        public Sprite FullImage;
        [Multiline]
        public string Text;

        public PostData Post;
    }
}
