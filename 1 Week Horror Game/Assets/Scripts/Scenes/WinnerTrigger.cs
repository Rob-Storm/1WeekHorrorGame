using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerTrigger : MonoBehaviour
{

    public string levelName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(levelName);
        }
    }
}
