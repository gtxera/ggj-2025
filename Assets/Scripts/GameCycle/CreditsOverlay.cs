using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CreditsOverlay : MonoBehaviour
{
    [SerializeField]
    private Image[] _images;

    [SerializeField]
    private FakeNews[] _fakeNews;

    private void Start()
    {
        DaysManager.Instance.NextDay += SetOverlay;
    }

    private void SetOverlay(int day, string overlay, FakeNews _)
    {
        var index = day - 1;
        _images[index].sprite = _fakeNews[index].Posts.Keys.Single(s => s.name == overlay);
    }
}
