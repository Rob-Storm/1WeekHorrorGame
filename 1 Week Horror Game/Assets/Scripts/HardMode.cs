using UnityEngine;

public class HardMode : MonoBehaviour
{
    public bool isEnabled = false;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("HardModeEnabled", 0) == 1) isEnabled = true;
        else isEnabled = false;
    }

    public void CheckPref()
    {
        if (isEnabled) PlayerPrefs.SetInt("HardModeEnabled", 1);
        else PlayerPrefs.SetInt("HardModeEnabled", 0);
    }
}
