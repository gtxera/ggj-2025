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

    public void SwitchMainScreens(int index)
    {
        workareaScreen.SetActive(index == 1);
        feedScreen.SetActive(index == 2);
        loginScreen.SetActive(index == 3);
    }

    public void SwitchPopUp(int index)
    {
        generalPopUpScreen.SetActive(index != 0);
        settingsPopUp.SetActive(index == 1);
        notesPopUp.SetActive(index == 2);
        errorPopUp.SetActive(index == 3);
        postPopUp.SetActive(index == 4);
    }
}
