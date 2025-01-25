using System;
using System.Collections.Generic;
using System.Linq;
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

    private void Start()
    {
        DaysManager.Instance.NextDay += CreatePosts;
    }

    public void CreatePost(PostData data, bool withNumbers = true)
    {
        var post = Instantiate(_postPrefab, _feedRect.content);
        post.BindData(data, withNumbers);
        _posts.Add(post);
    }
    
    private void CreatePosts(int day, string lastDayPost)
    {
        var data = PostLoader.GetPostsFor(lastDayPost);

        foreach (var post in _posts)
        {
            post.BindNumbers();
        }
        
        foreach (var postData in data)
        {
            CreatePost(postData);
        }

        foreach (var item in _topElementsInOrder.Select((value, i) => new { element = value, index = i}))
        {
            item.element.SetSiblingIndex(item.index);
        }
    }
}
