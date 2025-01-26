using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Post : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _usernameText;

    [SerializeField]
    private Image _userIconImage;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private TextMeshProUGUI _likesText;

    [SerializeField]
    private TextMeshProUGUI _commentsText;

    [SerializeField]
    private TextMeshProUGUI _sharesText;

    private PostData _data;

    private bool _hasNumbers;

    public void BindData(PostData data, bool withNumbers)
    {
        _data = data;
        _usernameText.text = data.User.Username;
        _userIconImage.sprite = data.User.Icon;
        _image.sprite = data.Image;
        _image.gameObject.SetActive(data.Image != null);
        _text.text = data.Text;
        _hasNumbers = withNumbers;
        if (!withNumbers) return;
        _likesText.text = FormatNumber(data.Likes);
        _commentsText.text = FormatNumber(data.Comments);
        _sharesText.text = FormatNumber(data.Shares);
    }

    public void BindNumbers()
    {
        if (_hasNumbers)
            return;
        
        _likesText.text = FormatNumber(_data.Likes);
        _commentsText.text = FormatNumber(_data.Comments);
        _sharesText.text = FormatNumber(_data.Shares);
        _hasNumbers = true;
    }

    public static string FormatNumber(int n)
    {
        return n switch
        {
            < 1000 => n.ToString(),
            < 10000 => string.Format("{0:#,.##}K", n - 5),
            < 100000 => string.Format("{0:#,.#}K", n - 50),
            < 1000000 => string.Format("{0:#,.}K", n - 500),
            < 10000000 => string.Format("{0:#,,.##}M", n - 5000),
            < 100000000 => string.Format("{0:#,,.#}M", n - 50000),
            < 1000000000 => string.Format("{0:#,,.}M", n - 500000),
            _ => string.Format("{0:#,,,.##}B", n - 5000000)
        };
    }
}
