using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject interactionText;
    public TMPro.TMP_InputField mouseSensitivity;
    public PlayerMouseLook mouseLook;
    public bool isOpen = false;

    private void Start()
    {
        float mSens = PlayerPrefs.GetFloat("MouseSensitivity", 1) / 100;
        mouseSensitivity.text = $"{mSens}";
    }

    // Update is called once per frame
    void Update()
    {
        mouseLook.mouseSensitivity = (float)Convert.ToDecimal(mouseSensitivity.text) * 100;
        PlayerPrefs.SetFloat("MouseSensitivity", mouseLook.mouseSensitivity);
    }

    public void OpenMenu()
    {
        pauseMenu.SetActive(true);
        interactionText.SetActive(false);
        isOpen = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    public void CloseMenu()
    {
        pauseMenu.SetActive(false);
        interactionText.SetActive(true);
        isOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
