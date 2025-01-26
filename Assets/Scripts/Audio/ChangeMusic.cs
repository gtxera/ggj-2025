using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    [SerializeField]
    private Music _music;

    public void Change()
    {
        _music.StartGame();
    }
}
