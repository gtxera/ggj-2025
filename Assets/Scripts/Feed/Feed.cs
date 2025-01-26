using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feed : MonoBehaviour
{
    [SerializeField]
    private ScrollRect _feedRect;

    [SerializeField]
    private Post _postPrefab;

    [SerializeField]
    private RectTransform[] _topElementsInOrder;

    private List<Post> _posts = new ();

    private bool _needsUpdate;
    private int _day;
    private string _lastDayPost;

    private void Start()
    {
        DaysManager.Instance.NextDay += SetToUpdate;
    }

    public void CreatePost(PostData data, bool withNumbers = true)
    {
        var post = Instantiate(_postPrefab, _feedRect.content);
        post.transform.SetSiblingIndex(_topElementsInOrder.Length);
        post.BindData(data, withNumbers);
        _posts.Add(post);
    }

    private void SetToUpdate(int _, string lastDayPost, FakeNews __)
    {
        _needsUpdate = true;
        _lastDayPost = lastDayPost;
    }
    
    private void UpdateFeed()
    {
        var data = PostLoader.GetPostsFor(_lastDayPost);

        foreach (var post in _posts)
        {
            post.BindNumbers();
        }
        
        foreach (var postData in data)
        {
            CreatePost(postData);
        }

        _feedRect.content.anchoredPosition = Vector2.zero;
        _feedRect.velocity = Vector2.zero;

        _needsUpdate = false;
    }

    private void OnEnable()
    {
        if (_needsUpdate)
            UpdateFeed();
    }
}
