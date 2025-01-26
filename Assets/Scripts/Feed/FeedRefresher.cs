using System;
using System.Collections;
using UnityEngine;

public class FeedRefresher : MonoBehaviour
{
    [SerializeField]
    private Feed _feed;
    
    private bool _needsRefesh;
    
    private void Start()
    {
        DaysManager.Instance.NextDay += (_, _, _) => UpdateFeed();
    }

    private void UpdateFeed()
    {
        _needsRefesh = true;
    }

    private IEnumerator Refresh()
    {
        _feed.gameObject.SetActive(false);
        yield return null;
        _feed.gameObject.SetActive(true);
        _needsRefesh = false;
    }

    private void OnEnable()
    {
        if (_needsRefesh)
            StartCoroutine(Refresh());
    }
}
