using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerScreen : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HelpMenu;
    public GameObject CreditsScreen;
    public GameObject GraphicsScreen;

    public HardMode hardmode;

    public Toggle hardModeCheckbox;

    private void Start()
    {
        if (hardModeCheckbox.isOn)
        {
            hardmode.isEnabled = true;
        }
        else
        {
            hardmode.isEnabled = false;
        }

        hardmode.CheckPref();
    }

    public void CheckBox()
    {
        if(hardModeCheckbox.isOn) 
        {
            hardmode.isEnabled = true;
        }
        else
        {
            hardmode.isEnabled = false;
        }

        hardmode.CheckPref();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Mission1");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Help()
    {
        MainMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        HelpMenu.SetActive(false);
    }

    public void Credits()
    {
        MainMenu.SetActive(false);
        CreditsScreen.SetActive(true);
    }

    public void BackCredits()
    {
        MainMenu.SetActive(true);
        CreditsScreen.SetActive(false);
    }

    public void Graphics()
    {
        MainMenu.SetActive(false);
        GraphicsScreen.SetActive(true);
    }

    public void BackGraphics()
    {
        MainMenu.SetActive(true);
        GraphicsScreen.SetActive(false);
    }

    public void LogoClick()
    {
        Application.OpenURL("https://www.develteam.com/Game/1-Week-Horror-Game");
    }
}
