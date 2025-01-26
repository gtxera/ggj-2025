using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Main Screens")]
    [SerializeField] GameObject workareaScreen;
    [SerializeField] GameObject feedScreen;

    [SerializeField]
    private GameObject loginScreen;

    [Header("Pop Ups Screens")]
    [SerializeField] GameObject generalPopUpScreen;
    [SerializeField] GameObject postPopUp;
    [SerializeField] GameObject settingsPopUp;
    [SerializeField] GameObject notesPopUp;
    [SerializeField] GameObject errorPopUp;
    [SerializeField] GameObject uploadPopUp;

    [SerializeField]
    private GameObject affirmationPopup;

    public void SwitchMainScreens(int index)
    {
        workareaScreen.SetActive(index == (int)MainScreens.WorkArea);
        feedScreen.SetActive(index == (int)MainScreens.Feed);
        loginScreen.SetActive(index == (int)MainScreens.Login);
    }

    public void SwitchPopUp(int index)
    {
        generalPopUpScreen.SetActive(index != 0);
        settingsPopUp.SetActive(index == (int)Popups.Settings);
        notesPopUp.SetActive(index == (int)Popups.Notes);
        errorPopUp.SetActive(index == (int)Popups.Error);
        postPopUp.SetActive(index == (int)Popups.Post);
        affirmationPopup.SetActive(index == (int)Popups.Affirmation);
        uploadPopUp.SetActive(index == (int)Popups.Upload);
    }
}

public enum MainScreens
{
    None,
    WorkArea,
    Feed,
    Login
}

public enum Popups
{
    None,
    Settings,
    Notes,
    Error,
    Post,
    Affirmation,
    Upload
}