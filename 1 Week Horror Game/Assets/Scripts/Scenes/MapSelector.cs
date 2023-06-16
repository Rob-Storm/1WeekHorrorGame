using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelector : MonoBehaviour
{
    public TMP_InputField mapText;

    string mapName = string.Empty;

    public void OnTextChanged()
    {
        mapName = mapText.text;
    }

    public void LoadMap()
    {
        SceneManager.LoadScene(mapName);
    }
}
