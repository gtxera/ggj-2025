using System.Collections.Generic;
using UnityEngine;

public static class PostLoader
{
    public static IEnumerable<PostData> GetPostsFor(string post)
    {
        return Resources.LoadAll<PostData>(post);
    }
}
