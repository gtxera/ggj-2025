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

    private void CreatePosts(IEnumerable<PostData> data)
    {
        foreach (var postData in data)
        {
            var post = Instantiate(_postPrefab, _feedRect.content);
            post.BindData(postData);
        }

        foreach (var item in _topElementsInOrder.Select((value, i) => new { element = value, index = i}))
        {
            item.element.SetSiblingIndex(item.index);
        }
    }
}
