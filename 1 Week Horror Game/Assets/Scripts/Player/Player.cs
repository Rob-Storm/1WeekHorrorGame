using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Light flashlight;
    public ObjectiveManager manager;

    bool enableLight = true;

    public AudioSource audioSource;
    public AudioClip flashToggle;

    public float interactDistance = 5f;

    public TMP_Text interactionText;

    public Camera cam;

    PauseMenu pauseMenu;

    public HardMode hardmode;

    // Start is called before the first frame update
    void Start()
    {
        if (hardmode.isEnabled)
        {
            flashlight.enabled = false;
            enableLight = false;
        }
        pauseMenu = GetComponent<PauseMenu>();

        //UGLY workaround to that mouse issue, may be noticeable on slower hardware
        pauseMenu.OpenMenu();
        pauseMenu.CloseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        Debug();

        Controls();

        Interact();
    }

    void Interact()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

        RaycastHit hit;

        bool successfulHit = false;

        if(Physics.Raycast(ray, out hit, interactDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if(interactable != null)
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;
            }
        }

        if(!successfulHit)
        {
            interactionText.text = string.Empty;
        }
    }

    private void HandleInteraction(Interactable interactable)
    {
        KeyCode key = KeyCode.Mouse1;

        switch(interactable.interactionType) 
        {
            case Interactable.InteractionType.Click:
                if(Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;

            case Interactable.InteractionType.Hold:
                if (Input.GetKey(key))
                {
                    interactable.Interact();
                }
                break;

            case Interactable.InteractionType.Minigame:
                //Do shit
                break;

            default:
                throw new Exception("Unsupported Type of Interactable");
        }
    }

    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.F) && enableLight)
        {
            flashlight.enabled = !flashlight.enabled;
            audioSource.PlayOneShot(flashToggle);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.OpenMenu();
        }
    }

    void Debug()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Cursor.visible = !Cursor.visible;
        }

        if(Input.GetKeyDown(KeyCode.K)) 
        {
            Death();
        }
    }

    public void Death()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver");
    }
}