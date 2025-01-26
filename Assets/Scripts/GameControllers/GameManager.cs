using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Main Screens")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject workareaScreen;
    [SerializeField] GameObject feedScreen;

    [SerializeField]
    private GameObject loginScreen;

    [SerializeField]
    private GameObject creditsScreen;

    [Header("Pop Ups Screens")]
    [SerializeField] GameObject generalPopUpScreen;
    [SerializeField] GameObject postPopUp;
    [SerializeField] GameObject settingsPopUp;
    [SerializeField] GameObject notesPopUp;
    [SerializeField] GameObject errorPopUp;
    [SerializeField] GameObject uploadPopUp;

    [SerializeField]
    private GameObject affirmationPopup;

    [Header("Other Elements")]
    [SerializeField] Animator mainMenuAnim;
    [SerializeField] Animator loginAnim;

    private void Awake()
    {
        //SwitchMainScreens(MainScreens.MainMenu);   
    }

    private void Start()
    {
        DaysManager.Instance.NextDay += (_, _, _) => OnNextDay();
    }

    public void StartGame()
    {
        mainMenuAnim.SetTrigger("Play");
    }

    public void SwitchMainScreens(MainScreens screen)
    {
        mainMenu.SetActive(screen == MainScreens.MainMenu);
        workareaScreen.SetActive(screen == MainScreens.WorkArea);
        feedScreen.SetActive(screen == MainScreens.Feed);
        loginScreen.SetActive(screen == MainScreens.Login);
        creditsScreen.SetActive(screen == MainScreens.Credits);
    }

    public void SwitchMainScreens(int index)
    {
        SwitchMainScreens((MainScreens)index);
    }

    public void SwitchPopUp(PopUps popUp)
    {
        generalPopUpScreen.SetActive(popUp != PopUps.None);
        settingsPopUp.SetActive(popUp == PopUps.Settings);
        notesPopUp.SetActive(popUp == PopUps.Notes);
        errorPopUp.SetActive(popUp == PopUps.Error);
        postPopUp.SetActive(popUp == PopUps.Post);
        affirmationPopup.SetActive(popUp == PopUps.Affirmation);
        uploadPopUp.SetActive(popUp == PopUps.Upload);
    }

    public void SwitchPopUp(int index)
    {
        SwitchPopUp((PopUps)index);
    }

    private void OnNextDay()
    {
        SwitchMainScreens(MainScreens.WorkArea);
    }
}

public enum MainScreens
{
    MainMenu,
    WorkArea,
    Feed,
    Login,
    Credits
}

public enum PopUps
{
    None,
    Settings,
    Notes,
    Error,
    Post,
    Affirmation,
    Upload
}