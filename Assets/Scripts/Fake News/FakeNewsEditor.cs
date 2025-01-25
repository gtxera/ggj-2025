using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FakeNewsEditor : MonoBehaviour
{
    [SerializeField]
    private Button _overlayButton;

    [SerializeField]
    private Image _baseImage;

    [SerializeField]
    private Image _postImage;

    [SerializeField]
    private TMP_InputField _postTextField;

    [SerializeField]
    private Button _finishEditButton;
    
    [SerializeField]
    private Button _publishButton;

    [SerializeField]
    private Feed _feed;

    [SerializeField]
    private FakeNews _currentFakeNews;
    private IEnumerator<Sprite> _overlaysEnumerator;
    private Sprite _currentOverlay;

    private StringBuilder _currentTextTyped;
    
    private void Start()
    {
        _overlayButton.onClick.AddListener(CycleOverlay);
        _postTextField.onValueChanged.AddListener(OnTextReceived);
        _finishEditButton.onClick.AddListener(FinishEditImage);
        _publishButton.onClick.AddListener(Publish);
        _currentTextTyped = new StringBuilder();
        LoadFakeNews(_currentFakeNews);
    }

    public void LoadFakeNews(FakeNews fakeNews)
    {
        _currentFakeNews = fakeNews;
        _baseImage.sprite = _currentFakeNews.BaseImage;
        _finishEditButton.interactable = false;
        _publishButton.interactable = false;
        _currentTextTyped.Clear();
        _overlaysEnumerator = _currentFakeNews.Posts.Keys.GetEnumerator();
        _overlaysEnumerator.MoveNext();
        _currentOverlay = _overlaysEnumerator.Current;
        _overlayButton.image.sprite = _currentOverlay;
        _postTextField.SetTextWithoutNotify("");
    }

    private void CycleOverlay()
    {
        if (!_overlaysEnumerator.MoveNext())
        {
            _overlaysEnumerator = _currentFakeNews.Posts.Keys.GetEnumerator();
            _overlaysEnumerator.MoveNext();
            _finishEditButton.interactable = true;
        }

        _currentOverlay = _overlaysEnumerator.Current;
        _overlayButton.image.sprite = _currentOverlay;
    }

    private void FinishEditImage()
    {
        _finishEditButton.image.sprite = _currentFakeNews.GetFullImageFor(_currentOverlay);
    }

    private void OnTextReceived(string text)
    {
        var fullText = _currentFakeNews.GetTextFor(_currentOverlay);
        
        if (_currentTextTyped.Length == fullText.Length)
        {
            _postTextField.SetTextWithoutNotify(fullText);
            _postTextField.caretPosition = _postTextField.text.Length;
            return;
        }

        _currentTextTyped.Append(fullText[_currentTextTyped.Length]);
        _postTextField.SetTextWithoutNotify(_currentTextTyped.ToString());
        _postTextField.caretPosition = _postTextField.text.Length;

        if (_currentTextTyped.Length == fullText.Length)
        {
            _publishButton.interactable = true;
        }
    }

    private void Publish()
    {
        _feed.CreatePost(_currentFakeNews.GetPostFor(_currentOverlay), false);
    }
}
