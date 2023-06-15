using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
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
